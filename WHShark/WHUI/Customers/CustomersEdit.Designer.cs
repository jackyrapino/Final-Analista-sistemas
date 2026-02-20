using System;
using System.Drawing;
using System.Windows.Forms;

namespace WHUI.Customers
{
    partial class CustomersEdit
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

        private void InitializeComponent()
        {
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.lblFirst = new System.Windows.Forms.Label();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.lblLast = new System.Windows.Forms.Label();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
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
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.Controls.Add(this.lblFirst, 0, 0);
            this.tlp.Controls.Add(this.txtFirst, 1, 0);
            this.tlp.Controls.Add(this.lblLast, 0, 1);
            this.tlp.Controls.Add(this.txtLast, 1, 1);
            this.tlp.Controls.Add(this.lblEmail, 0, 2);
            this.tlp.Controls.Add(this.txtEmail, 1, 2);
            this.tlp.Controls.Add(this.lblPhone, 0, 3);
            this.tlp.Controls.Add(this.txtPhone, 1, 3);
            this.tlp.Controls.Add(this.lblBirthday, 0, 4);
            this.tlp.Controls.Add(this.dtpBirthday, 1, 4);
            this.tlp.Controls.Add(this.lblAddress, 0, 5);
            this.tlp.Controls.Add(this.txtAddress, 1, 5);
            this.tlp.Controls.Add(this.pnlButtons, 0, 6);
            this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp.Location = new System.Drawing.Point(0, 0);
            this.tlp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 7;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.Size = new System.Drawing.Size(560, 320);
            this.tlp.TabIndex = 0;
            // 
            // lblFirst
            // 
            this.lblFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFirst.Location = new System.Drawing.Point(3, 0);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(134, 32);
            this.lblFirst.TabIndex = 0;
            this.lblFirst.Text = "First Name";
            this.lblFirst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFirst
            // 
            this.txtFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFirst.Location = new System.Drawing.Point(143, 2);
            this.txtFirst.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(414, 22);
            this.txtFirst.TabIndex = 1;
            // 
            // lblLast
            // 
            this.lblLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLast.Location = new System.Drawing.Point(3, 32);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(134, 32);
            this.lblLast.TabIndex = 2;
            this.lblLast.Text = "Last Name";
            this.lblLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLast
            // 
            this.txtLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLast.Location = new System.Drawing.Point(143, 34);
            this.txtLast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLast.Name = "txtLast";
            this.txtLast.Size = new System.Drawing.Size(414, 22);
            this.txtLast.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.Location = new System.Drawing.Point(3, 64);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(134, 32);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Location = new System.Drawing.Point(143, 66);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(414, 22);
            this.txtEmail.TabIndex = 5;
            // 
            // lblPhone
            // 
            this.lblPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhone.Location = new System.Drawing.Point(3, 96);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(134, 32);
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Text = "Phone";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPhone
            // 
            this.txtPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPhone.Location = new System.Drawing.Point(143, 98);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(414, 22);
            this.txtPhone.TabIndex = 7;
            // 
            // lblBirthday
            // 
            this.lblBirthday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBirthday.Location = new System.Drawing.Point(3, 128);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(134, 32);
            this.lblBirthday.TabIndex = 8;
            this.lblBirthday.Text = "Birthday";
            this.lblBirthday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthday.Location = new System.Drawing.Point(143, 130);
            this.dtpBirthday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(414, 22);
            this.dtpBirthday.TabIndex = 9;
            // 
            // lblAddress
            // 
            this.lblAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddress.Location = new System.Drawing.Point(3, 160);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(134, 96);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = "Address";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAddress
            // 
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.Location = new System.Drawing.Point(143, 162);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(414, 92);
            this.txtAddress.TabIndex = 11;
            // 
            // pnlButtons
            // 
            this.tlp.SetColumnSpan(this.pnlButtons, 2);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnOK);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlButtons.Location = new System.Drawing.Point(3, 258);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(554, 60);
            this.pnlButtons.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(451, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(345, 2);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 30);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // CustomersEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 320);
            this.Controls.Add(this.tlp);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CustomersEdit";
            this.Text = "Customer";
            this.tlp.ResumeLayout(false);
            this.tlp.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.TextBox txtLast;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}