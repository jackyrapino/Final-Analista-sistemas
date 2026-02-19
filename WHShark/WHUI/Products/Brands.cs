using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainModel;
using BLL.Services;
using Services.Services;
using DAL.Implementations;
using BLL.Services.Contracts;

namespace WHUI.Products
{
    public partial class Brands : Form
    {
        public Brands()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(this, "Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            var brand = new Brand
            {
                Name = txtName.Text.Trim(),
                Description = txtDescription.Text?.Trim(),
                CreatedAt = DateTime.Now
            };

            try
            {
                var brandService = new BrandService(BrandRepository.Current);
                brandService.Add(brand);

                LoggerService.WriteInfo($"Brand created: {brand.Name}");
                MessageBox.Show(this, "Brand saved.", "Brands", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError($"Failed to save brand: {ex.Message}");
                MessageBox.Show(this, "Failed saving brand: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
