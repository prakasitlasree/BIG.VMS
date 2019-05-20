using BIG.VMS.DATASERVICE;
using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.MODEL.EntityModel;
using BIG.VMS.PRESENT.Forms.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIG.VMS.PRESENT.Forms.FormVisitor
{
    public partial class frmVisitorOut : PageBase
    {
        private readonly VisitorServices _service = new VisitorServices();
        private ContainerVisitor _container = new ContainerVisitor();
        private bool isChangePhoto;
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
                    if (_container.TRN_VISITOR.CONTACT_PHOTO != null)
                    {
                        picImage.Image = ByteToImage(_container.TRN_VISITOR.CONTACT_PHOTO);
                    }
                    if (_container.TRN_VISITOR.ID_CARD_PHOTO != null)
                    {
                        picCard.Image = ByteToImage(_container.TRN_VISITOR.ID_CARD_PHOTO);
                    }
                    else
                    {
                        txtCarInfo.Text = "ไม่ได้นำรถมา";
                    }

                }
                else
                {

                    MessageBox.Show(res.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPersonInfo.Text = "";
                    txtCarInfo.Text = "";
                    _container.TRN_VISITOR = null;
                    btnSave.Enabled = false;


                }
            }
        }

        public Bitmap ByteToImage(byte[] blob)
        {
            try
            {
                MemoryStream mStream = new MemoryStream();
                byte[] pData = blob;
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                Bitmap bm = new Bitmap(mStream, false);
                mStream.Dispose();
                return bm;
            }
            catch (Exception)
            {
                throw;
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
                            //no = no + 1;
                            var obj = new TRN_VISITOR()
                            {

                                NO = no.ToString(),
                                ID_CARD = org_obj.ID_CARD,
                                ID_CARD_PHOTO = org_obj.ID_CARD_PHOTO,
                                TYPE = org_obj.TYPE == "Appointment" ? "AppointmentOut" : "Out",
                                FIRST_NAME = org_obj.FIRST_NAME,
                                LAST_NAME = org_obj.LAST_NAME,
                                CAR_MODEL_ID = org_obj.CAR_MODEL_ID,
                                LICENSE_PLATE = org_obj.LICENSE_PLATE,
                                LICENSE_PLATE_PROVINCE_ID = org_obj.LICENSE_PLATE_PROVINCE_ID,
                                REASON_ID = org_obj.REASON_ID,
                                CONTACT_EMPLOYEE_ID = org_obj.CONTACT_EMPLOYEE_ID,
                                CONTACT_PHOTO = org_obj.CONTACT_PHOTO,
                                STATUS = 2,
                                CREATED_BY = LOGIN,
                                UPDATED_BY = LOGIN,
                                CREATED_DATE = DateTime.Now,
                                UPDATED_DATE = DateTime.Now,
                                YEAR = org_obj.YEAR,
                                MONTH = org_obj.MONTH,

                            };
                            if (isChangePhoto)
                            {
                                obj.CONTACT_PHOTO = ImageToByte(picPhoto);
                            }

                           
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

        public byte[] ImageToByte(PictureBox source)
        {
            try
            {
                Image img = source.Image;
                using (var ms = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(img);
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    return ms.ToArray();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private void btnPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new CameraSelection();
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {

                    if (frm.CAMERA != null)
                    {
                        isChangePhoto = true;
                        picPhoto.Image = frm.CAMERA;
                    }
                    // MessageBox.Show("ถ่ายรูป เรียบร้อย!!!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
