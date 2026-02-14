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
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.lblFailedAttempts = new System.Windows.Forms.Label();
            this.txtFailedAttempts = new System.Windows.Forms.TextBox();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.chkIsAdmin = new System.Windows.Forms.CheckBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRepeatPassword = new System.Windows.Forms.Label();
            this.txtRepeatPassword = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
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
            this.contentPanel.Size = new System.Drawing.Size(737, 307);
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
            this.tlp.Controls.Add(this.lblUsername, 0, 1);
            this.tlp.Controls.Add(this.txtUsername, 1, 1);
            this.tlp.Controls.Add(this.lblState, 0, 2);
            this.tlp.Controls.Add(this.cbState, 1, 2);
            this.tlp.Controls.Add(this.lblFailedAttempts, 0, 3);
            this.tlp.Controls.Add(this.txtFailedAttempts, 1, 3);
            this.tlp.Controls.Add(this.lblAdmin, 0, 4);
            this.tlp.Controls.Add(this.chkIsAdmin, 1, 4);
            this.tlp.Controls.Add(this.lblPassword, 0, 5);
            this.tlp.Controls.Add(this.txtPassword, 1, 5);
            this.tlp.Controls.Add(this.lblRepeatPassword, 0, 6);
            this.tlp.Controls.Add(this.txtRepeatPassword, 1, 6);
            this.tlp.Controls.Add(this.lblRole, 0, 7);
            this.tlp.Controls.Add(this.cbRole, 1, 7);
            this.tlp.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp.Location = new System.Drawing.Point(8, 6);
            this.tlp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 8;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.Size = new System.Drawing.Size(721, 240);
            this.tlp.TabIndex = 0;
            // 
            // lblFirst
            // 
            this.lblFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFirst.Location = new System.Drawing.Point(3, 0);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(134, 30);
            this.lblFirst.TabIndex = 0;
            this.lblFirst.Text = "Name";
            this.lblFirst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFirst
            // 
            this.txtFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFirst.Location = new System.Drawing.Point(143, 2);
            this.txtFirst.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(575, 22);
            this.txtFirst.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsername.Location = new System.Drawing.Point(3, 30);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(134, 30);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "Username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUsername
            // 
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Location = new System.Drawing.Point(143, 32);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(575, 22);
            this.txtUsername.TabIndex = 7;
            // 
            // lblState
            // 
            this.lblState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblState.Location = new System.Drawing.Point(3, 60);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(134, 30);
            this.lblState.TabIndex = 8;
            this.lblState.Text = "State";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbState
            // 
            this.cbState.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.Location = new System.Drawing.Point(143, 62);
            this.cbState.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(220, 24);
            this.cbState.TabIndex = 9;
            // 
            // lblFailedAttempts
            // 
            this.lblFailedAttempts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFailedAttempts.Location = new System.Drawing.Point(3, 90);
            this.lblFailedAttempts.Name = "lblFailedAttempts";
            this.lblFailedAttempts.Size = new System.Drawing.Size(134, 30);
            this.lblFailedAttempts.TabIndex = 10;
            this.lblFailedAttempts.Text = "Failed Attempts";
            this.lblFailedAttempts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFailedAttempts
            // 
            this.txtFailedAttempts.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtFailedAttempts.Location = new System.Drawing.Point(143, 92);
            this.txtFailedAttempts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFailedAttempts.Name = "txtFailedAttempts";
            this.txtFailedAttempts.ReadOnly = true;
            this.txtFailedAttempts.Size = new System.Drawing.Size(100, 22);
            this.txtFailedAttempts.TabIndex = 11;
            // 
            // lblAdmin
            // 
            this.lblAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAdmin.Location = new System.Drawing.Point(3, 120);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(134, 30);
            this.lblAdmin.TabIndex = 12;
            this.lblAdmin.Text = "Administrator";
            this.lblAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIsAdmin
            // 
            this.chkIsAdmin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIsAdmin.AutoSize = true;
            this.chkIsAdmin.Location = new System.Drawing.Point(143, 126);
            this.chkIsAdmin.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.chkIsAdmin.Name = "chkIsAdmin";
            this.chkIsAdmin.Size = new System.Drawing.Size(18, 17);
            this.chkIsAdmin.TabIndex = 13;
            this.chkIsAdmin.UseVisualStyleBackColor = true;
            // 
            // lblPassword
            // 
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Location = new System.Drawing.Point(3, 150);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(134, 30);
            this.lblPassword.TabIndex = 20;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Location = new System.Drawing.Point(143, 152);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(575, 22);
            this.txtPassword.TabIndex = 21;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblRepeatPassword
            // 
            this.lblRepeatPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRepeatPassword.Location = new System.Drawing.Point(3, 180);
            this.lblRepeatPassword.Name = "lblRepeatPassword";
            this.lblRepeatPassword.Size = new System.Drawing.Size(134, 30);
            this.lblRepeatPassword.TabIndex = 22;
            this.lblRepeatPassword.Text = "Repeat Password";
            this.lblRepeatPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRepeatPassword
            // 
            this.txtRepeatPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRepeatPassword.Location = new System.Drawing.Point(143, 182);
            this.txtRepeatPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRepeatPassword.Name = "txtRepeatPassword";
            this.txtRepeatPassword.Size = new System.Drawing.Size(575, 22);
            this.txtRepeatPassword.TabIndex = 23;
            this.txtRepeatPassword.UseSystemPasswordChar = true;
            // 
            // lblRole
            // 
            this.lblRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRole.Location = new System.Drawing.Point(3, 210);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(134, 30);
            this.lblRole.TabIndex = 14;
            this.lblRole.Text = "Role";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbRole
            // 
            this.cbRole.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.Location = new System.Drawing.Point(143, 212);
            this.cbRole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(220, 24);
            this.cbRole.TabIndex = 15;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnOK);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlButtons.Location = new System.Drawing.Point(0, 307);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pnlButtons.Size = new System.Drawing.Size(737, 46);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(618, 8);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(512, 8);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 26);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // UsersEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 353);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.pnlButtons);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(600, 380);
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
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.Label lblFailedAttempts;
        private System.Windows.Forms.TextBox txtFailedAttempts;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.CheckBox chkIsAdmin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRepeatPassword;
        private System.Windows.Forms.TextBox txtRepeatPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        #endregion
    }
}