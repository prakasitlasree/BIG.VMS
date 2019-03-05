using BIG.VMS.DATASERVICE;
using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.MODEL.EntityModel;
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
    public partial class frmVisitorOut : Form
    {
        private readonly VisitorServices _service = new VisitorServices();
        private ContainerVisitor _container = new ContainerVisitor();

        public frmVisitorOut()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string NO = txtNo.Text;
            var res = _service.GetVisitorByNo(NO);
            if (res.Status)
            {
                _container = res;


                if (_container.TRN_VISITOR != null && _container.TRN_VISITOR.AUTO_ID >0)
                {
                    txtPersonInfo.Text = _container.TRN_VISITOR.FIRST_NAME + " " + _container.TRN_VISITOR.LAST_NAME;
                    if (_container.TRN_VISITOR.MAS_PROVINCE != null)
                    {
                        txtCarInfo.Text = _container.TRN_VISITOR.MAS_PROVINCE.NAME + " " + _container.TRN_VISITOR.LICENSE_PLATE;
                    }
                    else
                    {
                        txtCarInfo.Text = "ไม่ได้นำรถมา";
                    }

                }
                else
                {
                    MessageBox.Show("ไม่มีข้อมูล");
                    txtPersonInfo.Text = "";
                    txtCarInfo.Text = "";
                    _container.TRN_VISITOR = null;
                }


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (_container.TRN_VISITOR != null)
            {
                var obj = new TRN_VISITOR();
                obj = _container.TRN_VISITOR;
                obj.TYPE = "Out";

                var container = new ContainerVisitor { TRN_VISITOR = obj };

                var res = _service.Create(container);

                if (res.Status)
                {
                    MessageBox.Show(Message.MSG_SAVE_COMPLETE);
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                else
                {
                    MessageBox.Show(res.Message + res.ExceptionMessage);
                }
            }
            else
            {
                MessageBox.Show("ไม่มีข้อมูล");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
