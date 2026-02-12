using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WHUI.Users
{
    public partial class UserPermissions : Form
    {
        public Guid UserId { get; private set; }

        // Example list of all possible permissions in the system
        private readonly List<string> _allPermissions = new List<string>
        {
            "PRODUCTS.VIEW",
            "PRODUCTS.ADD",
            "PRODUCTS.EDIT",
            "PRODUCTS.DELETE",
            "STOCK.VIEW",
            "STOCK.ADJUST",
            "SALES.CREATE",
            "SALES.VIEW",
            "PURCHASES.CREATE",
            "USERS.MANAGE",
        };

        public UserPermissions()
        {
            InitializeComponent();
        }

        public void LoadForUser(Guid userId, string username)
        {
            UserId = userId;
            txtUser.Text = username;

            // Load roles into combo (for demo using static list)
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Administrator");
            cmbRole.Items.Add("Manager");
            cmbRole.Items.Add("Clerk");

            cmbRole.SelectedIndex = 0;

            // Populate the checked list box with all permissions
            clbPermissions.Items.Clear();
            foreach (var p in _allPermissions)
            {
                clbPermissions.Items.Add(p, false);
            }

            // TODO: load user's assigned permissions from repository and set checked items accordingly
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
