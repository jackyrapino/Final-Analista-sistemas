using System;
using System.Drawing;
using System.Windows.Forms;

namespace WHUI.Login
{
    partial class ResetPass
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.lblNew = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.txtRepeatPassword = new System.Windows.Forms.TextBox();
            this.buttonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.labelTitle, 0, 0);
            this.tlpMain.Controls.Add(this.labelInfo, 0, 1);
            this.tlpMain.Controls.Add(this.lblUsername, 0, 2);
            this.tlpMain.Controls.Add(this.txtUsername, 1, 2);
            this.tlpMain.Controls.Add(this.lblCurrent, 0, 3);
            this.tlpMain.Controls.Add(this.txtCurrentPassword, 1, 3);
            this.tlpMain.Controls.Add(this.lblNew, 0, 4);
            this.tlpMain.Controls.Add(this.txtNewPassword, 1, 4);
            this.tlpMain.Controls.Add(this.lblRepeat, 0, 5);
            this.tlpMain.Controls.Add(this.txtRepeatPassword, 1, 5);
            this.tlpMain.Controls.Add(this.buttonsPanel, 0, 6);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.tlpMain.RowCount = 8;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(800, 360);
            this.tlpMain.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.tlpMain.SetColumnSpan(this.labelTitle, 2);
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(12, 10);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(776, 51);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Change password";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.tlpMain.SetColumnSpan(this.labelInfo, 2);
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInfo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelInfo.Location = new System.Drawing.Point(12, 61);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(776, 14);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "Provide your username, current password and a new password.";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 88);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 16);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(178, 85);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(6, 2, 12, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(598, 22);
            this.txtUsername.TabIndex = 3;
            // 
            // lblCurrent
            // 
            this.lblCurrent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(12, 120);
            this.lblCurrent.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(114, 16);
            this.lblCurrent.TabIndex = 4;
            this.lblCurrent.Text = "Current password:";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentPassword.Location = new System.Drawing.Point(178, 117);
            this.txtCurrentPassword.Margin = new System.Windows.Forms.Padding(6, 2, 12, 2);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.Size = new System.Drawing.Size(598, 22);
            this.txtCurrentPassword.TabIndex = 5;
            this.txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // lblNew
            // 
            this.lblNew.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNew.AutoSize = true;
            this.lblNew.Location = new System.Drawing.Point(12, 152);
            this.lblNew.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(99, 16);
            this.lblNew.TabIndex = 6;
            this.lblNew.Text = "New password:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewPassword.Location = new System.Drawing.Point(178, 149);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(6, 2, 12, 2);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(598, 22);
            this.txtNewPassword.TabIndex = 7;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblRepeat
            // 
            this.lblRepeat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRepeat.AutoSize = true;
            this.lblRepeat.Location = new System.Drawing.Point(12, 184);
            this.lblRepeat.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(117, 16);
            this.lblRepeat.TabIndex = 8;
            this.lblRepeat.Text = "Repeat password:";
            // 
            // txtRepeatPassword
            // 
            this.txtRepeatPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRepeatPassword.Location = new System.Drawing.Point(178, 181);
            this.txtRepeatPassword.Margin = new System.Windows.Forms.Padding(6, 2, 12, 2);
            this.txtRepeatPassword.Name = "txtRepeatPassword";
            this.txtRepeatPassword.Size = new System.Drawing.Size(598, 22);
            this.txtRepeatPassword.TabIndex = 9;
            this.txtRepeatPassword.UseSystemPasswordChar = true;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonsPanel.AutoSize = true;
            this.buttonsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpMain.SetColumnSpan(this.buttonsPanel, 2);
            this.buttonsPanel.Controls.Add(this.btnChange);
            this.buttonsPanel.Controls.Add(this.btnCancel);
            this.buttonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonsPanel.Location = new System.Drawing.Point(279, 213);
            this.buttonsPanel.Margin = new System.Windows.Forms.Padding(6, 5, 12, 5);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(236, 38);
            this.buttonsPanel.TabIndex = 10;
            // 
            // btnChange
            // 
            this.btnChange.AutoSize = true;
            this.btnChange.Location = new System.Drawing.Point(124, 5);
            this.btnChange.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(106, 29);
            this.btnChange.TabIndex = 11;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(6, 5);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 29);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ResetPass
            // 
            this.AcceptButton = this.btnChange;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(800, 360);
            this.Controls.Add(this.tlpMain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(560, 313);
            this.Name = "ResetPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change password";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            this.buttonsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.TextBox txtRepeatPassword;
        private System.Windows.Forms.FlowLayoutPanel buttonsPanel;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnCancel;
    }
}