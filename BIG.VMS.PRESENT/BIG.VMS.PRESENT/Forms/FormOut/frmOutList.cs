using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIG.VMS.PRESENT.Forms.FormOut
{
    public partial class frmOutList : Form
    {
        public frmOutList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOut frm = new frmOut();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}
