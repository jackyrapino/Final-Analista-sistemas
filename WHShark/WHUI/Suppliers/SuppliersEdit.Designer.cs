using System;
using System.Windows.Forms;
using System.Drawing;

namespace WHUI.Suppliers
{
    partial class SuppliersEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel tlp;
        private Label lblName;
        private TextBox txtName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private FlowLayoutPanel pnlButtons;
        private Button btnOK;
        private Button btnCancel;

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
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tlp.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp
            // 
            this.tlp.ColumnCount = 2;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.Controls.Add(this.lblName, 0, 0);
            this.tlp.Controls.Add(this.txtName, 1, 0);
            this.tlp.Controls.Add(this.lblEmail, 0, 1);
            this.tlp.Controls.Add(this.txtEmail, 1, 1);
            this.tlp.Controls.Add(this.lblPhone, 0, 2);
            this.tlp.Controls.Add(this.txtPhone, 1, 2);
            this.tlp.Controls.Add(this.lblAddress, 0, 3);
            this.tlp.Controls.Add(this.txtAddress, 1, 3);
            this.tlp.Controls.Add(this.pnlButtons, 0, 4);
            this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp.Location = new System.Drawing.Point(0, 0);
            this.tlp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 5;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.Size = new System.Drawing.Size(520, 240);
            this.tlp.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(114, 32);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(123, 2);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(394, 22);
            this.txtName.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.Location = new System.Drawing.Point(3, 32);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(114, 32);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Location = new System.Drawing.Point(123, 34);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(394, 22);
            this.txtEmail.TabIndex = 3;
            // 
            // lblPhone
            // 
            this.lblPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhone.Location = new System.Drawing.Point(3, 64);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(114, 32);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "Phone";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPhone
            // 
            this.txtPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPhone.Location = new System.Drawing.Point(123, 66);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(394, 22);
            this.txtPhone.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddress.Location = new System.Drawing.Point(3, 96);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(114, 96);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Address";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAddress
            // 
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.Location = new System.Drawing.Point(123, 98);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(394, 92);
            this.txtAddress.TabIndex = 7;
            // 
            // pnlButtons
            // 
            this.tlp.SetColumnSpan(this.pnlButtons, 2);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnOK);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlButtons.Location = new System.Drawing.Point(3, 194);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(514, 44);
            this.pnlButtons.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Location = new System.Drawing.Point(436, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.Location = new System.Drawing.Point(355, 2);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 26);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SuppliersEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 240);
            this.Controls.Add(this.tlp);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SuppliersEdit";
            this.Text = "Supplier";
            this.tlp.ResumeLayout(false);
            this.tlp.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}