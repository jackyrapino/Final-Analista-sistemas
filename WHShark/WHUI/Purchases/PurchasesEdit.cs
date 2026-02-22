using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DomainModel;
using BLL.Services;
using Services.Services;
using DAL.Implementations;

namespace WHUI.Purchases
{
    public partial class PurchasesEdit : Form
    {
        private Purchase _purchase;

        public PurchasesEdit()
        {
            InitializeComponent();
        }

        public void LoadPurchase(Purchase purchase)
        {
            _purchase = purchase;

            try
            {
                var supplierSvc = new SupplierService();
                var suppliers = supplierSvc.SelectAll()?.ToList() ?? new List<Supplier>();
                cmbSupplier.DisplayMember = "Name";
                cmbSupplier.ValueMember = "SupplierId";
                cmbSupplier.DataSource = suppliers;

                var branchSvc = new BranchService();
                var branches = branchSvc.SelectAll()?.ToList() ?? new List<Branch>();
                cmbBranch.DisplayMember = "Name";
                cmbBranch.ValueMember = "BranchId";
                cmbBranch.DataSource = branches;

                var users = DAL.Implementations.UserRepository.Current.SelectAll()?.ToList() ?? new List<DomainModel.User>();
                cmbUser.DisplayMember = "Name";
                cmbUser.ValueMember = "UserId";
                cmbUser.DataSource = users;

                cmbStatus.DisplayMember = null;
                cmbStatus.ValueMember = null;
                cmbStatus.DataSource = DomainModel.PurchaseStatus.List().ToList();

                if (_purchase != null)
                {
                    cmbSupplier.SelectedValue = _purchase.Supplier?.SupplierId ?? Guid.Empty;
                    cmbBranch.SelectedValue = _purchase.Branch?.BranchId ?? Guid.Empty;
                    cmbUser.SelectedValue = _purchase.User?.UserId ?? Guid.Empty;
                    dtpPurchaseDate.Value = _purchase.PurchaseDate == default(DateTime) ? DateTime.Now : _purchase.PurchaseDate;
                    cmbStatus.SelectedItem = _purchase.Status ?? DomainModel.PurchaseStatus.Pending;
                    numTotal.Value = _purchase.TotalAmount;

                    RefreshItemsGrid();
                }
                else
                {
                    dtpPurchaseDate.Value = DateTime.Now;
                    cmbStatus.SelectedItem = DomainModel.PurchaseStatus.Pending;
                    numTotal.Value = 0;
                    dgvItems.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to load purchase edit lookups: " + ex.ToString());
                MessageBox.Show(this, "Failed to load lookup data: " + ex.Message, "Purchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOK_SetPurchaseValuesAndSave()
        {
            var svc = new PurchaseService();

            var purchase = _purchase ?? new Purchase { PurchaseId = Guid.Empty };

            var supId = cmbSupplier.SelectedValue as Guid? ?? (cmbSupplier.SelectedValue != null ? Guid.Parse(cmbSupplier.SelectedValue.ToString()) : Guid.Empty);
            purchase.Supplier = supId == Guid.Empty ? null : DAL.Implementations.SupplierRepository.Current.SelectOne(supId);

            var brId = cmbBranch.SelectedValue as Guid? ?? (cmbBranch.SelectedValue != null ? Guid.Parse(cmbBranch.SelectedValue.ToString()) : Guid.Empty);
            purchase.Branch = brId == Guid.Empty ? null : DAL.Implementations.BranchRepository.Current.SelectOne(brId);

            var userId = cmbUser.SelectedValue as Guid? ?? (cmbUser.SelectedValue != null ? Guid.Parse(cmbUser.SelectedValue.ToString()) : Guid.Empty);
            purchase.User = userId == Guid.Empty ? null : DAL.Implementations.UserRepository.Current.SelectOne(userId);

            purchase.PurchaseDate = dtpPurchaseDate.Value;
            purchase.Status = cmbStatus.SelectedItem?.ToString() ?? DomainModel.PurchaseStatus.Pending;
            purchase.TotalAmount = numTotal.Value;

            purchase.Items = _purchase?.Items ?? new List<PurchaseItem>();

            if (purchase.PurchaseId == Guid.Empty)
            {
                svc.Add(purchase);
                LoggerService.WriteInfo($"Purchase added: {purchase.PurchaseId}");
            }
            else
            {
                svc.Update(purchase);
                LoggerService.WriteInfo($"Purchase updated: {purchase.PurchaseId}");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                BtnOK_SetPurchaseValuesAndSave();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to save purchase: " + ex.ToString());
                MessageBox.Show(this, "Failed to save purchase: " + ex.Message, "Purchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; Close();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new AddProduct())
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        var item = dlg.SelectedItem;
                        if (item != null)
                        {
                            if (_purchase == null)
                                _purchase = new Purchase { Items = new List<PurchaseItem>() };
                            if (_purchase.Items == null)
                                _purchase.Items = new List<PurchaseItem>();

                            var exists = _purchase.Items.FirstOrDefault(x => x.ProductId == item.ProductId);
                            if (exists != null)
                            {
                                MessageBox.Show(this, "The selected product is already in the items list. Edit the existing item to change quantity.", "Duplicate Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                _purchase.Items.Add(item);
                                RefreshItemsGrid();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to add item: " + ex.ToString());
                MessageBox.Show(this, "Failed to add item: " + ex.Message, "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItems.SelectedRows.Count == 0)
                {
                    MessageBox.Show(this, "Please select an item to remove.", "Remove Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var row = dgvItems.SelectedRows[0];
                var pidObj = row.Cells["colPurchaseItemId"].Value;
                if (pidObj == null) return;

                if (!Guid.TryParse(pidObj.ToString(), out Guid pid)) return;

                if (_purchase?.Items != null)
                {
                    var toRemove = _purchase.Items.FirstOrDefault(x => x.PurchaseItemId == pid);
                    if (toRemove != null)
                    {
                        _purchase.Items.Remove(toRemove);
                        RefreshItemsGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to remove item: " + ex.ToString());
                MessageBox.Show(this, "Failed to remove item: " + ex.Message, "Remove Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshItemsGrid()
        {
            var rows = (_purchase?.Items ?? new List<PurchaseItem>()).Select(i => new
            {
                PurchaseItemId = i.PurchaseItemId,
                ProductId = i.ProductId,
                SKU = DAL.Implementations.ProductRepository.Current.SelectOne(i.ProductId)?.SKU ?? string.Empty,
                Name = DAL.Implementations.ProductRepository.Current.SelectOne(i.ProductId)?.Name ?? string.Empty,
                Quantity = i.Quantity,
                UnitCost = i.UnitCost,
                TotalCost = i.TotalCost ?? i.UnitCost * i.Quantity
            }).ToList();

            dgvItems.AutoGenerateColumns = false;
            dgvItems.DataSource = rows;

            var total = (_purchase?.Items ?? new List<PurchaseItem>()).Sum(x => x.TotalCost ?? x.UnitCost * x.Quantity);
            try
            {
                numTotal.Value = total;
            }
            catch
            {
                numTotal.Value = numTotal.Maximum;
            }
        }
    }
}
