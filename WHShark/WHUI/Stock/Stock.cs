using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainModel;
using BLL.Services;
using Services.Services;

namespace WHUI.Stock
{
    public partial class Stock : Form
    {
        private bool _populatingSites;

        public Stock()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PopulateSites();
            try
            {
                LoadStock();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError(ex.ToString());
            }
        }

        private void PopulateSites()
        {
            try
            {
                _populatingSites = true;

                var branchSvc = new BranchService();
                var branches = branchSvc.SelectAll().ToList();

                var all = new Branch { BranchId = Guid.Empty, Name = "All branches" };
                branches.Insert(0, all);

                cbSite.DisplayMember = "Name";
                cbSite.ValueMember = "BranchId";
                cbSite.DataSource = branches;

                cbSite.SelectedValue = Guid.Empty;
            }
            catch (Exception ex)
            {
                LoggerService.WriteError(ex.ToString());
            }
            finally
            {
                _populatingSites = false;
            }
        }

        private void LoadStock()
        {
            try
            {
                var svc = new StockService();
                var items = svc.SelectAll().ToList();
                var rows = items.Select(s => new
                {
                    StockId = s.StockId,
                    ProductName = s.Product?.Name ?? string.Empty,
                    ListPrice = s.Product != null ? (decimal?)s.Product.ListPrice : null,
                    Quantity = s.Quantity,
                    BranchName = s.Branch?.Name ?? string.Empty,
                    Product = s.Product,
                    Branch = s.Branch,
                    LastUpdated = s.LastUpdated
                }).ToList();

                dgv.AutoGenerateColumns = false;
                colId.DataPropertyName = "StockId";
                colName.DataPropertyName = "ProductName";
                colPrice.DataPropertyName = "ListPrice";
                colQty.DataPropertyName = "Quantity";
                colBranch.DataPropertyName = "BranchName";

                dgv.DataSource = rows;

                for (int i = 0; i < items.Count && i < dgv.Rows.Count; i++)
                {
                    try
                    {
                        var stock = items[i];
                        if (stock.Product != null && stock.Product.AlertStock >= 0 && stock.Quantity <= stock.Product.AlertStock)
                        {
                            dgv.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        }
                        else
                        {
                            dgv.Rows[i].DefaultCellStyle.BackColor = dgv.DefaultCellStyle.BackColor;
                            dgv.Rows[i].DefaultCellStyle.ForeColor = dgv.DefaultCellStyle.ForeColor;
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerService.WriteError("Failed loading alert for stock row: " + ex.ToString());
                    }
                }

                lblLoading.Text = $"Loaded {items.Count} stock item(s).";
            }
            catch (Exception ex)
            {
                LoggerService.WriteError(ex.ToString());
                MessageBox.Show(this, "Failed to load stock: " + ex.Message, "Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStockByBranch(Guid branchId)
        {
            try
            {
                var svc = new StockService();
                var items = svc.StockByBranch(branchId).ToList();

                var rows = items.Select(s => new
                {
                    StockId = s.StockId,
                    ProductName = s.Product?.Name ?? string.Empty,
                    ListPrice = s.Product != null ? (decimal?)s.Product.ListPrice : null,
                    Quantity = s.Quantity,
                    BranchName = s.Branch?.Name ?? string.Empty,
                    Product = s.Product,
                    Branch = s.Branch,
                    LastUpdated = s.LastUpdated
                }).ToList();

                dgv.AutoGenerateColumns = false;
                colId.DataPropertyName = "StockId";
                colName.DataPropertyName = "ProductName";
                colPrice.DataPropertyName = "ListPrice";
                colQty.DataPropertyName = "Quantity";
                colBranch.DataPropertyName = "BranchName";

                dgv.DataSource = rows;

                for (int i = 0; i < items.Count && i < dgv.Rows.Count; i++)
                {
                    try
                    {
                        var stock = items[i];
                        if (stock.Product != null && stock.Product.AlertStock >= 0 && stock.Quantity <= stock.Product.AlertStock)
                        {
                            dgv.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        }
                        else
                        {
                            dgv.Rows[i].DefaultCellStyle.BackColor = dgv.DefaultCellStyle.BackColor;
                            dgv.Rows[i].DefaultCellStyle.ForeColor = dgv.DefaultCellStyle.ForeColor;
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerService.WriteError("Failed loading alert for stock row: " + ex.ToString());
                    }
                }

                lblLoading.Text = $"Loaded {items.Count} stock item(s) for branch.";
            }
            catch (Exception ex)
            {
                LoggerService.WriteError(ex.ToString());
                MessageBox.Show(this, "Failed to load stock by branch: " + ex.Message, "Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_populatingSites) return;

                if (cbSite.SelectedValue == null)
                {
                    LoadStock();
                    return;
                }

                Guid selectedId;
                if (cbSite.SelectedValue is Guid g)
                    selectedId = g;
                else if (!Guid.TryParse(cbSite.SelectedValue.ToString(), out selectedId))
                {
                    LoadStock();
                    return;
                }

                if (selectedId == Guid.Empty)
                    LoadStock();
                else
                    LoadStockByBranch(selectedId);
            }
            catch (Exception ex)
            {
                LoggerService.WriteError(ex.ToString());
            }
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new StockEdit())
                {
                    dlg.LoadStock(null);
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        cbSite_SelectedIndexChanged(cbSite, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteError(ex.ToString());
                MessageBox.Show(this, "Failed to open stock editor: " + ex.Message, "Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditStock_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;

            try
            {
                var stockbyproducto = dgv.CurrentRow.DataBoundItem as DomainModel.Stock;
                DomainModel.Stock stock = null;

                if (stockbyproducto != null)
                {
                    stock = stockbyproducto;
                }
                else
                {
                    var cell = dgv.CurrentRow.Cells["colId"]?.Value ?? dgv.CurrentRow.Cells[0]?.Value;
                    if (cell == null) return;
                    if (!Guid.TryParse(cell.ToString(), out Guid id)) return;

                    var svc = new StockService();
                    stock = svc.SelectOne(id);
                    if (stock == null) return;
                }

                using (var dlg = new StockEdit())
                {
                    dlg.LoadStock(stock);
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        cbSite_SelectedIndexChanged(cbSite, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteError(ex.ToString());
                MessageBox.Show(this, "Failed to open stock editor: " + ex.Message, "Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteStock_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;

            try
            {
                var bound = dgv.CurrentRow.DataBoundItem as DomainModel.Stock;
                Guid id;
                if (bound != null)
                {
                    id = bound.StockId;
                }
                else
                {
                    var cell = dgv.CurrentRow.Cells["colId"]?.Value ?? dgv.CurrentRow.Cells[0]?.Value;
                    if (cell == null) return;
                    if (!Guid.TryParse(cell.ToString(), out id)) return;
                }

                var confirm = MessageBox.Show(this, "Are you sure you want to delete the selected stock record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;

                var svc = new StockService();
                svc.Delete(id);
                LoggerService.WriteInfo($"Stock deleted: {id}");

                cbSite_SelectedIndexChanged(cbSite, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                LoggerService.WriteError(ex.ToString());
                MessageBox.Show(this, "Failed to delete stock: " + ex.Message, "Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
