using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WHUI.Login
{
    partial class ForceChangePass
    {
        private IContainer components = null;
        private TextBox txtNewPassword;
        private TextBox txtRepeatPassword;
        private Button btnSet;
        private Label lblNew;
        private Label lblRepeat;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtRepeatPassword = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.lblNew = new System.Windows.Forms.Label();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(149, 13);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(228, 22);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtRepeatPassword
            // 
            this.txtRepeatPassword.Location = new System.Drawing.Point(149, 49);
            this.txtRepeatPassword.Name = "txtRepeatPassword";
            this.txtRepeatPassword.Size = new System.Drawing.Size(228, 22);
            this.txtRepeatPassword.TabIndex = 3;
            this.txtRepeatPassword.UseSystemPasswordChar = true;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(291, 90);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(86, 26);
            this.btnSet.TabIndex = 4;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Location = new System.Drawing.Point(14, 16);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(99, 16);
            this.lblNew.TabIndex = 0;
            this.lblNew.Text = "New password:";
            // 
            // lblRepeat
            // 
            this.lblRepeat.AutoSize = true;
            this.lblRepeat.Location = new System.Drawing.Point(14, 54);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(117, 16);
            this.lblRepeat.TabIndex = 2;
            this.lblRepeat.Text = "Repeat password:";
            // 
            // ForceChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 134);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblRepeat);
            this.Controls.Add(this.txtRepeatPassword);
            this.Controls.Add(this.btnSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ForceChangePass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}