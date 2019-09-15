namespace NFFM.Base
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;

    public abstract class BaseForm : Form
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
        protected virtual void comboBoxGeneral_Enter(object sender, EventArgs e)
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
        protected abstract ComboBox ComboBoxTruckerName { get; }
        protected abstract void LoadData(int id);
        protected abstract void BindLineItems(DataTable dtLineItems);
        protected abstract void RecalculateTotals();
        protected abstract void HandleCellEvent(object sender, DataGridViewCellEventArgs e, bool isClick = false);
        #endregion

        #region "Protected Methods"
        protected void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.HandleCellEvent(sender, e);
        }

        protected void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleCellEvent(sender, e, true);
        }

        protected void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        protected void Form1_Activated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DBManager.NewTruckerId))
            {
                var data = DBManager.GetDataTable("Truckers_GetAll");
                this.LoadTruckers(this.ComboBoxTruckerName, data, DBManager.NewTruckerId);
                DBManager.NewTruckerId = string.Empty;
                return;
            }

            if (DBManager.isDataLoaded == false)
            {
                this.LoadData(0);
                this.InitialDataLoaded = 1;
            }
        }
        #endregion
    }
}
