using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WHUI.Products
{
    partial class ProductEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductEdit));
            this.lblSKU = new System.Windows.Forms.Label();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cbBrand = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.cbBranch = new System.Windows.Forms.ComboBox();
            this.lblVolume = new System.Windows.Forms.Label();
            this.nudVolume = new System.Windows.Forms.NumericUpDown();
            this.lblVolumeUnit = new System.Windows.Forms.Label();
            this.txtVolumeUnit = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.lblWeightUnit = new System.Windows.Forms.Label();
            this.txtWeightUnit = new System.Windows.Forms.TextBox();
            this.lblCostPrice = new System.Windows.Forms.Label();
            this.nudCostPrice = new System.Windows.Forms.NumericUpDown();
            this.lblListPrice = new System.Windows.Forms.Label();
            this.nudListPrice = new System.Windows.Forms.NumericUpDown();
            this.lblAlertStock = new System.Windows.Forms.Label();
            this.nudAlertStock = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCostPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudListPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlertStock)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSKU
            // 
            resources.ApplyResources(this.lblSKU, "lblSKU");
            this.lblSKU.Name = "lblSKU";
            // 
            // txtSKU
            // 
            resources.ApplyResources(this.txtSKU, "txtSKU");
            this.txtSKU.Name = "txtSKU";
            // 
            // lblBarcode
            // 
            resources.ApplyResources(this.lblBarcode, "lblBarcode");
            this.lblBarcode.Name = "lblBarcode";
            // 
            // txtBarcode
            // 
            resources.ApplyResources(this.txtBarcode, "txtBarcode");
            this.txtBarcode.Name = "txtBarcode";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Name = "lblDescription";
            // 
            // txtDescription
            // 
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.Name = "txtDescription";
            // 
            // lblBrand
            // 
            resources.ApplyResources(this.lblBrand, "lblBrand");
            this.lblBrand.Name = "lblBrand";
            // 
            // cbBrand
            // 
            this.cbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbBrand, "cbBrand");
            this.cbBrand.Name = "cbBrand";
            // 
            // lblCategory
            // 
            resources.ApplyResources(this.lblCategory, "lblCategory");
            this.lblCategory.Name = "lblCategory";
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbCategory, "cbCategory");
            this.cbCategory.Name = "cbCategory";
            // 
            // lblBranch
            // 
            resources.ApplyResources(this.lblBranch, "lblBranch");
            this.lblBranch.Name = "lblBranch";
            // 
            // cbBranch
            // 
            this.cbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbBranch, "cbBranch");
            this.cbBranch.Name = "cbBranch";
            // 
            // lblVolume
            // 
            resources.ApplyResources(this.lblVolume, "lblVolume");
            this.lblVolume.Name = "lblVolume";
            // 
            // nudVolume
            // 
            this.nudVolume.DecimalPlaces = 2;
            resources.ApplyResources(this.nudVolume, "nudVolume");
            this.nudVolume.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudVolume.Name = "nudVolume";
            // 
            // lblVolumeUnit
            // 
            resources.ApplyResources(this.lblVolumeUnit, "lblVolumeUnit");
            this.lblVolumeUnit.Name = "lblVolumeUnit";
            // 
            // txtVolumeUnit
            // 
            resources.ApplyResources(this.txtVolumeUnit, "txtVolumeUnit");
            this.txtVolumeUnit.Name = "txtVolumeUnit";
            // 
            // lblWeight
            // 
            resources.ApplyResources(this.lblWeight, "lblWeight");
            this.lblWeight.Name = "lblWeight";
            // 
            // nudWeight
            // 
            this.nudWeight.DecimalPlaces = 2;
            resources.ApplyResources(this.nudWeight, "nudWeight");
            this.nudWeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudWeight.Name = "nudWeight";
            // 
            // lblWeightUnit
            // 
            resources.ApplyResources(this.lblWeightUnit, "lblWeightUnit");
            this.lblWeightUnit.Name = "lblWeightUnit";
            // 
            // txtWeightUnit
            // 
            resources.ApplyResources(this.txtWeightUnit, "txtWeightUnit");
            this.txtWeightUnit.Name = "txtWeightUnit";
            // 
            // lblCostPrice
            // 
            resources.ApplyResources(this.lblCostPrice, "lblCostPrice");
            this.lblCostPrice.Name = "lblCostPrice";
            // 
            // nudCostPrice
            // 
            this.nudCostPrice.DecimalPlaces = 2;
            resources.ApplyResources(this.nudCostPrice, "nudCostPrice");
            this.nudCostPrice.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudCostPrice.Name = "nudCostPrice";
            // 
            // lblListPrice
            // 
            resources.ApplyResources(this.lblListPrice, "lblListPrice");
            this.lblListPrice.Name = "lblListPrice";
            // 
            // nudListPrice
            // 
            this.nudListPrice.DecimalPlaces = 2;
            resources.ApplyResources(this.nudListPrice, "nudListPrice");
            this.nudListPrice.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudListPrice.Name = "nudListPrice";
            // 
            // lblAlertStock
            // 
            resources.ApplyResources(this.lblAlertStock, "lblAlertStock");
            this.lblAlertStock.Name = "lblAlertStock";
            // 
            // nudAlertStock
            // 
            resources.ApplyResources(this.nudAlertStock, "nudAlertStock");
            this.nudAlertStock.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudAlertStock.Name = "nudAlertStock";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ProductEdit
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lblSKU);
            this.Controls.Add(this.txtSKU);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.cbBrand);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.cbBranch);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.nudVolume);
            this.Controls.Add(this.lblVolumeUnit);
            this.Controls.Add(this.txtVolumeUnit);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.nudWeight);
            this.Controls.Add(this.lblWeightUnit);
            this.Controls.Add(this.txtWeightUnit);
            this.Controls.Add(this.lblCostPrice);
            this.Controls.Add(this.nudCostPrice);
            this.Controls.Add(this.lblListPrice);
            this.Controls.Add(this.nudListPrice);
            this.Controls.Add(this.lblAlertStock);
            this.Controls.Add(this.nudAlertStock);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductEdit";
            ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCostPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudListPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlertStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblSKU;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cbBrand;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cbBranch;

        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.NumericUpDown nudVolume;
        private System.Windows.Forms.Label lblVolumeUnit;
        private System.Windows.Forms.TextBox txtVolumeUnit;

        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.Label lblWeightUnit;
        private System.Windows.Forms.TextBox txtWeightUnit;

        private System.Windows.Forms.Label lblCostPrice;
        private System.Windows.Forms.NumericUpDown nudCostPrice;
        private System.Windows.Forms.Label lblListPrice;
        private System.Windows.Forms.NumericUpDown nudListPrice;
        private System.Windows.Forms.Label lblAlertStock;
        private System.Windows.Forms.NumericUpDown nudAlertStock;

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}