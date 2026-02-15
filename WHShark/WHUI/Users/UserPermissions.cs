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
        private List<Family> _families = new List<Family>();
        private List<Patent> _patents = new List<Patent>();

        public UserPermissions()
        {
            InitializeComponent();
        }

        public void LoadForUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            UserId = user.IdUser;
            txtUser.Text = user.Username;
            EnsureListsLoaded();

            try
            {
                MarkUserPermissions(user);
            }
            catch (Exception ex)
            {
                LoggerService.WriteWarning($"Failed to mark roles/permissions for user {user?.Username ?? UserId.ToString()}: {ex.Message}");
            }

        }

        private void UserPermissions_Load(object sender, EventArgs e)
        {
            try
            {
                EnsureListsLoaded();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("An error occurred while loading roles and permissions: " + ex.Message); 
            }
        }

        private void EnsureListsLoaded()
        {
            if (lstRoles.Items.Count > 0 && clbPermissions.Items.Count > 0)
                return;

            string msg;

            _families = PermissionService.ListAllRoles(out msg)?.ToList() ?? new List<Family>();
            lstRoles.Items.Clear();
            lstRoles.DisplayMember = "Nombre";
            foreach (var f in _families)
            {
                lstRoles.Items.Add(f, false);
            }

            if (lstRoles.Items.Count > 0)
                lstRoles.SelectedIndex = 0;

            _patents = PermissionService.ListAllPermissions(out msg)?.ToList() ?? new List<Patent>();
            clbPermissions.Items.Clear();
            clbPermissions.DisplayMember = "MenuItemName"; 
            foreach (var p in _patents)
            {
                clbPermissions.Items.Add(p, false);
            }
        }

        private void MarkUserPermissions(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            var userRoles = user.Permisos?.OfType<Family>()
                                .Select(f => f.IdComponent)
                                .ToHashSet() ?? new HashSet<Guid>();

            for (int i = 0; i < lstRoles.Items.Count; i++)
            {
                var family = (Family)lstRoles.Items[i];
                bool assigned = userRoles.Contains(family.IdComponent);
                lstRoles.SetItemChecked(i, assigned);
            }
            var userPatents = user.Permisos?.OfType<Family>()
                          .SelectMany(f => f.GetChildrens()) 
                          .OfType<Patent>()               
                          .Select(p => p.IdComponent)
                          .ToHashSet() ?? new HashSet<Guid>();


            for (int i = 0; i < clbPermissions.Items.Count; i++)
            {
                var patent = (Patent)clbPermissions.Items[i];
                bool assigned = userPatents.Contains(patent.IdComponent);
                clbPermissions.SetItemChecked(i, assigned);
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

            // Collect selected roles
            var selectedRoles = new List<string>();
            foreach (var item in lstRoles.CheckedItems)
            {
                selectedRoles.Add(item.ToString());
            }

            // TODO: persist selected permissions and roles for the user (call service/repository)
            MessageBox.Show($"Roles: {selectedRoles.Count} - Permissions: {selected.Count}", "Manage Permissions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
