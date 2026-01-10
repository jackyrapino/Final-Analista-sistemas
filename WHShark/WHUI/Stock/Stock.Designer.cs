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
            pnlTop = new Panel();
            lblSite = new Label();
            cbSite = new ComboBox();
            btnAddStock = new Button();
            btnEditStock = new Button();
            btnDeleteStock = new Button();
            pnlAlertIndicator = new Panel();
            lblAlertLegend = new Label();
            txtSearch = new TextBox();
            btnClear = new Button();
            btnRefresh = new Button();
            dgv = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colBranch = new DataGridViewTextBoxColumn();
            lblLoading = new Label();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(lblSite);
            pnlTop.Controls.Add(cbSite);
            pnlTop.Controls.Add(btnAddStock);
            pnlTop.Controls.Add(btnEditStock);
            pnlTop.Controls.Add(btnDeleteStock);
            pnlTop.Controls.Add(pnlAlertIndicator);
            pnlTop.Controls.Add(lblAlertLegend);
            pnlTop.Controls.Add(txtSearch);
            pnlTop.Controls.Add(btnClear);
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(8);
            pnlTop.Size = new Size(1110, 52);
            pnlTop.TabIndex = 0;
            // 
            // lblSite
            // 
            lblSite.Anchor = AnchorStyles.Left;
            lblSite.AutoSize = true;
            lblSite.Location = new Point(8, 16);
            lblSite.Name = "lblSite";
            lblSite.Size = new Size(37, 20);
            lblSite.TabIndex = 0;
            lblSite.Text = "Site:";
            // 
            // cbSite
            // 
            cbSite.Anchor = AnchorStyles.Left;
            cbSite.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSite.Location = new Point(56, 14);
            cbSite.Name = "cbSite";
            cbSite.Size = new Size(180, 28);
            cbSite.TabIndex = 1;
            // 
            // btnAddStock
            // 
            btnAddStock.Location = new Point(250, 14);
            btnAddStock.Name = "btnAddStock";
            btnAddStock.Size = new Size(88, 28);
            btnAddStock.TabIndex = 2;
            btnAddStock.Text = "Add";
            btnAddStock.UseVisualStyleBackColor = true;
            // 
            // btnEditStock
            // 
            btnEditStock.Location = new Point(344, 14);
            btnEditStock.Name = "btnEditStock";
            btnEditStock.Size = new Size(88, 28);
            btnEditStock.TabIndex = 3;
            btnEditStock.Text = "Edit";
            btnEditStock.UseVisualStyleBackColor = true;
            // 
            // btnDeleteStock
            // 
            btnDeleteStock.Location = new Point(438, 14);
            btnDeleteStock.Name = "btnDeleteStock";
            btnDeleteStock.Size = new Size(88, 28);
            btnDeleteStock.TabIndex = 4;
            btnDeleteStock.Text = "Delete";
            btnDeleteStock.UseVisualStyleBackColor = true;
            // 
            // pnlAlertIndicator
            // 
            pnlAlertIndicator.BackColor = Color.Red;
            pnlAlertIndicator.BorderStyle = BorderStyle.FixedSingle;
            pnlAlertIndicator.Location = new Point(538, 18);
            pnlAlertIndicator.Name = "pnlAlertIndicator";
            pnlAlertIndicator.Size = new Size(12, 12);
            pnlAlertIndicator.TabIndex = 8;
            // 
            // lblAlertLegend
            // 
            lblAlertLegend.Location = new Point(556, 12);
            lblAlertLegend.Name = "lblAlertLegend";
            lblAlertLegend.Size = new Size(140, 24);
            lblAlertLegend.TabIndex = 9;
            lblAlertLegend.Text = "Red = low stock";
            lblAlertLegend.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Location = new Point(700, 11);
            txtSearch.Name = "txtSearch";
            // PlaceholderText not available in .NET Framework 4.7.2 - skip setting
            txtSearch.Size = new Size(180, 27);
            txtSearch.TabIndex = 5;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.Location = new Point(886, 11);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(88, 30);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Location = new Point(984, 11);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(88, 30);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersHeight = 29;
            dgv.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colPrice, colQty, colBranch });
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 52);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 51;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(1110, 461);
            dgv.TabIndex = 5;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.MinimumWidth = 60;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Product Name";
            colName.MinimumWidth = 120;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "List Price";
            colPrice.MinimumWidth = 90;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // colQty
            // 
            colQty.HeaderText = "Quantity";
            colQty.MinimumWidth = 80;
            colQty.Name = "colQty";
            colQty.ReadOnly = true;
            // 
            // colBranch
            // 
            colBranch.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBranch.DataPropertyName = "BranchName";
            colBranch.HeaderText = "Branch";
            colBranch.MinimumWidth = 6;
            colBranch.Name = "colBranch";
            colBranch.ReadOnly = true;
            // 
            // lblLoading
            // 
            lblLoading.AutoSize = true;
            lblLoading.Dock = DockStyle.Bottom;
            lblLoading.Location = new Point(0, 513);
            lblLoading.Name = "lblLoading";
            lblLoading.Padding = new Padding(8);
            lblLoading.Size = new Size(16, 36);
            lblLoading.TabIndex = 6;
            // 
            // Stock
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1110, 549);
            Controls.Add(dgv);
            Controls.Add(pnlTop);
            Controls.Add(lblLoading);
            Name = "Stock";
            Text = "Stock";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
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