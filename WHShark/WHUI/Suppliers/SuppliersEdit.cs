using System;
using System.Linq;
using System.Windows.Forms;
using DomainModel;
using BLL.Services;
using Services.Services;

namespace WHUI.Suppliers
{
    public partial class SuppliersEdit : Form
    {
        private Supplier _supplier;

        public SuppliersEdit()
        {
            InitializeComponent();
        }

        public void LoadSupplier(Supplier supplier)
        {
            _supplier = supplier;
            if (_supplier != null)
            {
                txtName.Text = _supplier.Name;
                txtEmail.Text = _supplier.Email;
                txtPhone.Text = _supplier.Phone;
                txtAddress.Text = _supplier.Address;
                this.Text = "Edit Supplier";
                btnOK.Text = "Save";
            }
            else
            {
                this.Text = "Add Supplier";
                btnOK.Text = "OK";
            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return true;
            var at = email.IndexOf('@');
            if (at <= 0 || at == email.Length - 1) return false;
            var local = email.Substring(0, at);
            var domain = email.Substring(at + 1);
            if (string.IsNullOrWhiteSpace(local) || string.IsNullOrWhiteSpace(domain)) return false;
            if (!domain.Contains('.')) return false;
            var parts = domain.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) return false;
            if (parts.Any(p => p.Length == 0)) return false;
            if (parts.Last().Length < 2) return false;
            return true;
        }

        private bool IsDigitsOnlyAndMax10(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return true;
            var digits = new string(phone.Where(char.IsDigit).ToArray());
            return digits.Length > 0 && digits.Length <= 10 && digits.Length == phone.Length;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(this, "Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            var email = txtEmail.Text?.Trim();
            if (!IsValidEmail(email))
            {
                MessageBox.Show(this, "Email format is invalid.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            var phone = txtPhone.Text?.Trim();
            if (!IsDigitsOnlyAndMax10(phone))
            {
                MessageBox.Show(this, "Phone must contain only digits and be at most 10 digits long.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            try
            {
                var svc = new SupplierService();
                if (_supplier == null)
                {
                    var newSupplier = new Supplier
                    {
                        SupplierId = Guid.Empty,
                        Name = txtName.Text.Trim(),
                        Email = string.IsNullOrWhiteSpace(email) ? null : email,
                        Phone = string.IsNullOrWhiteSpace(phone) ? null : phone,
                        Address = txtAddress.Text?.Trim(),
                        CreatedAt = DateTime.Now
                    };

                    svc.Add(newSupplier);
                    LoggerService.WriteInfo($"Supplier added: {newSupplier.Name}");
                }
                else
                {
                    _supplier.Name = txtName.Text.Trim();
                    _supplier.Email = string.IsNullOrWhiteSpace(email) ? null : email;
                    _supplier.Phone = string.IsNullOrWhiteSpace(phone) ? null : phone;
                    _supplier.Address = txtAddress.Text?.Trim();

                    svc.Update(_supplier);
                    LoggerService.WriteInfo($"Supplier updated: {_supplier.Name}");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to save supplier: " + ex.Message);
                MessageBox.Show(this, "Failed to save supplier: " + ex.Message, "Suppliers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
