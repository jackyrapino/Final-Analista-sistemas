using System;
using System.Linq;
using System.Windows.Forms;
using BLL.Services;
using Services.Services;

namespace WHUI.Stock
{
    public partial class StockEdit : Form
    {
        private DomainModel.Stock _stock;

        public StockEdit()
        {
            InitializeComponent();
        }

        public void LoadStock(DomainModel.Stock stock)
        {
            _stock = stock;

            // Load products and branches into comboboxes
            try
            {
                var prodSvc = new ProductService();
                var prods = prodSvc.SelectAll()?.ToList() ?? new System.Collections.Generic.List<DomainModel.Product>();
                cbProduct.DisplayMember = "Name";
                cbProduct.ValueMember = "ProductId";
                cbProduct.DataSource = prods;

                var branchSvc = new BranchService();
                var branches = branchSvc.SelectAll()?.ToList() ?? new System.Collections.Generic.List<DomainModel.Branch>();
                cbBranch.DisplayMember = "Name";
                cbBranch.ValueMember = "BranchId";
                cbBranch.DataSource = branches;

                if (_stock != null)
                {
                    // set selections
                    cbProduct.SelectedValue = _stock.ProductId;
                    cbBranch.SelectedValue = _stock.BranchId;
                    nudQuantity.Value = _stock.Quantity;

                    this.Text = "Edit Stock";
                    btnOK.Text = "Save";
                }
                else
                {
                    this.Text = "Add Stock";
                    btnOK.Text = "OK";
                    if (cbProduct.Items.Count > 0) cbProduct.SelectedIndex = 0;
                    if (cbBranch.Items.Count > 0) cbBranch.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Services.Services.LoggerService.WriteError(ex.Message);
                MessageBox.Show(this, "Failed to load lookup data: " + ex.Message, "Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnOK_Click(object sender, EventArgs e)
        {

            if (cbProduct.SelectedValue == null || cbBranch.SelectedValue == null)
            {
                MessageBox.Show(this, "Please select product and branch.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var svc = new StockService();
                if (_stock == null)
                {
                    var newStock = new DomainModel.Stock
                    {
                        StockId = Guid.Empty,
                        ProductId = (Guid)cbProduct.SelectedValue,
                        BranchId = (Guid)cbBranch.SelectedValue,
                        Quantity = (int)nudQuantity.Value,
                        LastUpdated = DateTime.Now
                    };

                    svc.Add(newStock);
                    Services.Services.LoggerService.WriteInfo($"Stock added: product {newStock.ProductId} at branch {newStock.BranchId}");
                }
                else
                {
                    _stock.ProductId = (Guid)cbProduct.SelectedValue;
                    _stock.BranchId = (Guid)cbBranch.SelectedValue;
                    _stock.Quantity = (int)nudQuantity.Value;
                    _stock.LastUpdated = DateTime.Now;

                    svc.Update(_stock);
                    Services.Services.LoggerService.WriteInfo($"Stock updated: {_stock.StockId}");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Services.Services.LoggerService.WriteError(ex.Message);
                MessageBox.Show(this, "Failed to save stock: " + ex.Message, "Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
