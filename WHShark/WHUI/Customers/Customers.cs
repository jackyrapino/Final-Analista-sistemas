using System;
using System.Linq;
using System.Windows.Forms;
using DomainModel;
using BLL.Services;
using Services.Services;

namespace WHUI.Customers
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                var svc = new CustomerService();
                var items = svc.SelectAll()?.ToList() ?? new System.Collections.Generic.List<Customer>();
                dgv.DataSource = items;
                lblStatus.Text = $"Loaded {items.Count} customer(s).";
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to load customers: " + ex.Message);
                MessageBox.Show(this, "Failed to load customers: " + ex.Message, "Customers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var dlg = new CustomersEdit())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadCustomers();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;
            var cell = dgv.CurrentRow.Cells["colCustomerId"].Value;
            if (cell == null) return;
            if (!Guid.TryParse(cell.ToString(), out Guid id)) return;

            try
            {
                var svc = new CustomerService();
                var customer = svc.SelectOne(id);
                if (customer == null) return;

                using (var dlg = new CustomersEdit())
                {
                    dlg.LoadCustomer(customer);
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadCustomers();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to open customer edit: " + ex.Message);
                MessageBox.Show(this, "Failed to open customer editor: " + ex.Message, "Customers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;
            var cell = dgv.CurrentRow.Cells["colCustomerId"].Value;
            if (cell == null) return;
            if (!Guid.TryParse(cell.ToString(), out Guid id)) return;

            var confirm = MessageBox.Show(this, "Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var svc = new CustomerService();
                svc.Delete(id);
                LoggerService.WriteInfo($"Customer deleted: {id}");
                LoadCustomers();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to delete customer: " + ex.Message);
                MessageBox.Show(this, "Failed to delete customer: " + ex.Message, "Customers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
