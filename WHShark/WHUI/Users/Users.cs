using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.Services;
using Services.DomainModel.Security.Composite;
using Services.DAL.Implementations;

namespace WHUI.Users
{
    public partial class Users : Form
    {
        private List<User> _usersCache = new List<User>();

        public Users()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadUsers();
        }

        private void LoadUsers()
        {
            lblStatus.Text = "Loading users...";
            try
            {
                string message;
                var users = LoginService.ListAllUsers(out message).ToList();

                _usersCache = users;

                var rows = (from u in users
                            select new
                            {
                                Username = u.Username,
                                Name = u.Name,
                                State = u.State.ToString(),
                                FailedAttempts = u.FailedAttempts,
                                IsAdmin = u.IsAdmin
                            }).ToList();

                dgv.DataSource = rows;

                lblStatus.Text = string.IsNullOrWhiteSpace(message) ? $"Loaded {rows.Count} users." : message;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to load users.";
                LoggerService.WriteError("Failed to load users: " + ex.Message);
                MessageBox.Show(this, "Failed to load users: " + ex.Message, "Users", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new UsersEdit())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    LoadUsers();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
            {
                MessageBox.Show(this, "Please select a user to edit.", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dgv.CurrentRow.Index;
            if (rowIndex < 0 || rowIndex >= _usersCache.Count)
            {
                MessageBox.Show(this, "Invalid selection.", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = _usersCache[rowIndex];
            try
            {
                global::Services.BLL.LoginBLL.PopulatePermissions(user);
            }
            catch (Exception ex)
            {
                LoggerService.WriteError($"An error occurred while loading permissions for user '{user?.Username}': {ex.Message}", user?.Username ?? string.Empty);
                MessageBox.Show(this, "An error occurred while loading user permissions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            using (var frm = new UsersEdit(true))
            {
                frm.LoadUser(user);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    LoadUsers();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
            {
                MessageBox.Show(this, "Please select a user to delete.", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dgv.CurrentRow.Index;
            if (rowIndex < 0 || rowIndex >= _usersCache.Count)
            {
                MessageBox.Show(this, "Invalid selection.", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = _usersCache[rowIndex];

            var confirm = MessageBox.Show(this, $"Are you sure you want to delete user '{user.Username}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            string message;
            var ok = LoginService.DeleteUser(user.IdUser, out message);
            if (ok)
            {
                MessageBox.Show(this, message ?? "User deleted.", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
            else
            {
                MessageBox.Show(this, message ?? "Failed to delete user.", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManagePermissions_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
            {
                MessageBox.Show(this, "Please select a user.", "Manage Permissions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dgv.CurrentRow.Index;
            if (rowIndex < 0 || rowIndex >= _usersCache.Count)
            {
                MessageBox.Show(this, "Invalid selection.", "Manage Permissions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = _usersCache[rowIndex];

            try
            {
                global::Services.BLL.LoginBLL.PopulatePermissions(user);
            }
            catch (Exception ex)
            {
                LoggerService.WriteError($"An error occurred while populating permissions for user '{user?.Username}': {ex.Message}", user?.Username ?? string.Empty);
                MessageBox.Show(this, "An error occurred while loading user permissions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            using (var frm = new UserPermissions())
            {
                frm.LoadForUser(user);
                 frm.ShowDialog(this);
            }
        }
    }
}
