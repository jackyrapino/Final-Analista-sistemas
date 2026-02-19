using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WHUI.Products
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new ProductEdit())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            using (var frm = new Brands())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                  
                }
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            using (var frm = new Categories())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                   
                }
            }
        }
    }
}
