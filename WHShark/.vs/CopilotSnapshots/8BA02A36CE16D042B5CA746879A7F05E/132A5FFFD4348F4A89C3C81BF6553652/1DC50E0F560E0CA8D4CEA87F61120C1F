using System;
using System.Windows.Forms;

namespace WHUI.Login
{
    public partial class ForgetPassCode : Form
    {
        private readonly string _username;
        public string VerifiedCode { get; private set; } = string.Empty;

        public ForgetPassCode(string username)
        {
            InitializeComponent();
            _username = username ?? throw new ArgumentNullException(nameof(username));

            btnSendCode.Click += btnSendCode_Click;
        }

        private void ForgetPassCode_Load(object sender, EventArgs e)
        {
            try
            {
                this.AcceptButton = btnSendCode;
                textBox1.Focus();
            }
            catch
            {
                // swallow exceptions to avoid designer/runtime differences causing crashes
            }
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            var code = (textBox1.Text ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Please enter the verification code.", "Verify code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            VerifiedCode = code;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
