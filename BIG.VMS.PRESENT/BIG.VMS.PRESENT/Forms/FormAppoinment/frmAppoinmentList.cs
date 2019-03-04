using BIG.VMS.DATASERVICE;
using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.MODEL.CustomModel.Filter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIG.VMS.PRESENT.Forms.FormAppoinment
{
    public partial class frmAppoinmentList : Form
    {
        private readonly AppointmentServices _service = new AppointmentServices();
        private ContainerAppointment _container = new ContainerAppointment();
        public frmAppoinmentList()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAppoinmentKeyIn frm = new frmAppoinmentKeyIn();
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                BindGridData();
            }
           
        }

        private void BindGridData()
        {
            var filter = new AppointmentFilter()
            {
               
                ID_CARD = txtIDCard.Text,
                NAME = txtName.Text,
                LICENSE_PLATE =txtLicense.Text,
            };

            if (chkDate.Checked)
            {
                filter.CONTACT_DATE = dtContactDate.Value;
            }

            _container.Filter = filter;
            var obj = _service.Retrieve(_container);
            gridAppointment.DataSource = obj.ResultObj;
        }

        private void frmAppoinmentList_Load(object sender, EventArgs e)
        {
            BindGridData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridData();
        }
    }
}
