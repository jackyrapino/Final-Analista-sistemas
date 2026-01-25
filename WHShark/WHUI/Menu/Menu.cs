using System;
using System.Drawing;
using System.Windows.Forms;

namespace WHUI.Menu
{
    public partial class Menu : Form
    {
        private Form activeForm = null;

        public Menu()
        {
            InitializeComponent();
        }

        private void ShowChildForm(Form child)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            activeForm = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            panelContent.Controls.Clear();
            panelContent.Controls.Add(child);
            panelContent.Tag = child;
            child.BringToFront();
            child.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (var login = new WHUI.Login.LogIn())
            {
                var result = login.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Login successful for another user: show the menu again (could refresh user data here)
                    this.Show();
                }
                else
                {
                    // Login canceled or failed: close the menu to exit application
                    this.Close();
                }
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void tlpButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ShowChildForm(new WHUI.Products.Products());
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            ShowChildForm(new WHUI.Customers.Customers());
        }

        private void btnBranches_Click(object sender, EventArgs e)
        {
            // Open Branches form inside panelContent using the correct namespace
            ShowChildForm(new WHUI.Branches.Branches());
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            ShowChildForm(new WHUI.Customers.Customers());
        }

        private void btnStockMovements_Click(object sender, EventArgs e)
        {
            ShowChildForm(new WHUI.StockMovements.StockMovements());
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            ShowChildForm(new WHUI.Stock.Stock());
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            ShowChildForm(new WHUI.Sales.Sales());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ShowChildForm(new WHUI.Reports.Reports());
        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
            ShowChildForm(new WHUI.Purchases.Purchases());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ShowChildForm(new WHUI.Users.Users());
        }
    }
}
