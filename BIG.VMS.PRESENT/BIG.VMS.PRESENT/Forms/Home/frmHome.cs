using BIG.VMS.PRESENT.Forms.FormAppoinment;
using BIG.VMS.PRESENT.Forms.FormComeOften;
using BIG.VMS.PRESENT.Forms.FormIn;
using BIG.VMS.PRESENT.Forms.FormOut;
using BIG.VMS.PRESENT.Forms.FormReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIG.VMS.PRESENT.Forms.Home
{
    public partial class frmHome : PageBase
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {

        }


        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInList frm = new frmInList();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this.ParentForm;
            frm.Show();
            this.Close();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            frmOutList frm = new frmOutList();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this.ParentForm;
            frm.Show();
            this.Close();
        }

        private void btnRegular_Click(object sender, EventArgs e)
        {
            frmComeOftenList frm = new frmComeOftenList();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this.ParentForm;
            frm.Show();
            this.Close();
        }

        private void btnAhead_Click(object sender, EventArgs e)
        {
            frmAppoinmentList frm = new frmAppoinmentList();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this.ParentForm;
            frm.Show();
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReportList frm = new frmReportList();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this.ParentForm;
            frm.Show();
            this.Close();
        }
    }
}
