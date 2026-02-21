using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DomainModel;
using BLL.Services;
using Services.Services;

namespace WHUI.Suppliers
{
    public partial class Suppliers : Form
    {
        public Suppliers()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            try
            {
                var svc = new SupplierService();
                var items = svc.SelectAll()?.ToList() ?? new List<Supplier>();
                dgv.DataSource = items;
                lblStatus.Text = $"Loaded {items.Count} supplier(s).";
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to load suppliers: " + ex.Message);
                MessageBox.Show(this, "Failed to load suppliers: " + ex.Message, "Suppliers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;

            // Try to get bound Supplier object first
            var item = dgv.CurrentRow.DataBoundItem as Supplier;
            Supplier supplier = null;

            try
            {
                if (item != null)
                {
                    supplier = item;
                }
                else
                {
                    var cell = dgv.CurrentRow.Cells["SupplierId"]?.Value ?? dgv.CurrentRow.Cells[0]?.Value;
                    if (cell == null) return;
                    if (!Guid.TryParse(cell.ToString(), out Guid id)) return;

                    var svc = new SupplierService();
                    supplier = svc.SelectOne(id);
                    if (supplier == null) return;
                }

                using (var dlg = new SuppliersEdit())
                {
                    dlg.LoadSupplier(supplier);
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadSuppliers();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to open supplier edit: " + ex.Message);
                MessageBox.Show(this, "Failed to open supplier editor: " + ex.Message, "Suppliers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var dlg = new SuppliersEdit())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadSuppliers();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;

            var item = dgv.CurrentRow.DataBoundItem as Supplier;
            Guid id;
            if (item != null)
            {
                id = item.SupplierId;
            }
            else
            {
                var cell = dgv.CurrentRow.Cells["SupplierId"]?.Value ?? dgv.CurrentRow.Cells[0]?.Value;
                if (cell == null) return;
                if (!Guid.TryParse(cell.ToString(), out id)) return;
            }

            var confirm = MessageBox.Show(this, "Are you sure you want to delete this supplier?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var svc = new SupplierService();
                svc.Delete(id);
                LoggerService.WriteInfo($"Supplier deleted: {id}");
                LoadSuppliers();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to delete supplier: " + ex.Message);
                MessageBox.Show(this, "Failed to delete supplier: " + ex.Message, "Suppliers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
