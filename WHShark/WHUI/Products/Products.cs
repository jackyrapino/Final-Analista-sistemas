using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainModel;
using DAL.Implementations;
using Services.Services;
using BLL.Services;

namespace WHUI.Products
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                var svc = new ProductService();
                var products = svc.SelectAll()?.ToList() ?? new List<Product>();

                var gridItems = products.Select(p => new
                {
                    p.SKU,
                    p.Barcode,
                    p.Name,
                    p.Description,
                    p.BrandId,
                    p.CategoryId,
                    p.CostPrice,
                    p.ListPrice,
                    p.AlertStock,
                    p.BranchId,
                    ProductId = p.ProductId 
                }).ToList();

                dgv.DataSource = gridItems;
                lblStatus.Text = $"Loaded {gridItems.Count} product(s).";
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to load products: " + ex.Message);
                lblStatus.Text = "Failed to load products.";
                MessageBox.Show(this, "Failed to load products: " + ex.Message, "Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new ProductEdit())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            using (var frm = new Brands())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            using (var frm = new Categories())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
            {
                MessageBox.Show(this, "Please select a product to edit.", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var cellVal = dgv.CurrentRow.Cells["colProductId"].Value ?? dgv.CurrentRow.Cells["ProductId"].Value;
                if (cellVal == null)
                {
                    MessageBox.Show(this, "Selected row does not contain a product id.", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Guid.TryParse(cellVal.ToString(), out Guid productId))
                {
                    MessageBox.Show(this, "Invalid product id.", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var product = ProductRepository.Current.SelectOne(productId);
                if (product == null)
                {
                    MessageBox.Show(this, "Product not found.", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var frm = new ProductEdit())
                {
                    frm.LoadProduct(product);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadProducts();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteError($"Failed to open product edit: {ex.Message}");
                MessageBox.Show(this, "An error occurred while opening the product editor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
            {
                MessageBox.Show(this, "Please select a product to delete.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var cellVal = dgv.CurrentRow.Cells["colProductId"].Value ?? dgv.CurrentRow.Cells["ProductId"].Value;
                if (cellVal == null)
                {
                    MessageBox.Show(this, "Selected row does not contain a product id.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Guid.TryParse(cellVal.ToString(), out Guid productId))
                {
                    MessageBox.Show(this, "Invalid product id.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirm = MessageBox.Show(this, "Are you sure you want to delete the selected product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;

                var svc = new ProductService();
                svc.Delete(productId);

                LoggerService.WriteInfo($"Product deleted: {productId}");
                LoadProducts();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError($"Failed to delete product: {ex.Message}");
                MessageBox.Show(this, "Failed to delete product: " + ex.Message, "Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
