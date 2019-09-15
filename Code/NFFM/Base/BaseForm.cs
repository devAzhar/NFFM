namespace NFFM.Base
{
    using System;
    using System.Collections.Generic;
    using System.Data;
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
        #endregion
    }
}
