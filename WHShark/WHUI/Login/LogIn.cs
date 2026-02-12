using System;
using System.Windows.Forms;
using Services.Services;

namespace WHUI.Login
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUser.Text?.Trim() ?? string.Empty;
            var password = txtPass.Text ?? string.Empty;

            try
            {
                Services.DomainModel.Security.Composite.User user;
                string message;

                // Call the services layer TryLogin which delegates to BLL
                var ok = LoginService.TryLogin(username, password, out user, out message);

                if (ok)
                {
                    // Successful login: close dialog with OK so caller can open menu
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Show error message returned by service
                    MessageBox.Show(this, message ?? "Login failed.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Unexpected error
                MessageBox.Show(this, "An unexpected error occurred: " + ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}