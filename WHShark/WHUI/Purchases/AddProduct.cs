using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DAL.Implementations;
using DomainModel;
using WHUI.Products;
using BLL.Services;
using Services.Services;

namespace WHUI.Purchases
{
    public partial class AddProduct : Form
    {
        public PurchaseItem SelectedItem { get; private set; }

        public AddProduct()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts(string filter = null)
        {
            try
            {
                var svc = new ProductService();
                var prods = svc.SelectAll()?.ToList() ?? new List<Product>();
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    prods = prods.Where(p => (p.Name ?? string.Empty).IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 || (p.SKU ?? string.Empty).IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }

                var rows = prods.Select(p => new
                {
                    ProductId = p.ProductId,
                    SKU = p.SKU,
                    Name = p.Name,
                    CostPrice = p.CostPrice
                }).ToList();

                dgvProducts.AutoGenerateColumns = false;
                dgvProducts.DataSource = rows;
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to load products for add product dialog: " + ex.ToString());
                MessageBox.Show(this, "Failed to load products: " + ex.Message, "Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            LoadProducts(txtSearch.Text?.Trim());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text?.Trim());
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new WHUI.Products.ProductEdit())
                {
                    dlg.LoadProduct(null);
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadProducts(txtSearch.Text?.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to open product editor: " + ex.ToString());
                MessageBox.Show(this, "Failed to open product editor: " + ex.Message, "Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Please select a product to add.", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var row = dgvProducts.SelectedRows[0];
                var prodId = (Guid)row.Cells["colProductId"].Value;

                var qty = (int)nudQuantity.Value;

                SelectedItem = new PurchaseItem
                {
                    PurchaseItemId = Guid.NewGuid(),
                    ProductId = prodId,
                    Quantity = qty,
                    UnitCost = DAL.Implementations.ProductRepository.Current.SelectOne(prodId)?.CostPrice ?? 0,
                    TotalCost = (DAL.Implementations.ProductRepository.Current.SelectOne(prodId)?.CostPrice ?? 0) * qty
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to add product: " + ex.ToString());
                MessageBox.Show(this, "Failed to add product: " + ex.Message, "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {
            btnAdd_Click(sender, EventArgs.Empty);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; Close();
        }
    }
}
