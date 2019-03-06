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
            var res = _service.GetVisitorForOutByNo(NO);

            if (res.Status)
            {
                _container = res;


                if (_container.TRN_VISITOR != null && _container.TRN_VISITOR.AUTO_ID > 0)
                {
                    btnSave.Enabled = true;

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

                    MessageBox.Show("ไม่มีข้อมูล", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPersonInfo.Text = "";
                    txtCarInfo.Text = "";
                    _container.TRN_VISITOR = null;
                    btnSave.Enabled = false;


                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();

        }

        private void Save()
        {
            try
            {
                if (_container.TRN_VISITOR != null)
                {
                    var res = _service.UpdateVisitorOut(_container);
                    if (res.Status)
                    {

                        res = _service.GetItem(_container);
                        if (res.Status)
                        {
                            var org_obj = _container.TRN_VISITOR;
                            int no = Convert.ToInt32(res.TRN_VISITOR.NO);
                            no = no + 1;
                            var obj = new TRN_VISITOR()
                            {

                                NO = no.ToString("D6"),
                                ID_CARD = org_obj.ID_CARD,
                                ID_CARD_PHOTO = org_obj.ID_CARD_PHOTO,
                                TYPE = "Out",
                                FIRST_NAME = org_obj.FIRST_NAME,
                                LAST_NAME = org_obj.LAST_NAME,
                                CAR_MODEL_ID = org_obj.CAR_MODEL_ID,
                                LICENSE_PLATE = org_obj.LICENSE_PLATE,
                                LICENSE_PLATE_PROVINCE_ID = org_obj.LICENSE_PLATE_PROVINCE_ID,
                                REASON_ID = org_obj.REASON_ID,
                                CONTACT_EMPLOYEE_ID = org_obj.CONTACT_EMPLOYEE_ID,
                                CONTACT_PHOTO = org_obj.CONTACT_PHOTO,
                                STATUS = 2,
                                CREATED_DATE = DateTime.Now,
                                UPDATED_DATE = DateTime.Now


                            };

                            var container = new ContainerVisitor { TRN_VISITOR = obj };
                            res = _service.Create(container);

                            if (res.Status)
                            {
                                MessageBox.Show(Message.MSG_SAVE_COMPLETE, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show(res.ExceptionMessage, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show(res.ExceptionMessage, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(res.ExceptionMessage, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("ไม่มีข้อมูล", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
