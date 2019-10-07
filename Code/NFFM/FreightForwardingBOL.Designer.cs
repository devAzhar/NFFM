using NFFM.Base;

namespace NFFM
{
    partial class FreightForwardingBOL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHeading = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalesCode = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnAddShipper = new System.Windows.Forms.Button();
            this.txtBatchId = new System.Windows.Forms.TextBox();
            this.ddlTruckerName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.datePickerWeekEnding = new System.Windows.Forms.DateTimePicker();
            this.datePickerReceived = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new NFFM.Base.MyDataGridView();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.txtRecords = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTruckingTotal = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.Blue;
            this.lblHeading.Location = new System.Drawing.Point(538, 9);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(508, 28);
            this.lblHeading.TabIndex = 9;
            this.lblHeading.Text = "Freight Forwarding Bill of Lading Entry Form";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1439, 74);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 53);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "&Delete Displayed Bill of Lading";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(1326, 74);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 53);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "&Add a New Bill of Lading";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(628, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 21);
            this.label1.TabIndex = 21;
            this.label1.Text = "Click a heading to sort the data.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.btnSalesCode);
            this.panel1.Controls.Add(this.btnCustomer);
            this.panel1.Controls.Add(this.btnAddShipper);
            this.panel1.Controls.Add(this.txtBatchId);
            this.panel1.Controls.Add(this.ddlTruckerName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.datePickerWeekEnding);
            this.panel1.Controls.Add(this.datePickerReceived);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblHeading);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1596, 140);
            this.panel1.TabIndex = 20;
            // 
            // btnSalesCode
            // 
            this.btnSalesCode.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSalesCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalesCode.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesCode.ForeColor = System.Drawing.Color.White;
            this.btnSalesCode.Location = new System.Drawing.Point(1439, 12);
            this.btnSalesCode.Name = "btnSalesCode";
            this.btnSalesCode.Size = new System.Drawing.Size(130, 53);
            this.btnSalesCode.TabIndex = 32;
            this.btnSalesCode.Text = "Add Sales C&ode";
            this.btnSalesCode.UseVisualStyleBackColor = false;
            this.btnSalesCode.Click += new System.EventHandler(this.btnSalesCode_click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomer.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Location = new System.Drawing.Point(1209, 12);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(111, 53);
            this.btnCustomer.TabIndex = 31;
            this.btnCustomer.Text = "Add &Customer";
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_click);
            // 
            // btnAddShipper
            // 
            this.btnAddShipper.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddShipper.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddShipper.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddShipper.ForeColor = System.Drawing.Color.White;
            this.btnAddShipper.Location = new System.Drawing.Point(1326, 12);
            this.btnAddShipper.Name = "btnAddShipper";
            this.btnAddShipper.Size = new System.Drawing.Size(107, 53);
            this.btnAddShipper.TabIndex = 30;
            this.btnAddShipper.Text = "Add &Shipper";
            this.btnAddShipper.UseVisualStyleBackColor = false;
            this.btnAddShipper.Click += new System.EventHandler(this.btnAddShipper_Click);
            // 
            // txtBatchId
            // 
            this.txtBatchId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchId.Location = new System.Drawing.Point(877, 92);
            this.txtBatchId.Name = "txtBatchId";
            this.txtBatchId.Size = new System.Drawing.Size(207, 29);
            this.txtBatchId.TabIndex = 29;
            this.txtBatchId.Leave += new System.EventHandler(this.txtBatchId_Leave);
            // 
            // ddlTruckerName
            // 
            this.ddlTruckerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlTruckerName.FormattingEnabled = true;
            this.ddlTruckerName.Location = new System.Drawing.Point(877, 56);
            this.ddlTruckerName.Name = "ddlTruckerName";
            this.ddlTruckerName.Size = new System.Drawing.Size(207, 32);
            this.ddlTruckerName.TabIndex = 28;
            this.ddlTruckerName.SelectedIndexChanged += new System.EventHandler(this.ddlTruckerName_SelectedIndexChanged);
            this.ddlTruckerName.Enter += new System.EventHandler(this.comboBoxGeneral_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(717, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 24);
            this.label5.TabIndex = 27;
            this.label5.Text = "&Batch ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(717, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 24);
            this.label4.TabIndex = 26;
            this.label4.Text = "Trucker &Name:";
            // 
            // datePickerWeekEnding
            // 
            this.datePickerWeekEnding.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerWeekEnding.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerWeekEnding.Location = new System.Drawing.Point(457, 90);
            this.datePickerWeekEnding.Name = "datePickerWeekEnding";
            this.datePickerWeekEnding.Size = new System.Drawing.Size(148, 31);
            this.datePickerWeekEnding.TabIndex = 25;
            this.datePickerWeekEnding.Leave += new System.EventHandler(this.datePickerWeekEnding_Leave);
            // 
            // datePickerReceived
            // 
            this.datePickerReceived.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerReceived.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerReceived.Location = new System.Drawing.Point(457, 57);
            this.datePickerReceived.Name = "datePickerReceived";
            this.datePickerReceived.Size = new System.Drawing.Size(148, 31);
            this.datePickerReceived.TabIndex = 24;
            this.datePickerReceived.ValueChanged += new System.EventHandler(this.datePickerReceived_ValueChanged);
            this.datePickerReceived.Leave += new System.EventHandler(this.datePickerReceived_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(247, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 24);
            this.label3.TabIndex = 23;
            this.label3.Text = "&Week Ending Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(247, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 24);
            this.label2.TabIndex = 22;
            this.label2.Text = "Shipped &Date:";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(29, 168);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 45;
            this.dataGridView1.Size = new System.Drawing.Size(1542, 604);
            this.dataGridView1.TabIndex = 22;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // Action
            // 
            this.Action.HeaderText = "";
            this.Action.Name = "Action";
            this.Action.Text = "X";
            this.Action.ToolTipText = "Delete Line Item";
            this.Action.UseColumnTextForButtonValue = true;
            this.Action.Width = 30;
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(26, 778);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(32, 33);
            this.btnFirst.TabIndex = 23;
            this.btnFirst.Text = "|<";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(64, 778);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(26, 33);
            this.btnPrevious.TabIndex = 24;
            this.btnPrevious.Text = "&<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(515, 778);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(28, 33);
            this.btnNext.TabIndex = 25;
            this.btnNext.Text = "&>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(549, 778);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(33, 33);
            this.btnLast.TabIndex = 26;
            this.btnLast.Text = ">|";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // txtRecords
            // 
            this.txtRecords.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecords.Location = new System.Drawing.Point(96, 778);
            this.txtRecords.Name = "txtRecords";
            this.txtRecords.Size = new System.Drawing.Size(413, 33);
            this.txtRecords.TabIndex = 30;
            this.txtRecords.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(1262, 781);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 24);
            this.label6.TabIndex = 30;
            this.label6.Text = "Trucking Total:";
            // 
            // txtTruckingTotal
            // 
            this.txtTruckingTotal.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTruckingTotal.Location = new System.Drawing.Point(1435, 778);
            this.txtTruckingTotal.Name = "txtTruckingTotal";
            this.txtTruckingTotal.ReadOnly = true;
            this.txtTruckingTotal.Size = new System.Drawing.Size(136, 33);
            this.txtTruckingTotal.TabIndex = 31;
            this.txtTruckingTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FreightForwardingBOL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1596, 824);
            this.Controls.Add(this.txtTruckingTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRecords);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "FreightForwardingBOL";
            this.Text = "BillOfLading";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Activated);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datePickerReceived;
        private System.Windows.Forms.DateTimePicker datePickerWeekEnding;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBatchId;
        private System.Windows.Forms.ComboBox ddlTruckerName;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.TextBox txtRecords;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTruckingTotal;
        private System.Windows.Forms.Button btnAddShipper;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnSalesCode;
        private MyDataGridView dataGridView1;
    }
}