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

namespace WHUI.Products
{
    public partial class Categories : Form
    {
        public Categories()
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

            var category = new Category
            {
                Name = txtName.Text.Trim(),
                CreatedAt = DateTime.Now
            };

            try
            {
                var categoryService = new CategoryService(CategoryRepository.Current);
                categoryService.Add(category);

                LoggerService.WriteInfo($"Category created: {category.Name}");
                MessageBox.Show(this, "Category saved.", "Categories", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError($"Failed to save category: {ex.Message}");
                MessageBox.Show(this, "Failed saving category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
