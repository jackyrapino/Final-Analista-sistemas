using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.DomainModel.Security.Composite;

namespace WHUI.Login
{
    public partial class ForceChangePass : Form
    {
        private User _user;

        public ForceChangePass()
        {
            InitializeComponent();
        }
        public void SetUser(User user)
        {
            _user = user;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            var newPass = txtNewPassword.Text ?? string.Empty;
            var repeat = txtRepeatPassword.Text ?? string.Empty;

            // Compare passwords
            if (!string.Equals(newPass, repeat, StringComparison.Ordinal))
            {
                throw new InvalidOperationException("Passwords do not match.");
            }

            if (_user == null)
            {
                MessageBox.Show(this, "No user provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Hash and set password, update state and failed attempts
                _user.Password = global::Services.Services.CryptographyService.HashPassword(newPass);
                _user.State = global::Services.DomainModel.Security.UserState.Active;
                _user.FailedAttempts = 0;

                string message;
                var ok = global::Services.Services.LoginService.UpdateUser(_user, out message);
                if (ok)
                {
                    MessageBox.Show(this, message ?? "Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, message ?? "Failed to update password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
