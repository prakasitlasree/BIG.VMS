using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.PRESENT.Forms.FormVisitorBypass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIG.VMS.PRESENT.Forms.FormVisitor
{
    public partial class frmSelectInType : Form
    {
        public frmSelectInType()
        {
            InitializeComponent();
        }

        private void btnInCard_Click(object sender, EventArgs e)
        {
            frmVisitor frm = new frmVisitor();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.formMode = FormMode.Add;
            frm.visitorMode = VisitorMode.In;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnInWithOutCard_Click(object sender, EventArgs e)
        {
            frmVisitorByPass frm = new frmVisitorByPass();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.formMode = FormMode.Add;
            frm.visitorMode = VisitorMode.In;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
