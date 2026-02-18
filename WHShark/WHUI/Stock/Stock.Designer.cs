using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WHUI.Stock
{
    partial class Stock
    {
     
        private System.ComponentModel.IContainer components = null;

       
        // Clean up any resources being used
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblSite = new System.Windows.Forms.Label();
            this.cbSite = new System.Windows.Forms.ComboBox();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.btnEditStock = new System.Windows.Forms.Button();
            this.btnDeleteStock = new System.Windows.Forms.Button();
            this.pnlAlertIndicator = new System.Windows.Forms.Panel();
            this.lblAlertLegend = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLoading = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblSite);
            this.pnlTop.Controls.Add(this.cbSite);
            this.pnlTop.Controls.Add(this.btnAddStock);
            this.pnlTop.Controls.Add(this.btnEditStock);
            this.pnlTop.Controls.Add(this.btnDeleteStock);
            this.pnlTop.Controls.Add(this.pnlAlertIndicator);
            this.pnlTop.Controls.Add(this.lblAlertLegend);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.btnClear);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pnlTop.Size = new System.Drawing.Size(1110, 42);
            this.pnlTop.TabIndex = 0;
            // 
            // lblSite
            // 
            this.lblSite.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSite.AutoSize = true;
            this.lblSite.Location = new System.Drawing.Point(8, 13);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(33, 16);
            this.lblSite.TabIndex = 0;
            this.lblSite.Text = "Site:";
            // 
            // cbSite
            // 
            this.cbSite.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSite.Location = new System.Drawing.Point(56, 11);
            this.cbSite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSite.Name = "cbSite";
            this.cbSite.Size = new System.Drawing.Size(180, 24);
            this.cbSite.TabIndex = 1;
            // 
            // btnAddStock
            // 
            this.btnAddStock.Location = new System.Drawing.Point(250, 11);
            this.btnAddStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(88, 22);
            this.btnAddStock.TabIndex = 2;
            this.btnAddStock.Text = "Add";
            this.btnAddStock.UseVisualStyleBackColor = true;
            // 
            // btnEditStock
            // 
            this.btnEditStock.Location = new System.Drawing.Point(344, 11);
            this.btnEditStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditStock.Name = "btnEditStock";
            this.btnEditStock.Size = new System.Drawing.Size(88, 22);
            this.btnEditStock.TabIndex = 3;
            this.btnEditStock.Text = "Edit";
            this.btnEditStock.UseVisualStyleBackColor = true;
            // 
            // btnDeleteStock
            // 
            this.btnDeleteStock.Location = new System.Drawing.Point(438, 11);
            this.btnDeleteStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteStock.Name = "btnDeleteStock";
            this.btnDeleteStock.Size = new System.Drawing.Size(88, 22);
            this.btnDeleteStock.TabIndex = 4;
            this.btnDeleteStock.Text = "Delete";
            this.btnDeleteStock.UseVisualStyleBackColor = true;
            // 
            // pnlAlertIndicator
            // 
            this.pnlAlertIndicator.BackColor = System.Drawing.Color.Red;
            this.pnlAlertIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlertIndicator.Location = new System.Drawing.Point(538, 14);
            this.pnlAlertIndicator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlAlertIndicator.Name = "pnlAlertIndicator";
            this.pnlAlertIndicator.Size = new System.Drawing.Size(12, 10);
            this.pnlAlertIndicator.TabIndex = 8;
            // 
            // lblAlertLegend
            // 
            this.lblAlertLegend.Location = new System.Drawing.Point(556, 10);
            this.lblAlertLegend.Name = "lblAlertLegend";
            this.lblAlertLegend.Size = new System.Drawing.Size(140, 19);
            this.lblAlertLegend.TabIndex = 9;
            this.lblAlertLegend.Text = "Red = low stock";
            this.lblAlertLegend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(700, 9);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(180, 22);
            this.txtSearch.TabIndex = 5;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(886, 9);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 24);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(984, 9);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(88, 24);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeight = 29;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colPrice,
            this.colQty,
            this.colBranch});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 42);
            this.dgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1110, 369);
            this.dgv.TabIndex = 5;
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.MinimumWidth = 60;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Product Name";
            this.colName.MinimumWidth = 120;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "List Price";
            this.colPrice.MinimumWidth = 90;
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colQty
            // 
            this.colQty.HeaderText = "Quantity";
            this.colQty.MinimumWidth = 80;
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            // 
            // colBranch
            // 
            this.colBranch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBranch.DataPropertyName = "BranchName";
            this.colBranch.HeaderText = "Branch";
            this.colBranch.MinimumWidth = 6;
            this.colBranch.Name = "colBranch";
            this.colBranch.ReadOnly = true;
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLoading.Location = new System.Drawing.Point(0, 411);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.lblLoading.Size = new System.Drawing.Size(16, 28);
            this.lblLoading.TabIndex = 6;
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 439);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.lblLoading);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Stock";
            this.Text = "Stock";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.ComboBox cbSite;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.Button btnEditStock;
        private System.Windows.Forms.Button btnDeleteStock;
        private System.Windows.Forms.Panel pnlAlertIndicator; 
        private System.Windows.Forms.Label lblAlertLegend;    
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBranch;
    }
}