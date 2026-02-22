using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Services;
using DomainModel;
using Services.Services;

namespace WHUI.Purchases
{
    public partial class Purchases : Form
    {
        private bool _populatingBranches;

        public Purchases()
        {
           InitializeComponent();
        }

        private void Purchases_Load(object sender, EventArgs e)
        {
            PopulateBranches();
            try
            {
                LoadPurchases();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError(ex.ToString());
            }
        }

        private void PopulateBranches()
        {
            try
            {
                _populatingBranches = true;
                var branchSvc = new BranchService();
                var branches = branchSvc.SelectAll()?.ToList() ?? new List<Branch>();
                var all = new Branch { BranchId = Guid.Empty, Name = "All branches" };
                branches.Insert(0, all);

                cbBranch.DisplayMember = "Name";
                cbBranch.ValueMember = "BranchId";
                cbBranch.DataSource = branches;
                cbBranch.SelectedValue = Guid.Empty;
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to load branches for purchases combo: " + ex.ToString());
            }
            finally
            {
                _populatingBranches = false;
            }
        }

        private void LoadPurchases()
        {
            try
            {
                var svc = new PurchaseService();
                var items = svc.SelectAll()?.ToList() ?? new List<Purchase>();

                var rows = items.Select(p => new
                {
                    PurchaseId = p.PurchaseId,
                    PurchaseDate = p.PurchaseDate,
                    BranchName = p.Branch?.Name ?? string.Empty,
                    TotalAmount = p.TotalAmount,
                    UserName = p.User?.Name ?? string.Empty,
                    Status = p.Status
                }).ToList();

                dgv.AutoGenerateColumns = false;
                colPurchaseId.DataPropertyName = "PurchaseId";
                colPurchaseDate.DataPropertyName = "PurchaseDate";
                colBranchId.DataPropertyName = "BranchName";
                colTotalAmount.DataPropertyName = "TotalAmount";
                colUserId.DataPropertyName = "UserName";
                colStatus.DataPropertyName = "Status";

                dgv.DataSource = rows;
                lblStatus.Text = $"Loaded {items.Count} purchase(s).";
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to load purchases: " + ex.ToString());
                MessageBox.Show(this, "Failed to load purchases: " + ex.Message, "Purchases", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPurchasesByBranch(Guid branchId)
        {
            try
            {
                var svc = new PurchaseService();
                var items = svc.SelectAll()?.Where(p => p.Branch != null && p.Branch.BranchId == branchId).ToList() ?? new List<Purchase>();

                var rows = items.Select(p => new
                {
                    PurchaseId = p.PurchaseId,
                    PurchaseDate = p.PurchaseDate,
                    BranchName = p.Branch?.Name ?? string.Empty,
                    TotalAmount = p.TotalAmount,
                    UserName = p.User?.Name ?? string.Empty,
                    Status = p.Status
                }).ToList();

                dgv.AutoGenerateColumns = false;
                colPurchaseId.DataPropertyName = "PurchaseId";
                colPurchaseDate.DataPropertyName = "PurchaseDate";
                colBranchId.DataPropertyName = "BranchName";
                colTotalAmount.DataPropertyName = "TotalAmount";
                colUserId.DataPropertyName = "UserName";
                colStatus.DataPropertyName = "Status";

                dgv.DataSource = rows;
                lblStatus.Text = $"Loaded {items.Count} purchase(s) for branch.";
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to load purchases by branch: " + ex.ToString());
                MessageBox.Show(this, "Failed to load purchases by branch: " + ex.Message, "Purchases", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_populatingBranches) return;

                if (cbBranch.SelectedValue == null)
                {
                    LoadPurchases();
                    return;
                }

                Guid selectedId;
                if (cbBranch.SelectedValue is Guid g)
                    selectedId = g;
                else if (!Guid.TryParse(cbBranch.SelectedValue.ToString(), out selectedId))
                {
                    LoadPurchases();
                    return;
                }

                if (selectedId == Guid.Empty)
                    LoadPurchases();
                else
                    LoadPurchasesByBranch(selectedId);
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Error handling branch selection: " + ex.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new PurchasesEdit())
                {
                    dlg.LoadPurchase(null);
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        cbBranch_SelectedIndexChanged(cbBranch, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to open purchase editor: " + ex.ToString());
                MessageBox.Show(this, "Failed to open purchase editor: " + ex.Message, "Purchases", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.SelectedRows.Count == 0)
                {
                    MessageBox.Show(this, "Please select a purchase to edit.", "Edit Purchase", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dgv.SelectedRows[0];
                var purchaseId = (Guid)selectedRow.Cells["colPurchaseId"].Value;

                var svc = new PurchaseService();
                var purchase = svc.SelectOne(purchaseId);
                if (purchase == null)
                {
                    MessageBox.Show(this, "Purchase not found.", "Edit Purchase", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var dlg = new PurchasesEdit())
                {
                    dlg.LoadPurchase(purchase);
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        cbBranch_SelectedIndexChanged(cbBranch, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to open purchase editor: " + ex.ToString());
                MessageBox.Show(this, "Failed to open purchase editor: " + ex.Message, "Purchases", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.SelectedRows.Count == 0)
                {
                    MessageBox.Show(this, "Please select a purchase to delete.", "Delete Purchase", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dgv.SelectedRows[0];
                var purchaseId = (Guid)selectedRow.Cells["colPurchaseId"].Value;

                var confirmResult = MessageBox.Show(this, "Are you sure you want to delete this purchase?", "Delete Purchase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                var svc = new PurchaseService();
                svc.Delete(purchaseId);

                MessageBox.Show(this, "Purchase deleted successfully.", "Delete Purchase", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPurchases();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to delete purchase: " + ex.ToString());
                MessageBox.Show(this, "Failed to delete purchase: " + ex.Message, "Delete Purchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
