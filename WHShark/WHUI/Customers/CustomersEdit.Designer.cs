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
            tlp = new TableLayoutPanel();
            lblFirst = new Label();
            txtFirst = new TextBox();
            lblLast = new Label();
            txtLast = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            pnlButtons = new FlowLayoutPanel();
            btnCancel = new Button();
            btnOK = new Button();
            tlp.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tlp
            // 
            tlp.ColumnCount = 2;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp.Controls.Add(lblFirst, 0, 0);
            tlp.Controls.Add(txtFirst, 1, 0);
            tlp.Controls.Add(lblLast, 0, 1);
            tlp.Controls.Add(txtLast, 1, 1);
            tlp.Controls.Add(lblEmail, 0, 2);
            tlp.Controls.Add(txtEmail, 1, 2);
            tlp.Controls.Add(lblPhone, 0, 3);
            tlp.Controls.Add(txtPhone, 1, 3);
            tlp.Controls.Add(lblAddress, 0, 4);
            tlp.Controls.Add(txtAddress, 1, 4);
            tlp.Controls.Add(pnlButtons, 0, 5);
            tlp.Dock = DockStyle.Fill;
            tlp.Location = new Point(0, 0);
            tlp.Name = "tlp";
            tlp.RowCount = 6;
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp.Size = new Size(560, 360);
            tlp.TabIndex = 0;
            // 
            // lblFirst
            // 
            lblFirst.Dock = DockStyle.Fill;
            lblFirst.Location = new Point(3, 0);
            lblFirst.Name = "lblFirst";
            lblFirst.Size = new Size(134, 40);
            lblFirst.TabIndex = 0;
            lblFirst.Text = "First Name";
            lblFirst.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtFirst
            // 
            txtFirst.Dock = DockStyle.Fill;
            txtFirst.Location = new Point(143, 3);
            txtFirst.Name = "txtFirst";
            txtFirst.Size = new Size(414, 27);
            txtFirst.TabIndex = 1;
            // 
            // lblLast
            // 
            lblLast.Dock = DockStyle.Fill;
            lblLast.Location = new Point(3, 40);
            lblLast.Name = "lblLast";
            lblLast.Size = new Size(134, 40);
            lblLast.TabIndex = 2;
            lblLast.Text = "Last Name";
            lblLast.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtLast
            // 
            txtLast.Dock = DockStyle.Fill;
            txtLast.Location = new Point(143, 43);
            txtLast.Name = "txtLast";
            txtLast.Size = new Size(414, 27);
            txtLast.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.Dock = DockStyle.Fill;
            lblEmail.Location = new Point(3, 80);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(134, 40);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Location = new Point(143, 83);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(414, 27);
            txtEmail.TabIndex = 5;
            // 
            // lblPhone
            // 
            lblPhone.Dock = DockStyle.Fill;
            lblPhone.Location = new Point(3, 120);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(134, 40);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Phone";
            lblPhone.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPhone
            // 
            txtPhone.Dock = DockStyle.Fill;
            txtPhone.Location = new Point(143, 123);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(414, 27);
            txtPhone.TabIndex = 7;
            // 
            // lblAddress
            // 
            lblAddress.Dock = DockStyle.Fill;
            lblAddress.Location = new Point(3, 160);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(134, 120);
            lblAddress.TabIndex = 8;
            lblAddress.Text = "Address";
            lblAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtAddress
            // 
            txtAddress.Dock = DockStyle.Fill;
            txtAddress.Location = new Point(143, 163);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(414, 114);
            txtAddress.TabIndex = 9;
            // 
            // pnlButtons
            // 
            tlp.SetColumnSpan(pnlButtons, 2);
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Controls.Add(btnOK);
            pnlButtons.Dock = DockStyle.Fill;
            pnlButtons.FlowDirection = FlowDirection.RightToLeft;
            pnlButtons.Location = new Point(3, 283);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(554, 74);
            pnlButtons.TabIndex = 10;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(451, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(345, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 23);
            btnOK.TabIndex = 1;
            btnOK.Text = "OK";
            // 
            // CustomersEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 360);
            Controls.Add(tlp);
            Name = "CustomersEdit";
            Text = "Customer";
            tlp.ResumeLayout(false);
            tlp.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
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
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}