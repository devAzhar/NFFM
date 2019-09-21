namespace NFFM
{
    partial class SalesCode_AddUpdate
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
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSalesCode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtUOM = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtFFTier1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFFTier2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFFTier3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
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
            this.label2.Location = new System.Drawing.Point(68, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "&Sales Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(68, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "&Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "&Unit of Measure";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(68, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "&Price";
            // 
            // txtSalesCode
            // 
            this.txtSalesCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesCode.Location = new System.Drawing.Point(195, 89);
            this.txtSalesCode.MaxLength = 1;
            this.txtSalesCode.MinimumSize = new System.Drawing.Size(170, 30);
            this.txtSalesCode.Name = "txtSalesCode";
            this.txtSalesCode.Size = new System.Drawing.Size(170, 26);
            this.txtSalesCode.TabIndex = 6;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(195, 139);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(170, 26);
            this.txtDescription.TabIndex = 7;
            // 
            // txtUOM
            // 
            this.txtUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUOM.Location = new System.Drawing.Point(195, 183);
            this.txtUOM.Name = "txtUOM";
            this.txtUOM.Size = new System.Drawing.Size(170, 26);
            this.txtUOM.TabIndex = 8;
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(195, 227);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(170, 26);
            this.txtPrice.TabIndex = 10;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DimGray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(284, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 33);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "&Cancel";
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
            this.lblHeading.Size = new System.Drawing.Size(278, 25);
            this.lblHeading.TabIndex = 6;
            this.lblHeading.Text = "Sales Codes Update Form ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.lblHeading);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 62);
            this.panel1.TabIndex = 19;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(195, 390);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 33);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtFFTier1
            // 
            this.txtFFTier1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFFTier1.Location = new System.Drawing.Point(195, 271);
            this.txtFFTier1.Name = "txtFFTier1";
            this.txtFFTier1.Size = new System.Drawing.Size(170, 26);
            this.txtFFTier1.TabIndex = 22;
            this.txtFFTier1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFFtier_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 18);
            this.label1.TabIndex = 21;
            this.label1.Text = "FF Tier &1";
            // 
            // txtFFTier2
            // 
            this.txtFFTier2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFFTier2.Location = new System.Drawing.Point(195, 314);
            this.txtFFTier2.Name = "txtFFTier2";
            this.txtFFTier2.Size = new System.Drawing.Size(170, 26);
            this.txtFFTier2.TabIndex = 24;
            this.txtFFTier2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFFtier_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 18);
            this.label5.TabIndex = 23;
            this.label5.Text = "FF Tier &2";
            // 
            // txtFFTier3
            // 
            this.txtFFTier3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFFTier3.Location = new System.Drawing.Point(195, 358);
            this.txtFFTier3.Name = "txtFFTier3";
            this.txtFFTier3.Size = new System.Drawing.Size(170, 26);
            this.txtFFTier3.TabIndex = 26;
            this.txtFFTier3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFFtier_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(68, 366);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 18);
            this.label7.TabIndex = 25;
            this.label7.Text = "FF Tier &3";
            // 
            // SalesCode_AddUpdate
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(495, 452);
            this.Controls.Add(this.txtFFTier3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFFTier2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFFTier1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtUOM);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtSalesCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAddUpdate);
            this.Name = "SalesCode_AddUpdate";
            this.Text = "AddCustomerForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label lblAddUpdate;
        public System.Windows.Forms.TextBox txtSalesCode;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.TextBox txtUOM;
        public System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.TextBox txtFFTier1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtFFTier2;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtFFTier3;
        private System.Windows.Forms.Label label7;
    }
}