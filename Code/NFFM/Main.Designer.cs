namespace NFFM
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tblCustomersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nFFM_be_sqlDataSet1 = new NFFM.NFFM_be_sqlDataSet1();
            this.tblCustomersTableAdapter = new NFFM.NFFM_be_sqlDataSet1TableAdapters.tblCustomersTableAdapter();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeading = new System.Windows.Forms.Label();
            this.btnSalesCode = new System.Windows.Forms.Button();
            this.btnShipper = new System.Windows.Forms.Button();
            this.btnTrucker = new System.Windows.Forms.Button();
            this.btnBOL = new System.Windows.Forms.Button();
            this.btnBOLReport = new System.Windows.Forms.Button();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFFM_be_sqlDataSet1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tblCustomersBindingSource
            // 
            this.tblCustomersBindingSource.DataMember = "tblCustomers";
            this.tblCustomersBindingSource.DataSource = this.nFFM_be_sqlDataSet1;
            // 
            // nFFM_be_sqlDataSet1
            // 
            this.nFFM_be_sqlDataSet1.DataSetName = "NFFM_be_sqlDataSet1";
            this.nFFM_be_sqlDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblCustomersTableAdapter
            // 
            this.tblCustomersTableAdapter.ClearBeforeFill = true;
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomer.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Location = new System.Drawing.Point(22, 102);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(248, 109);
            this.btnCustomer.TabIndex = 3;
            this.btnCustomer.Text = "&Customers";
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.lblHeading);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 77);
            this.panel1.TabIndex = 18;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.Blue;
            this.lblHeading.Location = new System.Drawing.Point(272, 9);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(275, 41);
            this.lblHeading.TabIndex = 6;
            this.lblHeading.Text = "NFFM Launcher";
            // 
            // btnSalesCode
            // 
            this.btnSalesCode.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSalesCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalesCode.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesCode.ForeColor = System.Drawing.Color.White;
            this.btnSalesCode.Location = new System.Drawing.Point(279, 102);
            this.btnSalesCode.Name = "btnSalesCode";
            this.btnSalesCode.Size = new System.Drawing.Size(248, 109);
            this.btnSalesCode.TabIndex = 20;
            this.btnSalesCode.Text = "&Sales Code";
            this.btnSalesCode.UseVisualStyleBackColor = false;
            this.btnSalesCode.Click += new System.EventHandler(this.btnSalesCode_Click);
            // 
            // btnShipper
            // 
            this.btnShipper.BackColor = System.Drawing.Color.SeaGreen;
            this.btnShipper.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShipper.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShipper.ForeColor = System.Drawing.Color.White;
            this.btnShipper.Location = new System.Drawing.Point(536, 102);
            this.btnShipper.Name = "btnShipper";
            this.btnShipper.Size = new System.Drawing.Size(248, 109);
            this.btnShipper.TabIndex = 21;
            this.btnShipper.Text = "S&hipper";
            this.btnShipper.UseVisualStyleBackColor = false;
            this.btnShipper.Click += new System.EventHandler(this.btnShipper_Click);
            // 
            // btnTrucker
            // 
            this.btnTrucker.BackColor = System.Drawing.Color.SeaGreen;
            this.btnTrucker.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTrucker.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrucker.ForeColor = System.Drawing.Color.White;
            this.btnTrucker.Location = new System.Drawing.Point(22, 228);
            this.btnTrucker.Name = "btnTrucker";
            this.btnTrucker.Size = new System.Drawing.Size(248, 109);
            this.btnTrucker.TabIndex = 22;
            this.btnTrucker.Text = "&Trucker";
            this.btnTrucker.UseVisualStyleBackColor = false;
            this.btnTrucker.Click += new System.EventHandler(this.btnTrucker_Click);
            // 
            // btnBOL
            // 
            this.btnBOL.BackColor = System.Drawing.Color.SeaGreen;
            this.btnBOL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBOL.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBOL.ForeColor = System.Drawing.Color.White;
            this.btnBOL.Location = new System.Drawing.Point(279, 228);
            this.btnBOL.Name = "btnBOL";
            this.btnBOL.Size = new System.Drawing.Size(248, 109);
            this.btnBOL.TabIndex = 23;
            this.btnBOL.Text = "&Receiving Bill of Lading";
            this.btnBOL.UseVisualStyleBackColor = false;
            this.btnBOL.Click += new System.EventHandler(this.btnBOL_Click);
            // 
            // btnBOLReport
            // 
            this.btnBOLReport.BackColor = System.Drawing.Color.SeaGreen;
            this.btnBOLReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBOLReport.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBOLReport.ForeColor = System.Drawing.Color.White;
            this.btnBOLReport.Location = new System.Drawing.Point(536, 228);
            this.btnBOLReport.Name = "btnBOLReport";
            this.btnBOLReport.Size = new System.Drawing.Size(248, 109);
            this.btnBOLReport.TabIndex = 25;
            this.btnBOLReport.Text = "Receiving &Bill of Lading Report";
            this.btnBOLReport.UseVisualStyleBackColor = false;
            this.btnBOLReport.Click += new System.EventHandler(this.btnBOLReport_Click);
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(NFFM.Customers);
            // 
            // Main
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(807, 360);
            this.Controls.Add(this.btnBOLReport);
            this.Controls.Add(this.btnBOL);
            this.Controls.Add(this.btnTrucker);
            this.Controls.Add(this.btnShipper);
            this.Controls.Add(this.btnSalesCode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCustomer);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFFM_be_sqlDataSet1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource form1BindingSource;
        private NFFM_be_sqlDataSet1 nFFM_be_sqlDataSet1;
        private System.Windows.Forms.BindingSource tblCustomersBindingSource;
        private NFFM_be_sqlDataSet1TableAdapters.tblCustomersTableAdapter tblCustomersTableAdapter;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Button btnSalesCode;
        private System.Windows.Forms.Button btnShipper;
        private System.Windows.Forms.Button btnTrucker;
        private System.Windows.Forms.Button btnBOL;
        private System.Windows.Forms.Button btnBOLReport;
    }
}

