using System;
using System.Drawing;
using System.Windows.Forms;

namespace WHUI.Sales
{
    partial class SalesEdit
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
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.ComboBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.txtBranchId = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpSaleDate = new System.Windows.Forms.DateTimePicker();
            this.lblPayment = new System.Windows.Forms.Label();
            this.txtPaymentMethod = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.numTotal = new System.Windows.Forms.NumericUpDown();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tlpMain.Controls.Add(this.lblCustomer, 0, 0);
            this.tlpMain.Controls.Add(this.txtCustomerId, 1, 0);
            this.tlpMain.Controls.Add(this.lblBranch, 0, 1);
            this.tlpMain.Controls.Add(this.txtBranchId, 1, 1);
            this.tlpMain.Controls.Add(this.lblUser, 0, 2);
            this.tlpMain.Controls.Add(this.txtUserId, 1, 2);
            this.tlpMain.Controls.Add(this.lblDate, 0, 3);
            this.tlpMain.Controls.Add(this.dtpSaleDate, 1, 3);
            this.tlpMain.Controls.Add(this.lblPayment, 0, 4);
            this.tlpMain.Controls.Add(this.txtPaymentMethod, 1, 4);
            this.tlpMain.Controls.Add(this.lblStatus, 0, 5);
            this.tlpMain.Controls.Add(this.txtStatus, 1, 5);
            this.tlpMain.Controls.Add(this.lblTotal, 0, 6);
            this.tlpMain.Controls.Add(this.numTotal, 1, 6);
            this.tlpMain.Controls.Add(this.grpItems, 0, 7);
            this.tlpMain.Controls.Add(this.pnlButtons, 0, 8);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 9;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.Size = new System.Drawing.Size(960, 512);
            this.tlpMain.TabIndex = 0;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomer.Location = new System.Drawing.Point(3, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(134, 27);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCustomerId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCustomerId.FormattingEnabled = true;
            this.txtCustomerId.Location = new System.Drawing.Point(143, 2);
            this.txtCustomerId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(814, 24);
            this.txtCustomerId.TabIndex = 1;
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
            // txtBranchId
            // 
            this.txtBranchId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBranchId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtBranchId.FormattingEnabled = true;
            this.txtBranchId.Location = new System.Drawing.Point(143, 29);
            this.txtBranchId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBranchId.Name = "txtBranchId";
            this.txtBranchId.Size = new System.Drawing.Size(814, 24);
            this.txtBranchId.TabIndex = 3;
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
            // txtUserId
            // 
            this.txtUserId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtUserId.FormattingEnabled = true;
            this.txtUserId.Location = new System.Drawing.Point(143, 56);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(814, 24);
            this.txtUserId.TabIndex = 5;
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
            // dtpSaleDate
            // 
            this.dtpSaleDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpSaleDate.Location = new System.Drawing.Point(143, 83);
            this.dtpSaleDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpSaleDate.Name = "dtpSaleDate";
            this.dtpSaleDate.Size = new System.Drawing.Size(220, 22);
            this.dtpSaleDate.TabIndex = 7;
            // 
            // lblPayment
            // 
            this.lblPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPayment.Location = new System.Drawing.Point(3, 108);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(134, 27);
            this.lblPayment.TabIndex = 8;
            this.lblPayment.Text = "Payment";
            this.lblPayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPaymentMethod
            // 
            this.txtPaymentMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPaymentMethod.Location = new System.Drawing.Point(143, 110);
            this.txtPaymentMethod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPaymentMethod.Name = "txtPaymentMethod";
            this.txtPaymentMethod.Size = new System.Drawing.Size(814, 22);
            this.txtPaymentMethod.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Location = new System.Drawing.Point(3, 135);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(134, 27);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStatus
            // 
            this.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatus.Location = new System.Drawing.Point(143, 137);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(814, 22);
            this.txtStatus.TabIndex = 11;
            // 
            // lblTotal
            // 
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotal.Location = new System.Drawing.Point(3, 162);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(134, 27);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "Total";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTotal
            // 
            this.numTotal.DecimalPlaces = 2;
            this.numTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.numTotal.Location = new System.Drawing.Point(143, 164);
            this.numTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numTotal.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numTotal.Name = "numTotal";
            this.numTotal.Size = new System.Drawing.Size(160, 22);
            this.numTotal.TabIndex = 13;
            // 
            // grpItems
            // 
            this.tlpMain.SetColumnSpan(this.grpItems, 2);
            this.grpItems.Controls.Add(this.dgvItems);
            this.grpItems.Controls.Add(this.pnlItemsTop);
            this.grpItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpItems.Location = new System.Drawing.Point(3, 191);
            this.grpItems.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpItems.Name = "grpItems";
            this.grpItems.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.grpItems.Size = new System.Drawing.Size(954, 284);
            this.grpItems.TabIndex = 14;
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
            this.colProductId,
            this.colSKU,
            this.colName,
            this.colQuantity,
            this.colUnitPrice,
            this.colTotalPrice});
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(8, 56);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(938, 222);
            this.dgvItems.TabIndex = 0;
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
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "UnitPrice";
            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.MinimumWidth = 6;
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.DataPropertyName = "TotalPrice";
            this.colTotalPrice.HeaderText = "Total";
            this.colTotalPrice.MinimumWidth = 6;
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.ReadOnly = true;
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
            this.pnlItemsTop.TabIndex = 1;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(116, 6);
            this.btnRemoveItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(120, 24);
            this.btnRemoveItem.TabIndex = 0;
            this.btnRemoveItem.Text = "Remove Item";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(8, 6);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(100, 24);
            this.btnAddItem.TabIndex = 1;
            this.btnAddItem.Text = "Add Item";
            // 
            // txtItemSearch
            // 
            this.txtItemSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemSearch.Location = new System.Drawing.Point(642, 6);
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
            this.pnlButtons.Location = new System.Drawing.Point(3, 479);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(954, 31);
            this.pnlButtons.TabIndex = 15;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(851, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 18);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(745, 2);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 18);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            // 
            // SalesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 512);
            this.Controls.Add(this.tlpMain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SalesEdit";
            this.Text = "Sale";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotal)).EndInit();
            this.grpItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlItemsTop.ResumeLayout(false);
            this.pnlItemsTop.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox txtCustomerId;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox txtBranchId;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox txtUserId;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpSaleDate;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.TextBox txtPaymentMethod;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPrice;
        #endregion
    }
}