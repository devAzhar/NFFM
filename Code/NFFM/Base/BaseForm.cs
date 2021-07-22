namespace NFFM.Base
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public abstract class BaseForm : Form
    {
        #region "Protected Members"
        protected bool FormInitialized = false;
        protected bool HandleCellEventFlag = false;
        protected int InitialDataLoaded = 0;
        protected int IsNewRecord = 0;
        protected Dictionary<string, string> CustomersDictionary { get; private set; } = new Dictionary<string, string>();
        protected Dictionary<string, string> ShippersDictionary { get; private set; } = new Dictionary<string, string>();
        protected Dictionary<string, string> SalesCodeDictionary { get; private set; } = new Dictionary<string, string>();

        protected Dictionary<string, string> ItemsDictionary = new Dictionary<string, string>();
        protected DataTable Customers { get; set; }
        protected DataTable Shippers { get; set; }
        protected DataTable SalesCode { get; set; }
        #endregion

        protected abstract void OnCellValueChanged(int eventRowIndex, int eventColumnIndex = 3, bool ignoreDBSave = false);

        protected static bool IsAlreadyOpen(Type formType)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == formType)
                {
                    f.BringToFront();
                    isOpen = true;
                    break;
                }
            }
            return isOpen;
        }
        protected bool IsAlertShown { get; set; } = false;

        #region "Virtual Members"
        protected virtual void OnComboBoxGeneralEnter(object sender)
        {
            var combobox = sender as ComboBox;

            if (combobox != null && !combobox.DroppedDown)
            {
                combobox.DroppedDown = true;
            }
        }

        protected virtual void LoadTruckers(ComboBox ddlTruckerName, DataTable dtTruckers, string selectedValue = "")
        {
            FormInitialized = false;
            if (dtTruckers.Rows.Count > 0)
            {
                ItemsDictionary.Clear();
                ItemsDictionary.Add("-1", "<<Add New Trucker>>");
                AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
                for (int i = 0; i < dtTruckers.Rows.Count; i++)
                {
                    string value = dtTruckers.Rows[i]["Trucker"].ToString();
                    ItemsDictionary.Add(dtTruckers.Rows[i]["truckerID"].ToString(), value);
                    autoCompleteStringCollection.Add(value);
                }
                ddlTruckerName.DataSource = new BindingSource(ItemsDictionary, null);
                ddlTruckerName.DisplayMember = "Value";
                ddlTruckerName.ValueMember = "Key";
                if (ddlTruckerName.AutoCompleteMode != 0)
                {
                    ddlTruckerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    ddlTruckerName.AutoCompleteCustomSource = autoCompleteStringCollection;
                }
                if (!string.IsNullOrEmpty(selectedValue))
                {
                    ddlTruckerName.SelectedValue = selectedValue;
                }
                FormInitialized = true;
            }
        }
        #endregion

        #region "Abstract Methods"
        protected virtual ComboBox ComboBoxTruckerName { get; }
        protected virtual void LoadData(int id) { }
        protected virtual void BindLineItems(DataTable dtLineItems) { }
        protected virtual void RecalculateTotals() { }
        protected virtual void HandleCellEvent(object sender, DataGridViewCellEventArgs e, bool isClick = false) { }
        #endregion

        #region "Protected Methods"
        private AutoCompleteStringCollection GetAutoCompleteValues(int columnIndex)
        {
            var dataCollection = new AutoCompleteStringCollection();
            DataTable dataTable = null;
            var fieldName = string.Empty;

            switch (columnIndex)
            {
                case 4: //Customer
                    dataTable = Customers;
                    fieldName = "Name";
                    break;
                case 5: //Shipper
                    dataTable = Shippers;
                    fieldName = "Shipper";
                    break;
                case 6: //Sales Code
                    dataTable = SalesCode;
                    fieldName = "Sales Code";
                    break;
            }

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    dataCollection.Add(Convert.ToString(row[fieldName]));
                }
            }

            return dataCollection;
        }

        protected void OndataGridView1_EditingControlShowing(DataGridView dataGridView, DataGridViewEditingControlShowingEventArgs e)
        {
            var comboBox = (e.Control as ComboBox);
            var textBox = (e.Control as TextBox);
            var currentCell = dataGridView.CurrentCell;

            if (textBox != null)
            {
                var list = GetAutoCompleteValues(currentCell.ColumnIndex);

                if (list?.Count > 0)
                {
                    textBox.AutoCompleteMode = AutoCompleteMode.Append;
                    textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    textBox.AutoCompleteCustomSource = list;
                }
                else
                {
                    textBox.AutoCompleteMode = AutoCompleteMode.None;
                }
            }

            if (comboBox != null)
            {
                comboBox.AutoCompleteMode = AutoCompleteMode.Append;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
        protected void OnDataGridFocus(DataGridView dataGridView, bool focusFirstField = false)
        {
            dataGridView.Focus();
            SendKeys.SendWait("{TAB}");

            if (focusFirstField)
            {
                SendKeys.SendWait("{TAB}");
            }
        }

        protected void OntxtBatchId_KeyUp(DataGridView dataGridView, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && !e.Shift)
            {
                OnDataGridFocus(dataGridView);
            }
        }

        protected virtual void CopyOverNewRow(DataGridView dataGridView1)
        {
            dataGridView1.EndEdit();

            var idColumnIndex = 2;
            var billOfLandingColumnIndex = 3;
            var quantityColumnIndex = 9;

            var totalRows = dataGridView1.Rows.Count;
            var lastRowIndex = totalRows - 1;
            var lastValidRowIndex = lastRowIndex - 1;

            if (lastRowIndex < 1 || dataGridView1[idColumnIndex, lastRowIndex].Value != DBNull.Value)
            {
                return;
            }

            var lastId = dataGridView1[idColumnIndex, lastValidRowIndex].Value.ToString();
            DBManager.CopyInProgress = true;
            for (var index = 0; index < dataGridView1.ColumnCount; index++)
            {
                if (index != idColumnIndex && index != billOfLandingColumnIndex)
                {
                    dataGridView1[index, lastRowIndex].Value = dataGridView1[index, lastValidRowIndex].Value;
                }
            }
                var quantityCell = dataGridView1.Rows[lastRowIndex].Cells[quantityColumnIndex];
            var billOfLandingCell = dataGridView1.Rows[lastRowIndex].Cells[billOfLandingColumnIndex];
            quantityCell.Value = 0;
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Display);

            DBManager.CopyInProgress = false;
            OnCellValueChanged(lastValidRowIndex + 1);
            //SAVE Copied Row in one go >>

            Task.Delay(10).ContinueWith(t => RefreshGrid(dataGridView1, billOfLandingCell));
        }

        protected void RefreshGrid(DataGridView dataGridView1, DataGridViewCell currentCell)
        {
            try
            {
                dataGridView1.CurrentCell = currentCell;
                //dataGridView1.BeginEdit(false);
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait("+{TAB}");
                //SendKeys.SendWait("0");
                //SendKeys.SendWait("{BACKSPACE}");
                // Scroll towards the end >>
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
            }
            catch (Exception e)
            {
            }
        }

        protected void OnDataGridViewKeyDown(DataGridView dataGridView1, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.SuppressKeyPress = true;

            int iColumn = dataGridView1.CurrentCell.ColumnIndex;
            int iRow = dataGridView1.CurrentCell.RowIndex;

            if (iColumn == dataGridView1.ColumnCount - 1)
            {
                if (dataGridView1.RowCount > (iRow + 1))
                {
                    var index = 1;

                    var cell = dataGridView1[index, iRow + 1];

                    while (!cell.Visible)
                    {
                        index++;
                        cell = dataGridView1[index, iRow + 1];
                    }

                    if (cell != null && cell.Visible)
                    {
                        dataGridView1.CurrentCell = cell;
                    }
                }
            }
            else
            {
                var cell = dataGridView1[iColumn + 1, iRow];

                if (!cell.Visible)
                {
                    cell = dataGridView1[iColumn + 2, iRow];
                }

                if (cell.Visible)
                {
                    dataGridView1.CurrentCell = cell;
                }
            }
        }
        #endregion
    }
}
