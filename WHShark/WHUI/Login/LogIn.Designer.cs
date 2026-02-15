using System;
using System.Drawing;
using System.Windows.Forms;

namespace WHUI.Login
{
    partial class LogIn
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.linkforget = new System.Windows.Forms.LinkLabel();
            this.LinkpassChange = new System.Windows.Forms.LinkLabel();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tlpContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pictureBox1, 0, 0);
            this.tlpMain.Controls.Add(this.tlpContent, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(800, 401);
            this.tlpMain.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(294, 397);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tlpContent
            // 
            this.tlpContent.ColumnCount = 1;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Controls.Add(this.label1, 0, 0);
            this.tlpContent.Controls.Add(this.labelUser, 0, 1);
            this.tlpContent.Controls.Add(this.txtUser, 0, 2);
            this.tlpContent.Controls.Add(this.labelPassword, 0, 3);
            this.tlpContent.Controls.Add(this.txtPass, 0, 4);
            this.tlpContent.Controls.Add(this.btnLogin, 0, 5);
            this.tlpContent.Controls.Add(this.linkforget, 0, 7);
            this.tlpContent.Controls.Add(this.LinkpassChange, 0, 8);
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.Location = new System.Drawing.Point(303, 2);
            this.tlpContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 10;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Size = new System.Drawing.Size(494, 397);
            this.tlpContent.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome";
            // 
            // labelUser
            // 
            this.labelUser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(10, 52);
            this.labelUser.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(70, 16);
            this.labelUser.TabIndex = 1;
            this.labelUser.Text = "Username";
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Location = new System.Drawing.Point(10, 77);
            this.txtUser.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(474, 22);
            this.txtUser.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(10, 108);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(67, 16);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password";
            // 
            // txtPass
            // 
            this.txtPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPass.Location = new System.Drawing.Point(10, 133);
            this.txtPass.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(474, 22);
            this.txtPass.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLogin.Location = new System.Drawing.Point(10, 165);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(10, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(120, 39);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // linkforget
            // 
            this.linkforget.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.linkforget.AutoSize = true;
            this.linkforget.Location = new System.Drawing.Point(10, 236);
            this.linkforget.Margin = new System.Windows.Forms.Padding(10, 2, 3, 2);
            this.linkforget.Name = "linkforget";
            this.linkforget.Size = new System.Drawing.Size(130, 16);
            this.linkforget.TabIndex = 7;
            this.linkforget.TabStop = true;
            this.linkforget.Text = "I forget my password";
            this.linkforget.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkforget_LinkClicked);
            // 
            // LinkpassChange
            // 
            this.LinkpassChange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LinkpassChange.AutoSize = true;
            this.LinkpassChange.Location = new System.Drawing.Point(10, 260);
            this.LinkpassChange.Margin = new System.Windows.Forms.Padding(10, 2, 3, 2);
            this.LinkpassChange.Name = "LinkpassChange";
            this.LinkpassChange.Size = new System.Drawing.Size(171, 16);
            this.LinkpassChange.TabIndex = 8;
            this.LinkpassChange.TabStop = true;
            this.LinkpassChange.Text = "I want change my password";
            this.LinkpassChange.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkpassChange_LinkClicked);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 401);
            this.Controls.Add(this.tlpMain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LogIn";
            this.Text = "LogIn";
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tlpContent.ResumeLayout(false);
            this.tlpContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlpMain;
        private PictureBox pictureBox1;
        private TableLayoutPanel tlpContent;
        private Label label1;
        private Label labelUser;
        private TextBox txtUser;
        private Label labelPassword;
        private TextBox txtPass;
        private Button btnLogin;
        private LinkLabel linkforget;
        private LinkLabel LinkpassChange;
    }
}