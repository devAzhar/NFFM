namespace NFFM
{
    partial class Customers_AddUpdate
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
            this.lblAddUpdate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustNo = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAddUpdate
            // 
            this.lblAddUpdate.AutoSize = true;
            this.lblAddUpdate.Location = new System.Drawing.Point(145, 49);
            this.lblAddUpdate.Name = "lblAddUpdate";
            this.lblAddUpdate.Size = new System.Drawing.Size(73, 13);
            this.lblAddUpdate.TabIndex = 0;
            this.lblAddUpdate.Text = "Add Customer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "&Customer No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "&Name";
            // 
            // txtCustNo
            // 
            this.txtCustNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCustNo.Location = new System.Drawing.Point(195, 94);
            this.txtCustNo.MinimumSize = new System.Drawing.Size(170, 30);
            this.txtCustNo.Name = "txtCustNo";
            this.txtCustNo.Size = new System.Drawing.Size(170, 26);
            this.txtCustNo.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtName.Location = new System.Drawing.Point(195, 143);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(170, 26);
            this.txtName.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DimGray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(285, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 31);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.Blue;
            this.lblHeading.Location = new System.Drawing.Point(104, 9);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(261, 25);
            this.lblHeading.TabIndex = 6;
            this.lblHeading.Text = "Customers Update Form ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.lblHeading);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 62);
            this.panel1.TabIndex = 19;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(195, 195);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 31);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Customers_AddUpdate
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(405, 253);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCustNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAddUpdate);
            this.Name = "Customers_AddUpdate";
            this.Text = "AddCustomerForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label lblAddUpdate;
        public System.Windows.Forms.TextBox txtCustNo;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnAdd;
    }
}