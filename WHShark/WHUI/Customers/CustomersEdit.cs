using System;
using System.Linq;
using System.Windows.Forms;
using DomainModel;
using BLL.Services;
using Services.Services;

namespace WHUI.Customers
{
    public partial class CustomersEdit : Form
    {
        private Customer _customer;

        public CustomersEdit()
        {
            InitializeComponent();
        }

        public void LoadCustomer(Customer customer)
        {
            _customer = customer;
            if (_customer != null)
            {
                txtFirst.Text = _customer.FirstName;
                txtLast.Text = _customer.LastName;
                txtEmail.Text = _customer.Email;
                txtPhone.Text = _customer.Phone;
                txtAddress.Text = _customer.Address;
                if (_customer.BirthdayDay.HasValue)
                    dtpBirthday.Value = _customer.BirthdayDay.Value;
                else
                    dtpBirthday.Value = DateTime.Today;

                this.Text = "Edit Customer";
                btnOK.Text = "Save";
            }
            else
            {
                this.Text = "Add Customer";
                btnOK.Text = "OK";
                dtpBirthday.Value = DateTime.Today;
            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
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

        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return true; // optional
            var digits = new string(phone.Where(char.IsDigit).ToArray());
            return digits.Length <= 10;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirst.Text))
            {
                MessageBox.Show(this, "First name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirst.Focus();
                return;
            }

            var email = txtEmail.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(email) && !IsValidEmail(email))
            {
                MessageBox.Show(this, "Email format is invalid.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            var phone = txtPhone.Text?.Trim();
            if (!IsValidPhone(phone))
            {
                MessageBox.Show(this, "Phone number must contain at most 10 digits.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            var birthday = dtpBirthday.Value.Date;
            if (birthday > DateTime.Today)
            {
                MessageBox.Show(this, "Birthday cannot be a future date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpBirthday.Focus();
                return;
            }

            try
            {
                var svc = new CustomerService();
                if (_customer == null)
                {
                    var newCustomer = new Customer
                    {
                        CustomerId = Guid.Empty,
                        FirstName = txtFirst.Text.Trim(),
                        LastName = txtLast.Text?.Trim(),
                        Email = string.IsNullOrWhiteSpace(email) ? null : email,
                        Phone = string.IsNullOrWhiteSpace(phone) ? null : phone,
                        Address = txtAddress.Text?.Trim(),
                        BirthdayDay = birthday,
                        CreatedAt = DateTime.Now
                    };

                    svc.Add(newCustomer);
                    LoggerService.WriteInfo($"Customer added: {newCustomer.FirstName} {newCustomer.LastName}");
                }
                else
                {
                    _customer.FirstName = txtFirst.Text.Trim();
                    _customer.LastName = txtLast.Text?.Trim();
                    _customer.Email = string.IsNullOrWhiteSpace(email) ? null : email;
                    _customer.Phone = string.IsNullOrWhiteSpace(phone) ? null : phone;
                    _customer.Address = txtAddress.Text?.Trim();
                    _customer.BirthdayDay = birthday;

                    svc.Update(_customer);
                    LoggerService.WriteInfo($"Customer updated: {_customer.FirstName} {_customer.LastName}");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to save customer: " + ex.Message);
                MessageBox.Show(this, "Failed to save customer: " + ex.Message, "Customers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
