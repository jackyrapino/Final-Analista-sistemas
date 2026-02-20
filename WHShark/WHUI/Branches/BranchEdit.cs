using System;
using System.Windows.Forms;
using DomainModel;
using BLL.Services;
using Services.Services;
using DAL.Implementations;

namespace WHUI.Branches
{
    public partial class BranchEdit : Form
    {
        private Branch _branch;
        public BranchEdit()
        {
            InitializeComponent();
        }

        public void LoadBranch(Branch branch)
        {
            _branch = branch;
            if (_branch != null)
            {
                txtName.Text = _branch.Name;
                txtAddress.Text = _branch.Address;
                chkIsWeb.Checked = _branch.IsWeb;
                this.Text = "Edit Branch";
                btnAdd.Text = "Save";
            }
            else
            {
                this.Text = "Add Branch";
                btnAdd.Text = "Add";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(this, "Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            try
            {
                var svc = new BranchService();
                if (_branch == null)
                {
                    var newBranch = new Branch
                    {
                        BranchId = Guid.Empty,
                        Name = txtName.Text.Trim(),
                        Address = txtAddress.Text?.Trim(),
                        IsWeb = chkIsWeb.Checked,
                        CreatedAt = DateTime.Now
                    };

                    svc.Add(newBranch);
                }
                else
                {
                    _branch.Name = txtName.Text.Trim();
                    _branch.Address = txtAddress.Text?.Trim();
                    _branch.IsWeb = chkIsWeb.Checked;

                    svc.Update(_branch);
                }

                LoggerService.WriteInfo($"Branch saved: {txtName.Text}");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Failed to save branch: " + ex.Message);
                MessageBox.Show(this, "Failed to save branch: " + ex.Message, "Branches", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
