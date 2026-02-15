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

namespace WHUI.Users
{
    public partial class UserPermissions : Form
    {
        public Guid UserId { get; private set; }
        public UserPermissions()
        {
            InitializeComponent();
        }

        public void LoadForUser(Guid userId, string username)
        {
            UserId = userId;
            txtUser.Text = username;

            // If permissions/roles already loaded on form load, just set selection here
            if (cmbRole.Items.Count == 0 || clbPermissions.Items.Count == 0)
            {
                // Trigger load now
                UserPermissions_Load(this, EventArgs.Empty);
            }

            // TODO: load user's assigned permissions from repository and set checked items accordingly
        }

        private void UserPermissions_Load(object sender, EventArgs e)
        {
            try
            {
                string msg;
                // Load roles (families)
                var families = PermissionService.ListAllRoles(out msg)?.ToList() ?? new List<Family>();
                cmbRole.Items.Clear();
                foreach (var f in families)
                {
                    cmbRole.Items.Add(f.Nombre);
                }

                if (cmbRole.Items.Count > 0)
                    cmbRole.SelectedIndex = 0;

                // Load patents (permissions)
                var patents = PermissionService.ListAllPermissions(out msg)?.ToList() ?? new List<Patent>();
                clbPermissions.Items.Clear();
                foreach (var p in patents)
                {
                    // Prefer MenuItemName if present, otherwise FormName
                    var label = string.IsNullOrWhiteSpace(p.MenuItemName) ? p.FormName : p.MenuItemName;
                    clbPermissions.Items.Add(label, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to load roles and permissions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Collect selected permissions
            var selected = new List<string>();
            foreach (var item in clbPermissions.CheckedItems)
            {
                selected.Add(item.ToString());
            }

            // TODO: persist selected permissions and role for the user (call service/repository)
            MessageBox.Show($"Permissions applied: {selected.Count}", "Manage Permissions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Revert changes: simply reload current user permissions
            LoadForUser(UserId, txtUser.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
