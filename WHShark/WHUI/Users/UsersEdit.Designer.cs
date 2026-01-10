// Added necessary using directives for .NET Framework 4.7 compatibility
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WHUI.Users
{
    partial class UsersEdit
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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.lblFirst = new System.Windows.Forms.Label();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.lblLast = new System.Windows.Forms.Label();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.cbBranch = new System.Windows.Forms.ComboBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.lblPwd2 = new System.Windows.Forms.Label();
            this.txtPwd2 = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.contentPanel.SuspendLayout();
            this.tlp.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.AutoScroll = true;
            this.contentPanel.Controls.Add(this.tlp);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.contentPanel.Size = new System.Drawing.Size(700, 301);
            this.contentPanel.TabIndex = 0;
            // 
            // tlp
            // 
            this.tlp.AutoSize = true;
            this.tlp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlp.ColumnCount = 2;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.Controls.Add(this.lblFirst, 0, 0);
            this.tlp.Controls.Add(this.txtFirst, 1, 0);
            this.tlp.Controls.Add(this.lblLast, 0, 1);
            this.tlp.Controls.Add(this.txtLast, 1, 1);
            this.tlp.Controls.Add(this.lblEmail, 0, 2);
            this.tlp.Controls.Add(this.txtEmail, 1, 2);
            this.tlp.Controls.Add(this.lblUsername, 0, 3);
            this.tlp.Controls.Add(this.txtUsername, 1, 3);
            this.tlp.Controls.Add(this.lblRole, 0, 4);
            this.tlp.Controls.Add(this.cbRole, 1, 4);
            this.tlp.Controls.Add(this.lblBranch, 0, 5);
            this.tlp.Controls.Add(this.cbBranch, 1, 5);
            this.tlp.Controls.Add(this.lblPwd, 0, 7);
            this.tlp.Controls.Add(this.txtPwd, 1, 7);
            this.tlp.Controls.Add(this.lblPwd2, 0, 8);
            this.tlp.Controls.Add(this.txtPwd2, 1, 8);
            this.tlp.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp.Location = new System.Drawing.Point(8, 6);
            this.tlp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 9;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tlp.Size = new System.Drawing.Size(684, 256);
            this.tlp.TabIndex = 0;
            // 
            // lblFirst
            // 
            this.lblFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFirst.Location = new System.Drawing.Point(3, 0);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(134, 30);
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
            this.txtFirst.Size = new System.Drawing.Size(538, 22);
            this.txtFirst.TabIndex = 1;
            // 
            // lblLast
            // 
            this.lblLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLast.Location = new System.Drawing.Point(3, 30);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(134, 30);
            this.lblLast.TabIndex = 2;
            this.lblLast.Text = "Last Name";
            this.lblLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLast
            // 
            this.txtLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLast.Location = new System.Drawing.Point(143, 32);
            this.txtLast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLast.Name = "txtLast";
            this.txtLast.Size = new System.Drawing.Size(538, 22);
            this.txtLast.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.Location = new System.Drawing.Point(3, 60);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(134, 30);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Location = new System.Drawing.Point(143, 62);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(538, 22);
            this.txtEmail.TabIndex = 5;
            // 
            // lblUsername
            // 
            this.lblUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsername.Location = new System.Drawing.Point(3, 90);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(134, 30);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "Username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUsername
            // 
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Location = new System.Drawing.Point(143, 92);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(538, 22);
            this.txtUsername.TabIndex = 7;
            // 
            // lblRole
            // 
            this.lblRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRole.Location = new System.Drawing.Point(3, 120);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(134, 30);
            this.lblRole.TabIndex = 8;
            this.lblRole.Text = "Role";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbRole
            // 
            this.cbRole.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.Location = new System.Drawing.Point(143, 122);
            this.cbRole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(220, 24);
            this.cbRole.TabIndex = 9;
            // 
            // lblBranch
            // 
            this.lblBranch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBranch.Location = new System.Drawing.Point(3, 150);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(134, 30);
            this.lblBranch.TabIndex = 10;
            this.lblBranch.Text = "Branch";
            this.lblBranch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbBranch
            // 
            this.cbBranch.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBranch.Location = new System.Drawing.Point(143, 152);
            this.cbBranch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbBranch.Name = "cbBranch";
            this.cbBranch.Size = new System.Drawing.Size(220, 24);
            this.cbBranch.TabIndex = 11;
            // 
            // lblPwd
            // 
            this.lblPwd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPwd.Location = new System.Drawing.Point(3, 210);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(134, 30);
            this.lblPwd.TabIndex = 12;
            this.lblPwd.Text = "Password";
            this.lblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPwd
            // 
            this.txtPwd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPwd.Location = new System.Drawing.Point(143, 212);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(538, 22);
            this.txtPwd.TabIndex = 13;
            this.txtPwd.UseSystemPasswordChar = true;
            // 
            // lblPwd2
            // 
            this.lblPwd2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPwd2.Location = new System.Drawing.Point(3, 240);
            this.lblPwd2.Name = "lblPwd2";
            this.lblPwd2.Size = new System.Drawing.Size(134, 16);
            this.lblPwd2.TabIndex = 14;
            this.lblPwd2.Text = "Confirm Password";
            this.lblPwd2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPwd2
            // 
            this.txtPwd2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPwd2.Location = new System.Drawing.Point(143, 242);
            this.txtPwd2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPwd2.Name = "txtPwd2";
            this.txtPwd2.Size = new System.Drawing.Size(538, 22);
            this.txtPwd2.TabIndex = 15;
            this.txtPwd2.UseSystemPasswordChar = true;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnOK);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlButtons.Location = new System.Drawing.Point(0, 301);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pnlButtons.Size = new System.Drawing.Size(700, 35);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(581, 8);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 18);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(475, 8);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 18);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            // 
            // UsersEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 336);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.pnlButtons);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(600, 313);
            this.Name = "UsersEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User";
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.tlp.ResumeLayout(false);
            this.tlp.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.TextBox txtLast;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cbBranch;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label lblPwd2;
        private System.Windows.Forms.TextBox txtPwd2;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        #endregion
    }
}