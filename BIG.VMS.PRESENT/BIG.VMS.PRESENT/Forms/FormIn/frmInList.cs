using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIG.VMS.PRESENT.Forms.FormIn
{
    public partial class frmInList : PageBase
    {
        public frmInList()
        {
            InitializeComponent();
        }

        private void frmInList_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmIn frm = new frmIn();
            frm.StartPosition = FormStartPosition.CenterParent;
             
            frm.ShowDialog();
             
        }
    }
}
