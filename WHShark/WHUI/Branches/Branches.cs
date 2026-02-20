using System;
using System.Linq;
using System.Windows.Forms;
using DomainModel;
using BLL.Services;
using Services.Services;
using DAL.Implementations;

namespace WHUI.Branches
{
    public partial class Branches : Form
    {
        public Branches()
        {
            InitializeComponent();
        }

        private void Branches_Load(object sender, EventArgs e)
        {
            LoadBranches();
        }

        private void LoadBranches()
        {
            try
            {
                var svc = new BranchService();
                var items = svc.SelectAll();
                var list = items?.ToList() ?? new System.Collections.Generic.List<Branch>();
                dgv.DataSource = list;
                lblStatus.Text = $"Loaded {list.Count} branch(es).";
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to load branches: " + ex.Message);
                MessageBox.Show(this, "Failed to load branches: " + ex.Message, "Branches", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var dlg = new BranchEdit())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadBranches();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
                return;

            var cell = dgv.CurrentRow.Cells["colBranchId"].Value;
            if (cell == null) return;

            if (!Guid.TryParse(cell.ToString(), out Guid id)) return;

            var branch = BranchRepository.Current.SelectOne(id);
            if (branch == null) return;

            using (var dlg = new BranchEdit())
            {
                dlg.LoadBranch(branch);
                dlg.ShowDialog(this);
                LoadBranches();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;
            var cell = dgv.CurrentRow.Cells["colBranchId"].Value;
            if (cell == null) return;
            if (!Guid.TryParse(cell.ToString(), out Guid id)) return;

            var confirm = MessageBox.Show(this, "Are you sure you want to delete this branch?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var svc = new BranchService();
                svc.Delete(id);
                LoadBranches();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to delete branch: " + ex.Message);
                MessageBox.Show(this, "Failed to delete branch: " + ex.Message, "Branches", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
