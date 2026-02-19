using System;
using System.Drawing;
using System.Windows.Forms;

namespace WHUI.Products
{
    partial class Products
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Products));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAddBrand = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlertStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrandId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Controls.Add(this.btnDelete);
            this.pnlTop.Controls.Add(this.btnEdit);
            this.pnlTop.Controls.Add(this.btnAdd);
            this.pnlTop.Controls.Add(this.btnAddBrand);
            this.pnlTop.Controls.Add(this.btnAddCategory);
            this.pnlTop.Controls.Add(this.btnClear);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Name = "pnlTop";
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddBrand
            // 
            resources.ApplyResources(this.btnAddBrand, "btnAddBrand");
            this.btnAddBrand.Name = "btnAddBrand";
            this.btnAddBrand.UseVisualStyleBackColor = true;
            this.btnAddBrand.Click += new System.EventHandler(this.btnAddBrand_Click);
            // 
            // btnAddCategory
            // 
            resources.ApplyResources(this.btnAddCategory, "btnAddCategory");
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.Name = "txtSearch";
            // 
            // dgv
            // 
            resources.ApplyResources(this.dgv, "dgv");
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colSKU,
            this.colBarcode,
            this.colName,
            this.colDescription,
            this.colListPrice,
            this.colCostPrice,
            this.colAlertStock,
            this.colBrandId,
            this.colCategoryId});
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // colProductId
            // 
            this.colProductId.DataPropertyName = "ProductId";
            resources.ApplyResources(this.colProductId, "colProductId");
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            // 
            // colSKU
            // 
            this.colSKU.DataPropertyName = "SKU";
            resources.ApplyResources(this.colSKU, "colSKU");
            this.colSKU.Name = "colSKU";
            this.colSKU.ReadOnly = true;
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            resources.ApplyResources(this.colBarcode, "colBarcode");
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            resources.ApplyResources(this.colName, "colName");
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            resources.ApplyResources(this.colDescription, "colDescription");
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colListPrice
            // 
            this.colListPrice.DataPropertyName = "ListPrice";
            resources.ApplyResources(this.colListPrice, "colListPrice");
            this.colListPrice.Name = "colListPrice";
            this.colListPrice.ReadOnly = true;
            // 
            // colCostPrice
            // 
            this.colCostPrice.DataPropertyName = "CostPrice";
            resources.ApplyResources(this.colCostPrice, "colCostPrice");
            this.colCostPrice.Name = "colCostPrice";
            this.colCostPrice.ReadOnly = true;
            // 
            // colAlertStock
            // 
            this.colAlertStock.DataPropertyName = "AlertStock";
            resources.ApplyResources(this.colAlertStock, "colAlertStock");
            this.colAlertStock.Name = "colAlertStock";
            this.colAlertStock.ReadOnly = true;
            // 
            // colBrandId
            // 
            this.colBrandId.DataPropertyName = "BrandId";
            resources.ApplyResources(this.colBrandId, "colBrandId");
            this.colBrandId.Name = "colBrandId";
            this.colBrandId.ReadOnly = true;
            // 
            // colCategoryId
            // 
            this.colCategoryId.DataPropertyName = "CategoryId";
            resources.ApplyResources(this.colCategoryId, "colCategoryId");
            this.colCategoryId.Name = "colCategoryId";
            this.colCategoryId.ReadOnly = true;
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
            // 
            // Products
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.lblStatus);
            this.Name = "Products";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlertStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrandId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryId;
        private System.Windows.Forms.Button btnAddBrand;
        private System.Windows.Forms.Button btnAddCategory;

    }
}