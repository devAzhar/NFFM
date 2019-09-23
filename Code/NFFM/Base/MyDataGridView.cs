namespace NFFM.Base
{
    using System.Windows.Forms;

    class MyDataGridView : DataGridView
    {
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {

            if ((keyData == (Keys.Enter)))
            {
                SendKeys.Send("{TAB}");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

}
