using System;
using System.Drawing;
using System.Windows.Forms;

namespace WHUI.StockMovements
{
    partial class StockMovementEdit
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
            tlp = new System.Windows.Forms.TableLayoutPanel();
            lblType = new System.Windows.Forms.Label();
            cbType = new System.Windows.Forms.ComboBox();
            lblFrom = new System.Windows.Forms.Label();
            cbFrom = new System.Windows.Forms.ComboBox();
            lblTo = new System.Windows.Forms.Label();
            cbTo = new System.Windows.Forms.ComboBox();
            lblReason = new System.Windows.Forms.Label();
            cbReason = new System.Windows.Forms.ComboBox();
            lblDate = new System.Windows.Forms.Label();
            dtpMovementDate = new System.Windows.Forms.DateTimePicker();
            lblStatus = new System.Windows.Forms.Label();
            cbStatus = new System.Windows.Forms.ComboBox();
            lblNotes = new System.Windows.Forms.Label();
            txtNotes = new System.Windows.Forms.TextBox();
            grpItems = new System.Windows.Forms.GroupBox();
            dgvItems = new System.Windows.Forms.DataGridView();
            colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            pnlItemsTop = new System.Windows.Forms.Panel();
            btnRemoveItem = new System.Windows.Forms.Button();
            btnAddItem = new System.Windows.Forms.Button();
            pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            btnOK = new System.Windows.Forms.Button();
            tlp.SuspendLayout();
            grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            pnlItemsTop.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tlp
            // 
            tlp.ColumnCount = 2;
            tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlp.Controls.Add(lblType, 0, 0);
            tlp.Controls.Add(cbType, 1, 0);
            tlp.Controls.Add(lblFrom, 0, 1);
            tlp.Controls.Add(cbFrom, 1, 1);
            tlp.Controls.Add(lblTo, 0, 2);
            tlp.Controls.Add(cbTo, 1, 2);
            tlp.Controls.Add(lblReason, 0, 3);
            tlp.Controls.Add(cbReason, 1, 3);
            tlp.Controls.Add(lblDate, 0, 4);
            tlp.Controls.Add(dtpMovementDate, 1, 4);
            tlp.Controls.Add(lblStatus, 0, 5);
            tlp.Controls.Add(cbStatus, 1, 5);
            tlp.Controls.Add(lblNotes, 0, 6);
            tlp.Controls.Add(txtNotes, 1, 6);
            tlp.Controls.Add(grpItems, 0, 7);
            tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            tlp.Location = new System.Drawing.Point(0, 0);
            tlp.Name = "tlp";
            tlp.RowCount = 8;
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlp.Size = new System.Drawing.Size(920, 636);
            tlp.TabIndex = 0;
            // 
            // lblType
            // 
            lblType.Dock = System.Windows.Forms.DockStyle.Fill;
            lblType.Location = new System.Drawing.Point(3, 0);
            lblType.Name = "lblType";
            lblType.Size = new System.Drawing.Size(134, 34);
            lblType.TabIndex = 0;
            lblType.Text = "Type";
            lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbType
            // 
            cbType.Dock = System.Windows.Forms.DockStyle.Left;
            cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbType.Location = new System.Drawing.Point(143, 3);
            cbType.Name = "cbType";
            cbType.Size = new System.Drawing.Size(240, 28);
            cbType.TabIndex = 1;
            // 
            // lblFrom
            // 
            lblFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            lblFrom.Location = new System.Drawing.Point(3, 34);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new System.Drawing.Size(134, 34);
            lblFrom.TabIndex = 2;
            lblFrom.Text = "From Branch";
            lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbFrom
            // 
            cbFrom.Dock = System.Windows.Forms.DockStyle.Left;
            cbFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFrom.Location = new System.Drawing.Point(143, 37);
            cbFrom.Name = "cbFrom";
            cbFrom.Size = new System.Drawing.Size(280, 28);
            cbFrom.TabIndex = 3;
            // 
            // lblTo
            // 
            lblTo.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTo.Location = new System.Drawing.Point(3, 68);
            lblTo.Name = "lblTo";
            lblTo.Size = new System.Drawing.Size(134, 34);
            lblTo.TabIndex = 4;
            lblTo.Text = "To Branch";
            lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbTo
            // 
            cbTo.Dock = System.Windows.Forms.DockStyle.Left;
            cbTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbTo.Location = new System.Drawing.Point(143, 71);
            cbTo.Name = "cbTo";
            cbTo.Size = new System.Drawing.Size(280, 28);
            cbTo.TabIndex = 5;
            // 
            // lblReason
            // 
            lblReason.Dock = System.Windows.Forms.DockStyle.Fill;
            lblReason.Location = new System.Drawing.Point(3, 102);
            lblReason.Name = "lblReason";
            lblReason.Size = new System.Drawing.Size(134, 34);
            lblReason.TabIndex = 6;
            lblReason.Text = "Reason";
            lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbReason
            // 
            cbReason.Dock = System.Windows.Forms.DockStyle.Left;
            cbReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbReason.Location = new System.Drawing.Point(143, 105);
            cbReason.Name = "cbReason";
            cbReason.Size = new System.Drawing.Size(280, 28);
            cbReason.TabIndex = 7;
            // 
            // lblDate
            // 
            lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            lblDate.Location = new System.Drawing.Point(3, 136);
            lblDate.Name = "lblDate";
            lblDate.Size = new System.Drawing.Size(134, 34);
            lblDate.TabIndex = 10;
            lblDate.Text = "Movement Date";
            lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpMovementDate
            // 
            dtpMovementDate.Dock = System.Windows.Forms.DockStyle.Left;
            dtpMovementDate.Location = new System.Drawing.Point(143, 139);
            dtpMovementDate.Name = "dtpMovementDate";
            dtpMovementDate.Size = new System.Drawing.Size(220, 27);
            dtpMovementDate.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            lblStatus.Location = new System.Drawing.Point(3, 170);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(134, 34);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Status";
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbStatus
            // 
            cbStatus.Dock = System.Windows.Forms.DockStyle.Left;
            cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbStatus.Location = new System.Drawing.Point(143, 173);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new System.Drawing.Size(220, 28);
            cbStatus.TabIndex = 13;
            // 
            // lblNotes
            // 
            lblNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            lblNotes.Location = new System.Drawing.Point(3, 204);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new System.Drawing.Size(134, 80);
            lblNotes.TabIndex = 14;
            lblNotes.Text = "Comments";
            lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNotes
            // 
            txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            txtNotes.Location = new System.Drawing.Point(143, 207);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new System.Drawing.Size(774, 74);
            txtNotes.TabIndex = 15;
            // 
            // grpItems
            // 
            tlp.SetColumnSpan(grpItems, 2);
            grpItems.Controls.Add(dgvItems);
            grpItems.Controls.Add(pnlItemsTop);
            grpItems.Dock = System.Windows.Forms.DockStyle.Fill;
            grpItems.Location = new System.Drawing.Point(3, 287);
            grpItems.Name = "grpItems";
            grpItems.Padding = new System.Windows.Forms.Padding(8);
            grpItems.Size = new System.Drawing.Size(914, 346);
            grpItems.TabIndex = 16;
            grpItems.TabStop = false;
            grpItems.Text = "Items";
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.ColumnHeadersHeight = 29;
            dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colProductId, colSKU, colName, colQuantity });
            dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvItems.Location = new System.Drawing.Point(8, 68);
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.RowHeadersVisible = false;
            dgvItems.RowHeadersWidth = 51;
            dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvItems.Size = new System.Drawing.Size(898, 270);
            dgvItems.TabIndex = 0;
            // 
            // colProductId
            // 
            colProductId.DataPropertyName = "ProductId";
            colProductId.HeaderText = "ProductId";
            colProductId.MinimumWidth = 6;
            colProductId.Name = "colProductId";
            colProductId.ReadOnly = true;
            colProductId.Visible = false;
            // 
            // colSKU
            // 
            colSKU.DataPropertyName = "SKU";
            colSKU.HeaderText = "SKU";
            colSKU.MinimumWidth = 6;
            colSKU.Name = "colSKU";
            colSKU.ReadOnly = true;
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Product";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colQuantity
            // 
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "Qty";
            colQuantity.MinimumWidth = 6;
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            // 
            // pnlItemsTop
            // 
            pnlItemsTop.Controls.Add(btnRemoveItem);
            pnlItemsTop.Controls.Add(btnAddItem);
            pnlItemsTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlItemsTop.Location = new System.Drawing.Point(8, 28);
            pnlItemsTop.Name = "pnlItemsTop";
            pnlItemsTop.Size = new System.Drawing.Size(898, 40);
            pnlItemsTop.TabIndex = 1;
            // 
            // btnRemoveItem
            // 
            btnRemoveItem.Location = new System.Drawing.Point(96, 8);
            btnRemoveItem.Name = "btnRemoveItem";
            btnRemoveItem.Size = new System.Drawing.Size(75, 23);
            btnRemoveItem.TabIndex = 0;
            btnRemoveItem.Text = "Remove Item";
            // 
            // btnAddItem
            // 
            btnAddItem.Location = new System.Drawing.Point(8, 8);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new System.Drawing.Size(75, 23);
            btnAddItem.TabIndex = 1;
            btnAddItem.Text = "Add Item";
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Controls.Add(btnOK);
            pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            pnlButtons.Location = new System.Drawing.Point(0, 636);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new System.Drawing.Size(920, 44);
            pnlButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(817, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(100, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            btnOK.Location = new System.Drawing.Point(711, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(100, 23);
            btnOK.TabIndex = 1;
            btnOK.Text = "OK";
            // 
            // StockMovementEdit
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(920, 680);
            Controls.Add(tlp);
            Controls.Add(pnlButtons);
            Name = "StockMovementEdit";
            Text = "Stock Transfer";
            tlp.ResumeLayout(false);
            tlp.PerformLayout();
            grpItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            pnlItemsTop.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.ComboBox cbFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.ComboBox cbTo;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.ComboBox cbReason;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpMovementDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.GroupBox grpItems;
        private System.Windows.Forms.Panel pnlItemsTop;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;


        #endregion
    }
}