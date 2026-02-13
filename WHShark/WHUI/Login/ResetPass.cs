using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.Services;

namespace WHUI.Login
{
    public partial class ResetPass : Form
    {
        public ResetPass()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Just close the dialog and return to the owner (original LogIn) if any
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string validationMessage;
            if (!ValidateInputs(out validationMessage))
            {
                MessageBox.Show(this, validationMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // After validation, gather values
            var username = txtUsername.Text?.Trim() ?? string.Empty;
            var current = txtCurrentPassword.Text ?? string.Empty;
            var newPass = txtNewPassword.Text ?? string.Empty;

            try
            {
                // Use service facade which returns bool and message
                string serviceMessage;
                var ok = LoginService.ChangePassword(username, current, newPass, out serviceMessage);

                if (ok)
                {
                    LoggerService.WriteInfo($"Password changed for user: {username}", username);
                    MessageBox.Show(this, serviceMessage ?? "Password changed successfully.", "Change password", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
                else
                {
                    // Business-level failure, message provided by service
                    LoggerService.WriteWarning(serviceMessage ?? "Failed to change password.");
                    MessageBox.Show(this, serviceMessage ?? "Failed to change password.", "Change password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Unexpected errors
                LoggerService.WriteError("Error changing password: " + ex.Message);
                MessageBox.Show(this, "An unexpected error occurred while changing the password.", "Change password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs(out string message)
        {
            var username = txtUsername.Text?.Trim() ?? string.Empty;
            var current = txtCurrentPassword.Text ?? string.Empty;
            var newPass = txtNewPassword.Text ?? string.Empty;
            var repeat = txtRepeatPassword.Text ?? string.Empty;

            if (string.IsNullOrWhiteSpace(username))
            {
                message = "Username is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(current))
            {
                message = "Current password is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(newPass))
            {
                message = "New password is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(repeat))
            {
                message = "Please repeat the new password.";
                return false;
            }

            if (!string.Equals(newPass, repeat, StringComparison.Ordinal))
            {
                message = "New password and repeated password do not match.";
                return false;
            }

            message = null;
            return true;
        }
    }
}