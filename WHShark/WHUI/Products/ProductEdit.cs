using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainModel;
using DAL.Implementations;
using BLL.Services;
using Services.Services;

namespace WHUI.Products
{
    public partial class ProductEdit : Form
    {
        private Product _product;

        public ProductEdit()
        {
            InitializeComponent();
        }

        public void LoadProduct(Product product)
        {
            _product = product;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadBrands();
            LoadCategories();
            LoadBranches();

            if (_product != null)
            {
                ApplyProductToControls(_product);
            }
        }

        private void LoadBrands()
        {
            try
            {
                var brands = BrandRepository.Current.SelectAll()?.ToList() ?? new List<DomainModel.Brand>();
                cbBrand.DisplayMember = "Name";
                cbBrand.ValueMember = "BrandId";
                cbBrand.DataSource = brands;
            }
            catch (Exception ex)
            {
                Services.Services.LoggerService.WriteError($"Failed to load brands: {ex.Message}");
            }
        }

        private void LoadCategories()
        {
            try
            {
                var categories = CategoryRepository.Current.SelectAll()?.ToList() ?? new List<DomainModel.Category>();
                cbCategory.DisplayMember = "Name";
                cbCategory.ValueMember = "CategoryId";
                cbCategory.DataSource = categories;
            }
            catch (Exception ex)
            {
                Services.Services.LoggerService.WriteError($"Failed to load categories: {ex.Message}");
            }
        }

        private void LoadBranches()
        {
            try
            {
                var branches = BranchRepository.Current.SelectAll()?.ToList() ?? new List<DomainModel.Branch>();
                cbBranch.DisplayMember = "Name";
                cbBranch.ValueMember = "BranchId";
                cbBranch.DataSource = branches;
            }
            catch (Exception ex)
            {
                Services.Services.LoggerService.WriteError($"Failed to load branches: {ex.Message}");
            }
        }

        private void ApplyProductToControls(Product product)
        {
            if (product == null) return;

            txtSKU.Text = product.SKU;
            txtBarcode.Text = product.Barcode;
            txtName.Text = product.Name;
            txtDescription.Text = product.Description;

            if (product.Volume.HasValue) nudVolume.Value = product.Volume.Value; else nudVolume.Value = 0;
            txtVolumeUnit.Text = product.VolumeUnit;
            if (product.Weight.HasValue) nudWeight.Value = product.Weight.Value; else nudWeight.Value = 0;
            txtWeightUnit.Text = product.WeightUnit;
            nudCostPrice.Value = product.CostPrice;
            nudListPrice.Value = product.ListPrice;
            nudAlertStock.Value = product.AlertStock;

            try
            {
                if (cbBrand.Items.Count > 0)
                    cbBrand.SelectedValue = product.BrandId;
            }
            catch { }

            try
            {
                if (cbCategory.Items.Count > 0)
                    cbCategory.SelectedValue = product.CategoryId;
            }
            catch { }

            try
            {
                if (cbBranch.Items.Count > 0)
                    cbBranch.SelectedValue = product.BranchId;
            }
            catch { }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(this, "Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            try
            {
                var product = new Product();
                if (_product != null)
                {
                    product = _product;
                }

                product.SKU = txtSKU.Text?.Trim();
                product.Barcode = txtBarcode.Text?.Trim();
                product.Name = txtName.Text?.Trim();
                product.Description = txtDescription.Text?.Trim();

                try
                {
                    if (cbBrand.SelectedValue != null)
                        product.BrandId = (Guid)cbBrand.SelectedValue;
                }
                catch
                {
                    Guid.TryParse(cbBrand.SelectedValue?.ToString(), out Guid bId);
                    product.BrandId = bId;
                }

                try
                {
                    if (cbCategory.SelectedValue != null)
                        product.CategoryId = (Guid)cbCategory.SelectedValue;
                }
                catch
                {
                    Guid.TryParse(cbCategory.SelectedValue?.ToString(), out Guid cId);
                    product.CategoryId = cId;
                }

                try
                {
                    if (cbBranch.SelectedValue != null)
                        product.BranchId = (Guid)cbBranch.SelectedValue;
                }
                catch
                {
                    Guid.TryParse(cbBranch.SelectedValue?.ToString(), out Guid brId);
                    product.BranchId = brId;
                }

                product.Volume = nudVolume.Value == 0 ? (decimal?)null : nudVolume.Value;
                product.VolumeUnit = txtVolumeUnit.Text?.Trim();
                product.Weight = nudWeight.Value == 0 ? (decimal?)null : nudWeight.Value;
                product.WeightUnit = txtWeightUnit.Text?.Trim();
                product.CostPrice = nudCostPrice.Value;
                product.ListPrice = nudListPrice.Value;
                product.AlertStock = (int)nudAlertStock.Value;

                var svc = new ProductService();
                if (_product == null)
                {
                    svc.Add(product);
                    LoggerService.WriteInfo($"Product added: {product.Name}");
                }
                else
                {
                    svc.Update(product);
                    LoggerService.WriteInfo($"Product updated: {product.Name}");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError($"Failed to save product: {ex.Message}");
                MessageBox.Show(this, "Failed to save product: " + ex.Message, "Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
