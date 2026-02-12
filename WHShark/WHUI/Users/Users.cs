using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WHUI.Users
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            using (var frm = new UsersEdit())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (var frm = new UsersEdit())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnManagePermissions_Click(object sender, EventArgs e)
        {
            using (var frm = new UserPermissions())
            {
                frm.ShowDialog(this);
            }
        }
    }
}
