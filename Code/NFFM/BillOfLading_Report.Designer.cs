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
            this.rbtReceivedAll = new System.Windows.Forms.RadioButton();
            this.ddlReceived = new System.Windows.Forms.ComboBox();
            this.rbtReceived = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ddlBillOfLading = new System.Windows.Forms.ComboBox();
            this.rbtBillOfLadingAll = new System.Windows.Forms.RadioButton();
            this.rbtBillOfLading = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ddlInvoice = new System.Windows.Forms.ComboBox();
            this.rbtInvoiceAll = new System.Windows.Forms.RadioButton();
            this.rbtInvoice = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ddlBatch = new System.Windows.Forms.ComboBox();
            this.rbtBatchAll = new System.Windows.Forms.RadioButton();
            this.rbtBatch = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTruckingTotal = new System.Windows.Forms.TextBox();
            this.BOL_PrintPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.BOL_Print = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(589, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 21);
            this.label1.TabIndex = 21;
            this.label1.Text = "Click a heading to sort the data.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblHeading);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1604, 151);
            this.panel1.TabIndex = 20;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ddlCustomer);
            this.groupBox5.Controls.Add(this.rbtCustomer);
            this.groupBox5.Controls.Add(this.rbtCustomerAll);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(1099, 49);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 90);
            this.groupBox5.TabIndex = 44;
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
            this.ddlCustomer.SelectedIndexChanged += new System.EventHandler(this.ddlCustomer_SelectedIndexChanged);
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
            this.rbtCustomer.Click += new System.EventHandler(this.rbtCustomer_Click);
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
            this.rbtCustomerAll.Click += new System.EventHandler(this.rbtCustomerAll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtReceivedAll);
            this.groupBox1.Controls.Add(this.ddlReceived);
            this.groupBox1.Controls.Add(this.rbtReceived);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(219, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 91);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Received Date";
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
            this.rbtReceivedAll.Click += new System.EventHandler(this.rbtReceivedAll_Click);
            // 
            // ddlReceived
            // 
            this.ddlReceived.FormattingEnabled = true;
            this.ddlReceived.Location = new System.Drawing.Point(24, 57);
            this.ddlReceived.Name = "ddlReceived";
            this.ddlReceived.Size = new System.Drawing.Size(161, 28);
            this.ddlReceived.TabIndex = 31;
            this.ddlReceived.SelectedIndexChanged += new System.EventHandler(this.ddlReceived_SelectedIndexChanged);
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
            this.rbtReceived.Click += new System.EventHandler(this.rbtReceived_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ddlBillOfLading);
            this.groupBox4.Controls.Add(this.rbtBillOfLadingAll);
            this.groupBox4.Controls.Add(this.rbtBillOfLading);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(875, 49);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 90);
            this.groupBox4.TabIndex = 44;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bills of Lading";
            // 
            // ddlBillOfLading
            // 
            this.ddlBillOfLading.FormattingEnabled = true;
            this.ddlBillOfLading.Location = new System.Drawing.Point(35, 56);
            this.ddlBillOfLading.Name = "ddlBillOfLading";
            this.ddlBillOfLading.Size = new System.Drawing.Size(159, 28);
            this.ddlBillOfLading.TabIndex = 34;
            this.ddlBillOfLading.SelectedIndexChanged += new System.EventHandler(this.ddlBillOfLading_SelectedIndexChanged);
            // 
            // rbtBillOfLadingAll
            // 
            this.rbtBillOfLadingAll.AutoSize = true;
            this.rbtBillOfLadingAll.Location = new System.Drawing.Point(17, 29);
            this.rbtBillOfLadingAll.Name = "rbtBillOfLadingAll";
            this.rbtBillOfLadingAll.Size = new System.Drawing.Size(44, 24);
            this.rbtBillOfLadingAll.TabIndex = 39;
            this.rbtBillOfLadingAll.TabStop = true;
            this.rbtBillOfLadingAll.Text = "All";
            this.rbtBillOfLadingAll.UseVisualStyleBackColor = true;
            this.rbtBillOfLadingAll.Click += new System.EventHandler(this.rbtBillOfLadingAll_Click);
            // 
            // rbtBillOfLading
            // 
            this.rbtBillOfLading.AutoSize = true;
            this.rbtBillOfLading.Location = new System.Drawing.Point(15, 63);
            this.rbtBillOfLading.Name = "rbtBillOfLading";
            this.rbtBillOfLading.Size = new System.Drawing.Size(14, 13);
            this.rbtBillOfLading.TabIndex = 45;
            this.rbtBillOfLading.TabStop = true;
            this.rbtBillOfLading.UseVisualStyleBackColor = true;
            this.rbtBillOfLading.Click += new System.EventHandler(this.rbtBillOfLading_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(1108, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.TabIndex = 30;
            this.label7.Text = "Customers";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ddlInvoice);
            this.groupBox3.Controls.Add(this.rbtInvoiceAll);
            this.groupBox3.Controls.Add(this.rbtInvoice);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(653, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 90);
            this.groupBox3.TabIndex = 44;
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
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(895, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Bills of Lading";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ddlBatch);
            this.groupBox2.Controls.Add(this.rbtBatchAll);
            this.groupBox2.Controls.Add(this.rbtBatch);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(434, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 90);
            this.groupBox2.TabIndex = 43;
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
            this.ddlBatch.SelectedIndexChanged += new System.EventHandler(this.ddlBatch_SelectedIndexChanged);
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
            this.rbtBatchAll.Click += new System.EventHandler(this.rbtBatchAll_Click);
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
            this.rbtBatch.Click += new System.EventHandler(this.rbtBatch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(684, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Invoice Numbers";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(468, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Batch ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(249, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Received Date";
            // 
            // dataGridView1
            // 
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
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(29, 178);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.Size = new System.Drawing.Size(1552, 561);
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
            // txtTruckingTotal
            // 
            this.txtTruckingTotal.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTruckingTotal.Location = new System.Drawing.Point(1444, 758);
            this.txtTruckingTotal.Name = "txtTruckingTotal";
            this.txtTruckingTotal.ReadOnly = true;
            this.txtTruckingTotal.Size = new System.Drawing.Size(137, 31);
            this.txtTruckingTotal.TabIndex = 31;
            this.txtTruckingTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // BillOfLading_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1604, 800);
            this.Controls.Add(this.txtTruckingTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
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
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTruckingTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlCustomer;
        private System.Windows.Forms.ComboBox ddlBillOfLading;
        private System.Windows.Forms.ComboBox ddlInvoice;
        private System.Windows.Forms.ComboBox ddlBatch;
        private System.Windows.Forms.ComboBox ddlReceived;
        private System.Windows.Forms.RadioButton rbtCustomerAll;
        private System.Windows.Forms.RadioButton rbtBillOfLadingAll;
        private System.Windows.Forms.RadioButton rbtInvoiceAll;
        private System.Windows.Forms.RadioButton rbtBatchAll;
        private System.Windows.Forms.RadioButton rbtCustomer;
        private System.Windows.Forms.RadioButton rbtBillOfLading;
        private System.Windows.Forms.RadioButton rbtInvoice;
        private System.Windows.Forms.RadioButton rbtBatch;
        private System.Windows.Forms.RadioButton rbtReceived;
        private System.Windows.Forms.RadioButton rbtReceivedAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PrintPreviewDialog BOL_PrintPreviewDialog;
        private System.Drawing.Printing.PrintDocument BOL_Print;
    }
}