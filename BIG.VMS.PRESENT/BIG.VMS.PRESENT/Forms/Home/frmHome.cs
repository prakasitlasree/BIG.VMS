using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.PRESENT.Forms.FormAppoinment;
using BIG.VMS.PRESENT.Forms.FormComeOften;
using BIG.VMS.PRESENT.Forms.FormIn;
using BIG.VMS.PRESENT.Forms.FormOut;
using BIG.VMS.PRESENT.Forms.FormReport;
using BIG.VMS.PRESENT.Forms.FormVisitor;
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
            frmVisitor frm = new frmVisitor();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.formMode = FormMode.Add;
            frm.visitorMode = VisitorMode.In;
            frm.MdiParent = this.ParentForm;
            frm.Show();
            this.Close();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            frmVisitor_11 frm = new frmVisitor_11();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.formMode = FormMode.Add;
            frm.visitorMode = VisitorMode.Out;
            frm.MdiParent = this.ParentForm;
            frm.Show();
            this.Close();
        }

        private void btnRegular_Click(object sender, EventArgs e)
        {
            frmVisitor_11 frm = new frmVisitor_11();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.formMode = FormMode.Add;
            frm.visitorMode = VisitorMode.ComeOften;
            frm.MdiParent = this.ParentForm;
            frm.Show();
            this.Close();
        }

        private void btnAhead_Click(object sender, EventArgs e)
        {
            frmVisitor_11 frm = new frmVisitor_11();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.formMode = FormMode.Add;
            frm.visitorMode = VisitorMode.Appointment;
            frm.MdiParent = this.ParentForm;
            frm.Show();
            this.Close(); ;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            //frmReportList frm = new frmReportList();
            //frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.MdiParent = this.ParentForm;
            //frm.Show();
            //this.Close();

            frmProvince frm = new frmProvince();
            //frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.MdiParent = this.ParentForm;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                //var x = frm.selectedEmployeeID;
                this.Close();
            }
        }

        private void btnAllVisitor_Click(object sender, EventArgs e)
        {
            frmAllvisitor frm = new frmAllvisitor();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this.ParentForm;
            frm.Show();
            this.Close();
        }
    }
}
