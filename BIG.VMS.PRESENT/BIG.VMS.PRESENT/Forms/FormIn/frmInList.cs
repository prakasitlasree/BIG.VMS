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

namespace BIG.VMS.PRESENT.Forms.FormIn
{
    public partial class frmInList : PageBase
    {
        private readonly VisitorServices _service = new VisitorServices();
        private ContainerVisitor _container = new ContainerVisitor();
        public frmInList()
        {
            InitializeComponent();
        }

        private void frmInList_Load(object sender, EventArgs e)
        {
            BindGridData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmIn frm = new frmIn();
            frm.StartPosition = FormStartPosition.CenterParent;
             
             DialogResult result = frm.ShowDialog();
             if(result == DialogResult.OK)
            {
                BindGridData();
            }
        }

        private void BindGridData()
        {
            var filter = new VisitorFilter()
            {
                TYPE = "IN",
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
