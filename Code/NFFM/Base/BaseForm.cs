﻿namespace NFFM.Base
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class BaseForm : Form
    {
        #region "Protected Members"
        protected bool FormInitialized = false;
        protected bool HandleCellEventFlag = false;
        protected int InitialDataLoaded = 0;
        protected int IsNewRecord = 0;
        protected Dictionary<string, string> ddlCustomers = new Dictionary<string, string>();
        protected Dictionary<string, string> ddlShippers = new Dictionary<string, string>();
        protected Dictionary<string, string> ddlSalesCode = new Dictionary<string, string>();
        protected Dictionary<string, string> items = new Dictionary<string, string>();
        protected DataTable dtCustomers;
        protected DataTable dtShippers;
        protected DataTable dtSalesCode;
        #endregion

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
            this.FormInitialized = false;

            if (dtTruckers.Rows.Count > 0)
            {
                items.Clear();

                items.Add("-1", "<<Add New Trucker>>");

                for (int i = 0; i < dtTruckers.Rows.Count; i++)
                {
                    items.Add(dtTruckers.Rows[i]["truckerID"].ToString(), dtTruckers.Rows[i]["Trucker"].ToString());
                }

                ddlTruckerName.DataSource = new BindingSource(items, null);
                ddlTruckerName.DisplayMember = "Value";
                ddlTruckerName.ValueMember = "Key";

                if (!string.IsNullOrEmpty(selectedValue))
                {
                    ddlTruckerName.SelectedValue = selectedValue;
                }

                this.FormInitialized = true;
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
        protected virtual void CopyOverNewRow(DataGridView dataGridView1)
        {
            dataGridView1.EndEdit();

            var idColumnIndex = 2;
            var totalRows = dataGridView1.Rows.Count;
            var lastRowIndex = totalRows - 1;
            var lastValidRowIndex = lastRowIndex - 1;

            if (lastRowIndex < 1 || dataGridView1[idColumnIndex, lastRowIndex].Value != DBNull.Value)
            {
                return;
            }

            var lastId = dataGridView1[idColumnIndex, lastValidRowIndex].Value.ToString();

            for (var index = 0; index < dataGridView1.ColumnCount; index++)
            {
                if (index != idColumnIndex)
                {
                    dataGridView1[index, lastRowIndex].Value = dataGridView1[index, lastValidRowIndex].Value;
                }
            }
            var quantityCell = dataGridView1.Rows[lastRowIndex].Cells[9];
            quantityCell.Value = 0;
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Display);

            Task.Delay(100).ContinueWith(t => RefreshGrid(dataGridView1, quantityCell));
        }

        protected void RefreshGrid(DataGridView dataGridView1, DataGridViewCell quantityCell)
        {
            dataGridView1.CurrentCell = quantityCell;
            dataGridView1.BeginEdit(false);
            SendKeys.SendWait("{TAB}");
            SendKeys.SendWait("+{TAB}");
            SendKeys.SendWait("0");
            SendKeys.SendWait("{BACKSPACE}");
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