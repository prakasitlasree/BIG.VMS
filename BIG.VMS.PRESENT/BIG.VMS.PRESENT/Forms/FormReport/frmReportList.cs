using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIG.VMS.PRESENT.Forms.FormReport
{
    public partial class frmReportList : Form
    {
        public frmReportList()
        {
            InitializeComponent();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            frmReportKeyIn frm = new frmReportKeyIn();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}
