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
                    // set selections using navigation properties
                    cbProduct.SelectedValue = _stock.Product?.ProductId ?? Guid.Empty;
                    cbBranch.SelectedValue = _stock.Branch?.BranchId ?? Guid.Empty;
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
                Services.Services.LoggerService.WriteError(ex.Source);
                MessageBox.Show(this, "Failed to load lookup data: " + ex.Message, "Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DomainModel.Product ProdFromSelectedValue(object val)
        {
            try
            {
                if (val == null) return null;
                var id = val is Guid g ? g : Guid.Parse(val.ToString());
                return DAL.Implementations.ProductRepository.Current.SelectOne(id);
            }
            catch
            {
                return null;
            }
        }

        private DomainModel.Branch BranchFromSelectedValue(object val)
        {
            try
            {
                if (val == null) return null;
                var id = val is Guid g ? g : Guid.Parse(val.ToString());
                return DAL.Implementations.BranchRepository.Current.SelectOne(id);
            }
            catch
            {
                return null;
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

                var selectedProduct = cbProduct.SelectedItem as DomainModel.Product ?? ProdFromSelectedValue(cbProduct.SelectedValue);
                var selectedBranch = cbBranch.SelectedItem as DomainModel.Branch ?? BranchFromSelectedValue(cbBranch.SelectedValue);

                if (selectedProduct == null || selectedBranch == null)
                {
                    MessageBox.Show(this, "Invalid product or branch selection.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_stock == null)
                {
                    var newStock = new DomainModel.Stock
                    {
                        StockId = Guid.Empty,
                        Product = selectedProduct,
                        Branch = selectedBranch,
                        Quantity = (int)nudQuantity.Value,
                        LastUpdated = DateTime.Now
                    };

                    svc.Add(newStock);
                    Services.Services.LoggerService.WriteInfo($"Stock added: product {newStock.Product.ProductId} at branch {newStock.Branch.BranchId}");
                }
                else
                {
                    _stock.Product = selectedProduct;
                    _stock.Branch = selectedBranch;
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
                Services.Services.LoggerService.WriteError(ex.Source);
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
