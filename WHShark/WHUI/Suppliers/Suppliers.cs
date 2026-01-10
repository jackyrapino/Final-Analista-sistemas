using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WHUI.Suppliers
{
    public partial class Suppliers : Form
    {
        public Suppliers()
        {
            InitializeComponent();
 
        }

        // Event handler required by designer. Keep minimal to compile.
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var edit = new SuppliersEdit())
                {
                    // Optionally pass selected item data to edit form here
                    edit.ShowDialog(this);
                }
            }
            catch
            {
                // swallow exceptions to avoid crash in designer/runtime until implemented
            }
        }

    }
}
