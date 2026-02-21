using System;
using System.Drawing;
using System.Windows.Forms;
using Services.Services;
using System.Threading.Tasks;

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

        private async void btnBackup_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select destination folder for database backups";
                dlg.ShowNewFolderButton = true;

                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                var folder = dlg.SelectedPath;

                try
                {
                    // Run backup off UI thread
                    var result = await Task.Run(() => BackupService.BackupBoth(folder));

                    // Log and inform user
                    LoggerService.WriteInfo($"Backup completed. Business: {result.BusinessBackupPath}, Auth: {result.AuthBackupPath}", Session.CurrentUser?.Name ?? string.Empty);

                    MessageBox.Show(this, $"Backup completed:\nBusiness: {result.BusinessBackupPath}\nAuth: {result.AuthBackupPath}", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Log error and show message
                    LoggerService.WriteError("Backup failed: " + ex.Message, Session.CurrentUser?.Name ?? string.Empty);
                    MessageBox.Show(this, "Backup failed: " + ex.Message, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnRestore_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select folder that contains the .bak files to restore";
                dlg.ShowNewFolderButton = false;

                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                var folder = dlg.SelectedPath;

                // Confirm because restore will replace databases
                var confirm = MessageBox.Show(this, "Restoring will replace the current databases. Are you sure you want to continue?", "Confirm Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes)
                    return;

                try
                {
                    // Run restore off UI thread (RestoreDatabase will pick the two most recent .bak files and call RestoreBoth)
                    await Task.Run(() => BackupService.RestoreDatabase(folder));

                    LoggerService.WriteInfo($"Restore completed from folder: {folder}", Session.CurrentUser?.Name ?? string.Empty);
                    MessageBox.Show(this, "Restore completed successfully.", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    LoggerService.WriteError("Restore failed: " + ex.Message, Session.CurrentUser?.Name ?? string.Empty);
                    MessageBox.Show(this, "Restore failed: " + ex.Message, "Restore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.CurrentUser = null;

            if (activeForm != null)
            {
                try { activeForm.Close(); activeForm.Dispose(); }
                catch { }
                activeForm = null;
            }
            this.Hide();
            using (var login = new WHUI.Login.LogIn())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    // Logged in again
                    this.Show();
                    return;
                }
            }

            this.Close();
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

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            ShowChildForm(new WHUI.Customers.Customers());
        }

        private void btnBranches_Click(object sender, EventArgs e)
        {
            ShowChildForm(new WHUI.Branches.Branches());
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            ShowChildForm(new WHUI.Suppliers.Suppliers());
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
