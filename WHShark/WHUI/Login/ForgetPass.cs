using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.Services;
using Services.DomainModel.Security.Composite;

namespace WHUI.Login
{
    public partial class ForgetPass : Form
    {
        public ForgetPass()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnsenduser_Click(object sender, EventArgs e)
        {
            var username = txtuser.Text?.Trim() ?? string.Empty;
            string message;

            var user = LoginService.FindUserForReset(username, out message);
            if (user == null)
            {
                var display = string.IsNullOrWhiteSpace(message) ? "Cannot change password." : message;
                MessageBox.Show(this, display, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Hide();

            using (var frm = new ForceChangePass())
            {
                frm.SetUser(user);
                var res = frm.ShowDialog();
                this.Close();
            }
        }
    }
}
