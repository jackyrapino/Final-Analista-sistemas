using System;
using System.Drawing;
using System.Windows.Forms;

namespace WHUI.Purchases
{
    partial class PurchasesEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.numTotal = new System.Windows.Forms.NumericUpDown();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colPurchaseItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlItemsTop = new System.Windows.Forms.Panel();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.txtItemSearch = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotal)).BeginInit();
            this.grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.pnlItemsTop.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblSupplier, 0, 0);
            this.tlpMain.Controls.Add(this.cmbSupplier, 1, 0);
            this.tlpMain.Controls.Add(this.lblBranch, 0, 1);
            this.tlpMain.Controls.Add(this.cmbBranch, 1, 1);
            this.tlpMain.Controls.Add(this.lblUser, 0, 2);
            this.tlpMain.Controls.Add(this.cmbUser, 1, 2);
            this.tlpMain.Controls.Add(this.lblDate, 0, 3);
            this.tlpMain.Controls.Add(this.dtpPurchaseDate, 1, 3);
            this.tlpMain.Controls.Add(this.lblStatus, 0, 4);
            this.tlpMain.Controls.Add(this.cmbStatus, 1, 4);
            this.tlpMain.Controls.Add(this.lblTotal, 0, 5);
            this.tlpMain.Controls.Add(this.numTotal, 1, 5);
            this.tlpMain.Controls.Add(this.grpItems, 0, 6);
            this.tlpMain.Controls.Add(this.pnlButtons, 0, 7);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 8;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.Size = new System.Drawing.Size(960, 558);
            this.tlpMain.TabIndex = 0;
            // 
            // lblSupplier
            // 
            this.lblSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSupplier.Location = new System.Drawing.Point(3, 0);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(134, 27);
            this.lblSupplier.TabIndex = 0;
            this.lblSupplier.Text = "Supplier";
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.Location = new System.Drawing.Point(143, 2);
            this.cmbSupplier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(814, 24);
            this.cmbSupplier.TabIndex = 1;
            // 
            // lblBranch
            // 
            this.lblBranch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBranch.Location = new System.Drawing.Point(3, 27);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(134, 27);
            this.lblBranch.TabIndex = 2;
            this.lblBranch.Text = "Branch";
            this.lblBranch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbBranch
            // 
            this.cmbBranch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Location = new System.Drawing.Point(143, 29);
            this.cmbBranch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(814, 24);
            this.cmbBranch.TabIndex = 3;
            // 
            // lblUser
            // 
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUser.Location = new System.Drawing.Point(3, 54);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(134, 27);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "User";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbUser
            // 
            this.cmbUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.Location = new System.Drawing.Point(143, 56);
            this.cmbUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(814, 24);
            this.cmbUser.TabIndex = 5;
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Location = new System.Drawing.Point(3, 81);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(134, 27);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(143, 83);
            this.dtpPurchaseDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(220, 22);
            this.dtpPurchaseDate.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Location = new System.Drawing.Point(3, 108);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(134, 27);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Location = new System.Drawing.Point(143, 110);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(220, 24);
            this.cmbStatus.TabIndex = 9;
            // 
            // lblTotal
            // 
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotal.Location = new System.Drawing.Point(3, 135);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(134, 27);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Total";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTotal
            // 
            this.numTotal.DecimalPlaces = 2;
            this.numTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.numTotal.Location = new System.Drawing.Point(143, 137);
            this.numTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numTotal.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numTotal.Name = "numTotal";
            this.numTotal.Size = new System.Drawing.Size(160, 22);
            this.numTotal.TabIndex = 11;
            // 
            // grpItems
            // 
            this.tlpMain.SetColumnSpan(this.grpItems, 2);
            this.grpItems.Controls.Add(this.dgvItems);
            this.grpItems.Controls.Add(this.pnlItemsTop);
            this.grpItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpItems.Location = new System.Drawing.Point(3, 164);
            this.grpItems.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpItems.Name = "grpItems";
            this.grpItems.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.grpItems.Size = new System.Drawing.Size(954, 357);
            this.grpItems.TabIndex = 12;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Items";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.ColumnHeadersHeight = 29;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPurchaseItemId,
            this.colProductId,
            this.colSKU,
            this.colName,
            this.colQuantity,
            this.colUnitCost,
            this.colTotalCost});
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(8, 56);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(938, 295);
            this.dgvItems.TabIndex = 1;
            // 
            // colPurchaseItemId
            // 
            this.colPurchaseItemId.DataPropertyName = "PurchaseItemId";
            this.colPurchaseItemId.HeaderText = "PurchaseItemId";
            this.colPurchaseItemId.MinimumWidth = 6;
            this.colPurchaseItemId.Name = "colPurchaseItemId";
            this.colPurchaseItemId.ReadOnly = true;
            this.colPurchaseItemId.Visible = false;
            // 
            // colProductId
            // 
            this.colProductId.DataPropertyName = "ProductId";
            this.colProductId.HeaderText = "ProductId";
            this.colProductId.MinimumWidth = 6;
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Visible = false;
            // 
            // colSKU
            // 
            this.colSKU.DataPropertyName = "SKU";
            this.colSKU.HeaderText = "SKU";
            this.colSKU.MinimumWidth = 6;
            this.colSKU.Name = "colSKU";
            this.colSKU.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Product";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Qty";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            // 
            // colUnitCost
            // 
            this.colUnitCost.DataPropertyName = "UnitCost";
            this.colUnitCost.HeaderText = "Unit Cost";
            this.colUnitCost.MinimumWidth = 6;
            this.colUnitCost.Name = "colUnitCost";
            this.colUnitCost.ReadOnly = true;
            // 
            // colTotalCost
            // 
            this.colTotalCost.DataPropertyName = "TotalCost";
            this.colTotalCost.HeaderText = "Total";
            this.colTotalCost.MinimumWidth = 6;
            this.colTotalCost.Name = "colTotalCost";
            this.colTotalCost.ReadOnly = true;
            // 
            // pnlItemsTop
            // 
            this.pnlItemsTop.Controls.Add(this.btnRemoveItem);
            this.pnlItemsTop.Controls.Add(this.btnAddItem);
            this.pnlItemsTop.Controls.Add(this.txtItemSearch);
            this.pnlItemsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlItemsTop.Location = new System.Drawing.Point(8, 21);
            this.pnlItemsTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlItemsTop.Name = "pnlItemsTop";
            this.pnlItemsTop.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pnlItemsTop.Size = new System.Drawing.Size(938, 35);
            this.pnlItemsTop.TabIndex = 2;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(116, 6);
            this.btnRemoveItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(120, 25);
            this.btnRemoveItem.TabIndex = 0;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(8, 6);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(100, 25);
            this.btnAddItem.TabIndex = 1;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // txtItemSearch
            // 
            this.txtItemSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemSearch.Location = new System.Drawing.Point(1398, 8);
            this.txtItemSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtItemSearch.Name = "txtItemSearch";
            this.txtItemSearch.Size = new System.Drawing.Size(280, 22);
            this.txtItemSearch.TabIndex = 2;
            // 
            // pnlButtons
            // 
            this.tlpMain.SetColumnSpan(this.pnlButtons, 2);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnOK);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlButtons.Location = new System.Drawing.Point(3, 525);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(954, 31);
            this.pnlButtons.TabIndex = 13;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(851, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 31);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(745, 2);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 29);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // PurchasesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 558);
            this.Controls.Add(this.tlpMain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PurchasesEdit";
            this.Text = "Purchase";
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numTotal)).EndInit();
            this.grpItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlItemsTop.ResumeLayout(false);
            this.pnlItemsTop.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.NumericUpDown numTotal;
        private System.Windows.Forms.GroupBox grpItems;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Panel pnlItemsTop;
        private System.Windows.Forms.TextBox txtItemSearch;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalCost;

    }

    #endregion
}