using BIG.VMS.DATASERVICE;
using BIG.VMS.MODEL.CustomModel;
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
        private readonly VisitorServices _service = new VisitorServices();
        private ContainerVisitor _container = new ContainerVisitor();
        public frmOutList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOut frm = new frmOut();
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                BindGridData();
            }
        }

        private void frmOutList_Load(object sender, EventArgs e)
        {
            BindGridData();
        }

        private void BindGridData()
        {
            var filter = new VisitorFilter()
            {
                TYPE = "OUT",
                ID_CARD = txtIDCard.Text,
                LICENSE_PLATE = txtLicense.Text,
                NO = txtNo.Text
            };
            _container.Filter = filter;
            var obj = _service.Retrieve(_container);
            gridVisitorList.DataSource = obj.ResultObj;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridData();
        }
    }
}
