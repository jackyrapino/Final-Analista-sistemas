using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Services.DomainModel.Security.Composite;
using Services.Services;

namespace WHUI.Users
{
    public partial class UsersEdit : Form
    {
        private User _user;
        private List<Family> _families = new List<Family>();

        public UsersEdit()
        {
            InitializeComponent();
            cbState.Items.AddRange(Enum.GetNames(typeof(global::Services.DomainModel.Security.UserState)));
            try
            {
                string famMessage;
                var families = LoginService.ListAllFamilies(out famMessage)?.ToList() ?? new List<Family>();
                _families = families;
                cbRole.Items.Clear();
                foreach (var f in _families)
                    cbRole.Items.Add(f.Nombre);
            }
            catch
            {
                // ignore failures, leave combobox empty
            }
        }

        public void LoadUser(User user)
        {
            _user = user ?? new User();

            txtFirst.Text = _user.Name;
            txtUsername.Text = _user.Username;
            txtFailedAttempts.Text = _user.FailedAttempts.ToString();
            chkIsAdmin.Checked = _user.IsAdmin;

            cbState.SelectedItem = _user.State.ToString();

            try
            {
                var userFamily = _user.Permisos.OfType<Family>().FirstOrDefault();
                if (userFamily != null)
                {
                    var match = _families.FirstOrDefault(f => f.IdComponent == userFamily.IdComponent);
                    if (match != null)
                        cbRole.SelectedItem = match.Nombre;
                    else
                        cbRole.SelectedItem = userFamily.Nombre;
                }
                else if (_families.Count > 0)
                {
                    cbRole.SelectedIndex = 0;
                }
            }
            catch
            {
                // ignore
            }

            // Clear password fields
            txtPassword.Text = string.Empty;
            txtRepeatPassword.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            // Validation
            if (string.IsNullOrWhiteSpace(txtFirst.Text))
            {
                MessageBox.Show(this, "Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show(this, "Username is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // If password fields are used, verify match
            if (!string.IsNullOrEmpty(txtPassword.Text) || !string.IsNullOrEmpty(txtRepeatPassword.Text))
            {
                if (txtPassword.Text != txtRepeatPassword.Text)
                {
                    MessageBox.Show(this, "Passwords do not match.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Update model
            _user.Name = txtFirst.Text.Trim();
            _user.Username = txtUsername.Text.Trim();
            _user.IsAdmin = chkIsAdmin.Checked;

            if (cbState.SelectedItem != null && Enum.TryParse(cbState.SelectedItem.ToString(), out global::Services.DomainModel.Security.UserState state))
                _user.State = state;

            // If password provided, hash and set
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                _user.Password = CryptographyService.HashPassword(txtPassword.Text);
            }

            // Persist via services layer
            string message;
            var ok = LoginService.UpdateUser(_user, out message);
            if (ok)
            {
                MessageBox.Show(this, message ?? "Saved.", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(this, message ?? "Failed to save user.", "User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
