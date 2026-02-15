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
        private bool _isEdit;

        public UsersEdit() : this(false)
        {
        }

        public UsersEdit(bool isEdit)
        {
            InitializeComponent();

            _isEdit = isEdit;

            // If creating a new user, initialize model to avoid null refs
            if (!_isEdit)
            {
                _user = new User { IdUser = Guid.NewGuid() };
                txtFailedAttempts.Text = _user.FailedAttempts.ToString();
                cbState.SelectedItem = global::Services.DomainModel.Security.UserState.Active.ToString();
            }

            cbState.Items.AddRange(Enum.GetNames(typeof(global::Services.DomainModel.Security.UserState)));
            try
            {
                string famMessage;
                var families = LoginService.ListAllFamilies(out famMessage)?.ToList() ?? new List<Family>();
                _families = families;
                cbRole.Items.Clear();
                foreach (var f in _families)
                    cbRole.Items.Add(f.Nombre);
                if (cbRole.Items.Count > 0)
                    cbRole.SelectedIndex = 0;
            }
            catch
            {
                // ignore failures, leave combobox empty
            }

            // Disable password fields in edit mode to prevent accidental changes
            txtPassword.Enabled = !_isEdit;
            txtRepeatPassword.Enabled = !_isEdit;
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
                var userFamily = _user.Permisos?.OfType<Family>().FirstOrDefault();
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

            // Ensure enabled state follows edit mode (in case LoadUser is called after ctor)
            txtPassword.Enabled = !_isEdit;
            txtRepeatPassword.Enabled = !_isEdit;
        }

        /// <summary>
        /// Public method that receives isEdit and delegates to specialized methods.
        /// It logs exceptions via LoggerService.
        /// </summary>
        public (bool ok, string message) PublicUserEdit(bool isEdit)
        {
            try
            {
                if (isEdit)
                {
                    return UpdateUser();
                }
                else
                {
                    return CreateUser();
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteError($"Error in PublicUserEdit: {ex.Message}");
                return (false, ex.Message);
            }
        }

        private (bool ok, string message) CreateUser()
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtFirst.Text))
                return (false, "Name is required.");
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
                return (false, "Username is required.");

            // If password fields are used, verify match
            if (!string.IsNullOrEmpty(txtPassword.Text) || !string.IsNullOrEmpty(txtRepeatPassword.Text))
            {
                if (txtPassword.Text != txtRepeatPassword.Text)
                    return (false, "Passwords do not match.");
            }

            // Update model
            _user.Name = txtFirst.Text.Trim();
            _user.Username = txtUsername.Text.Trim();
            _user.IsAdmin = chkIsAdmin.Checked;

            if (cbState.SelectedItem != null && Enum.TryParse(cbState.SelectedItem.ToString(), out global::Services.DomainModel.Security.UserState state))
                _user.State = state;

            // If a role (family) selected, ensure user.Permisos contains it
            if (cbRole.SelectedItem != null)
            {
                var famName = cbRole.SelectedItem.ToString();
                var fam = _families.FirstOrDefault(f => f.Nombre == famName);
                if (fam != null)
                {
                    _user.Permisos = new List<Component> { fam };
                }
            }

            // If password provided, hash and set
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                _user.Password = CryptographyService.HashPassword(txtPassword.Text);
            }

            // Call service to add
            string message;
            var ok = LoginService.AddUser(_user, out message);
            return (ok, message);
        }

        private (bool ok, string message) UpdateUser()
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtFirst.Text))
                return (false, "Name is required.");
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
                return (false, "Username is required.");

            // If password fields are used, verify match
            if (!string.IsNullOrEmpty(txtPassword.Text) || !string.IsNullOrEmpty(txtRepeatPassword.Text))
            {
                if (txtPassword.Text != txtRepeatPassword.Text)
                    return (false, "Passwords do not match.");
            }

            // Update model
            _user.Name = txtFirst.Text.Trim();
            _user.Username = txtUsername.Text.Trim();
            _user.IsAdmin = chkIsAdmin.Checked;

            if (cbState.SelectedItem != null && Enum.TryParse(cbState.SelectedItem.ToString(), out global::Services.DomainModel.Security.UserState state))
                _user.State = state;

            // If a role (family) selected, ensure user.Permisos contains it
            if (cbRole.SelectedItem != null)
            {
                var famName = cbRole.SelectedItem.ToString();
                var fam = _families.FirstOrDefault(f => f.Nombre == famName);
                if (fam != null)
                {
                    _user.Permisos = new List<Component> { fam };
                }
            }

            // If password provided, hash and set
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                _user.Password = CryptographyService.HashPassword(txtPassword.Text);
            }

            // Call service to update
            string message;
            var ok = LoginService.UpdateUser(_user, out message);
            return (ok, message);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var result = PublicUserEdit(_isEdit);
            if (result.ok)
            {
                MessageBox.Show(this, result.message ?? "Saved.", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(this, result.message ?? "Failed to save user.", "User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
