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
        private Dictionary<Guid, int> _patentIndexById = new Dictionary<Guid, int>();
        private User _currentUser;

        public UserPermissions()
        {
            InitializeComponent();
            lstRoles.ItemCheck += LstRoles_ItemCheck;
        }

        public void LoadForUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            UserId = user.IdUser;
            _currentUser = user;
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
            _patentIndexById.Clear();
            for (int i = 0; i < _patents.Count; i++)
            {
                var p = _patents[i];
                clbPermissions.Items.Add(p, false);
                _patentIndexById[p.IdComponent] = i;
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

            var patentIds = new HashSet<Guid>();

            var directPatents = user.Permisos?.OfType<Patent>()
                                .Select(p => p.IdComponent) ?? Enumerable.Empty<Guid>();
            foreach (var id in directPatents)
                patentIds.Add(id);

            var familyList = user.Permisos?.OfType<Family>() ?? Enumerable.Empty<Family>();
            foreach (var fam in familyList)
            {
                CollectPatentIds(fam, patentIds);
            }

            for (int i = 0; i < clbPermissions.Items.Count; i++)
            {
                var patent = (Patent)clbPermissions.Items[i];
                bool assigned = patentIds.Contains(patent.IdComponent);
                clbPermissions.SetItemChecked(i, assigned);
            }
        }

        private void LstRoles_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                int idx = e.Index;
                if (idx < 0 || idx >= _families.Count) return;

                var family = _families[idx];
                var patentIds = new HashSet<Guid>();
                CollectPatentIds(family, patentIds);

                bool check = e.NewValue == CheckState.Checked;
                foreach (var pid in patentIds)
                {
                    if (_patentIndexById.TryGetValue(pid, out int pIndex))
                    {
                        clbPermissions.SetItemChecked(pIndex, check);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteWarning("Failed to update patents when role toggled: " + ex.Message);
            }
        }

        private void CollectPatentIds(Family family, HashSet<Guid> outIds)
        {
            if (family == null) return;

            foreach (var child in family.GetChildrens())
            {
                if (child == null) continue;
                try
                {
                    if (child.ChildrenCount() == 0)
                    {
                        outIds.Add(child.IdComponent);
                    }
                    else
                    {
                        var childFam = child as Family;
                        if (childFam != null)
                            CollectPatentIds(childFam, outIds);
                    }
                }
                catch
                {
                    // ignore
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var updatedUser = _currentUser;
            var selectedRoles = lstRoles.CheckedItems.Cast<Family>().ToList();

            var selectedPatents = clbPermissions.CheckedItems.Cast<Patent>().ToList();
            updatedUser.Permisos = new List<Services.DomainModel.Security.Composite.Component>();
            updatedUser.Permisos.AddRange(selectedRoles);
            updatedUser.Permisos.AddRange(selectedPatents);

            string msg;
            var ok = PermissionService.UpdateUserPermissions(updatedUser, out msg);
            if (ok)
            {
                MessageBox.Show(this, msg ?? "Permissions updated successfully.", "Manage Permissions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(this, msg ?? "Failed to update permissions.", "Manage Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
