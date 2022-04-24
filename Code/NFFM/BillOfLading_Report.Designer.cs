namespace NFFM
{
    partial class BillOfLading_Report
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillOfLading_Report));
            this.lblHeading = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ddlCustomer = new System.Windows.Forms.ComboBox();
            this.rbtCustomer = new System.Windows.Forms.RadioButton();
            this.rbtCustomerAll = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.rbtReceivedAll = new System.Windows.Forms.RadioButton();
            this.rbtReceived = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ddlInvoice = new System.Windows.Forms.ComboBox();
            this.rbtInvoiceAll = new System.Windows.Forms.RadioButton();
            this.rbtInvoice = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ddlBatch = new System.Windows.Forms.ComboBox();
            this.rbtBatchAll = new System.Windows.Forms.RadioButton();
            this.rbtBatch = new System.Windows.Forms.RadioButton();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnCreateReport = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.BOL_PrintPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.BOL_Print = new System.Drawing.Printing.PrintDocument();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.Blue;
            this.lblHeading.Location = new System.Drawing.Point(596, 9);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(479, 28);
            this.lblHeading.TabIndex = 9;
            this.lblHeading.Text = "Receiving Bill of Lading Summary Report";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(703, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 21);
            this.label1.TabIndex = 21;
            this.label1.Text = "Click a heading to sort the data.";
            this.label1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btnGenerateReport);
            this.panel1.Controls.Add(this.btnCreateReport);
            this.panel1.Controls.Add(this.lblHeading);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1727, 151);
            this.panel1.TabIndex = 20;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ddlCustomer);
            this.groupBox5.Controls.Add(this.rbtCustomer);
            this.groupBox5.Controls.Add(this.rbtCustomerAll);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(1082, 41);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 90);
            this.groupBox5.TabIndex = 63;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Customer";
            // 
            // ddlCustomer
            // 
            this.ddlCustomer.FormattingEnabled = true;
            this.ddlCustomer.Location = new System.Drawing.Point(26, 53);
            this.ddlCustomer.Name = "ddlCustomer";
            this.ddlCustomer.Size = new System.Drawing.Size(158, 28);
            this.ddlCustomer.TabIndex = 35;
            // 
            // rbtCustomer
            // 
            this.rbtCustomer.AutoSize = true;
            this.rbtCustomer.Location = new System.Drawing.Point(6, 60);
            this.rbtCustomer.Name = "rbtCustomer";
            this.rbtCustomer.Size = new System.Drawing.Size(14, 13);
            this.rbtCustomer.TabIndex = 46;
            this.rbtCustomer.TabStop = true;
            this.rbtCustomer.UseVisualStyleBackColor = true;
            this.rbtCustomer.CheckedChanged += new System.EventHandler(this.rbtCustomerAll_CheckedChanged);
            // 
            // rbtCustomerAll
            // 
            this.rbtCustomerAll.AutoSize = true;
            this.rbtCustomerAll.Location = new System.Drawing.Point(6, 29);
            this.rbtCustomerAll.Name = "rbtCustomerAll";
            this.rbtCustomerAll.Size = new System.Drawing.Size(44, 24);
            this.rbtCustomerAll.TabIndex = 40;
            this.rbtCustomerAll.TabStop = true;
            this.rbtCustomerAll.Text = "All";
            this.rbtCustomerAll.UseVisualStyleBackColor = true;
            this.rbtCustomerAll.CheckedChanged += new System.EventHandler(this.rbtCustomerAll_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtReceivedDate);
            this.groupBox1.Controls.Add(this.rbtReceivedAll);
            this.groupBox1.Controls.Add(this.rbtReceived);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(374, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 90);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Received Date";
            // 
            // dtReceivedDate
            // 
            this.dtReceivedDate.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.dtReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtReceivedDate.Location = new System.Drawing.Point(26, 53);
            this.dtReceivedDate.Name = "dtReceivedDate";
            this.dtReceivedDate.Size = new System.Drawing.Size(157, 31);
            this.dtReceivedDate.TabIndex = 66;
            // 
            // rbtReceivedAll
            // 
            this.rbtReceivedAll.AutoSize = true;
            this.rbtReceivedAll.Location = new System.Drawing.Point(6, 30);
            this.rbtReceivedAll.Name = "rbtReceivedAll";
            this.rbtReceivedAll.Size = new System.Drawing.Size(44, 24);
            this.rbtReceivedAll.TabIndex = 36;
            this.rbtReceivedAll.TabStop = true;
            this.rbtReceivedAll.Text = "All";
            this.rbtReceivedAll.UseVisualStyleBackColor = true;
            this.rbtReceivedAll.CheckedChanged += new System.EventHandler(this.rbtReceivedAll_CheckedChanged);
            // 
            // rbtReceived
            // 
            this.rbtReceived.AutoSize = true;
            this.rbtReceived.Location = new System.Drawing.Point(6, 64);
            this.rbtReceived.Name = "rbtReceived";
            this.rbtReceived.Size = new System.Drawing.Size(14, 13);
            this.rbtReceived.TabIndex = 42;
            this.rbtReceived.TabStop = true;
            this.rbtReceived.UseVisualStyleBackColor = true;
            this.rbtReceived.CheckedChanged += new System.EventHandler(this.rbtReceivedAll_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ddlInvoice);
            this.groupBox3.Controls.Add(this.rbtInvoiceAll);
            this.groupBox3.Controls.Add(this.rbtInvoice);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(846, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 90);
            this.groupBox3.TabIndex = 64;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Invoice Numbers";
            // 
            // ddlInvoice
            // 
            this.ddlInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlInvoice.FormattingEnabled = true;
            this.ddlInvoice.Location = new System.Drawing.Point(33, 56);
            this.ddlInvoice.Name = "ddlInvoice";
            this.ddlInvoice.Size = new System.Drawing.Size(154, 24);
            this.ddlInvoice.TabIndex = 33;
            // 
            // rbtInvoiceAll
            // 
            this.rbtInvoiceAll.AutoSize = true;
            this.rbtInvoiceAll.Location = new System.Drawing.Point(14, 24);
            this.rbtInvoiceAll.Name = "rbtInvoiceAll";
            this.rbtInvoiceAll.Size = new System.Drawing.Size(44, 24);
            this.rbtInvoiceAll.TabIndex = 38;
            this.rbtInvoiceAll.TabStop = true;
            this.rbtInvoiceAll.Text = "All";
            this.rbtInvoiceAll.UseVisualStyleBackColor = true;
            this.rbtInvoiceAll.CheckedChanged += new System.EventHandler(this.rbtInvoiceAll_CheckedChanged);
            // 
            // rbtInvoice
            // 
            this.rbtInvoice.AutoSize = true;
            this.rbtInvoice.Location = new System.Drawing.Point(13, 63);
            this.rbtInvoice.Name = "rbtInvoice";
            this.rbtInvoice.Size = new System.Drawing.Size(14, 13);
            this.rbtInvoice.TabIndex = 44;
            this.rbtInvoice.TabStop = true;
            this.rbtInvoice.UseVisualStyleBackColor = true;
            this.rbtInvoice.CheckedChanged += new System.EventHandler(this.rbtInvoiceAll_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ddlBatch);
            this.groupBox2.Controls.Add(this.rbtBatchAll);
            this.groupBox2.Controls.Add(this.rbtBatch);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(610, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 90);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Batch ID";
            // 
            // ddlBatch
            // 
            this.ddlBatch.FormattingEnabled = true;
            this.ddlBatch.Location = new System.Drawing.Point(27, 56);
            this.ddlBatch.Name = "ddlBatch";
            this.ddlBatch.Size = new System.Drawing.Size(157, 28);
            this.ddlBatch.TabIndex = 32;
            // 
            // rbtBatchAll
            // 
            this.rbtBatchAll.AutoSize = true;
            this.rbtBatchAll.Location = new System.Drawing.Point(7, 29);
            this.rbtBatchAll.Name = "rbtBatchAll";
            this.rbtBatchAll.Size = new System.Drawing.Size(44, 24);
            this.rbtBatchAll.TabIndex = 37;
            this.rbtBatchAll.TabStop = true;
            this.rbtBatchAll.Text = "All";
            this.rbtBatchAll.UseVisualStyleBackColor = true;
            this.rbtBatchAll.CheckedChanged += new System.EventHandler(this.rbtBatchAll_CheckedChanged);
            // 
            // rbtBatch
            // 
            this.rbtBatch.AutoSize = true;
            this.rbtBatch.Location = new System.Drawing.Point(7, 63);
            this.rbtBatch.Name = "rbtBatch";
            this.rbtBatch.Size = new System.Drawing.Size(14, 13);
            this.rbtBatch.TabIndex = 43;
            this.rbtBatch.TabStop = true;
            this.rbtBatch.UseVisualStyleBackColor = true;
            this.rbtBatch.CheckedChanged += new System.EventHandler(this.rbtBatchAll_CheckedChanged);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerateReport.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Location = new System.Drawing.Point(1312, 36);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(154, 43);
            this.btnGenerateReport.TabIndex = 42;
            this.btnGenerateReport.Text = "Generate &Report";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // btnCreateReport
            // 
            this.btnCreateReport.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCreateReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateReport.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateReport.ForeColor = System.Drawing.Color.White;
            this.btnCreateReport.Location = new System.Drawing.Point(1312, 85);
            this.btnCreateReport.Name = "btnCreateReport";
            this.btnCreateReport.Size = new System.Drawing.Size(154, 43);
            this.btnCreateReport.TabIndex = 33;
            this.btnCreateReport.Text = "&Export Data";
            this.btnCreateReport.UseVisualStyleBackColor = false;
            this.btnCreateReport.Click += new System.EventHandler(this.btnCreateReport_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeight = 35;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(10, 178);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 20;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.Size = new System.Drawing.Size(1707, 661);
            this.dataGridView1.TabIndex = 22;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(1092, 593);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 16);
            this.label6.TabIndex = 30;
            // 
            // BOL_PrintPreviewDialog
            // 
            this.BOL_PrintPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.BOL_PrintPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.BOL_PrintPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.BOL_PrintPreviewDialog.Enabled = true;
            this.BOL_PrintPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("BOL_PrintPreviewDialog.Icon")));
            this.BOL_PrintPreviewDialog.Name = "BOL_PrintPreviewDialog";
            this.BOL_PrintPreviewDialog.Visible = false;
            // 
            // BOL_Print
            // 
            this.BOL_Print.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.BOL_Print_PrintPage);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(763, 850);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(40, 23);
            this.btnPrevious.TabIndex = 31;
            this.btnPrevious.Text = "<<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(922, 850);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 23);
            this.btnNext.TabIndex = 32;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Location = new System.Drawing.Point(825, 855);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(78, 13);
            this.lblPageSize.TabIndex = 33;
            this.lblPageSize.Text = "Page {0} of {1}";
            this.lblPageSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(735, 196);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            // 
            // BillOfLading_Report
            // 
            this.AcceptButton = this.btnGenerateReport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1727, 883);
            this.Controls.Add(this.lblPageSize);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "BillOfLading_Report";
            this.Text = "BillOfLading_Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PrintPreviewDialog BOL_PrintPreviewDialog;
        private System.Drawing.Printing.PrintDocument BOL_Print;
        private System.Windows.Forms.Button btnCreateReport;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtReceivedAll;
        private System.Windows.Forms.RadioButton rbtReceived;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox ddlInvoice;
        private System.Windows.Forms.RadioButton rbtInvoiceAll;
        private System.Windows.Forms.RadioButton rbtInvoice;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox ddlBatch;
        private System.Windows.Forms.RadioButton rbtBatchAll;
        private System.Windows.Forms.RadioButton rbtBatch;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox ddlCustomer;
        private System.Windows.Forms.RadioButton rbtCustomer;
        private System.Windows.Forms.RadioButton rbtCustomerAll;
        private System.Windows.Forms.DateTimePicker dtReceivedDate;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}