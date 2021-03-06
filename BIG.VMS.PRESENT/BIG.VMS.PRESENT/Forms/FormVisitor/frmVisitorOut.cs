﻿using BIG.VMS.DATASERVICE;
using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.MODEL.EntityModel;
using BIG.VMS.PRESENT.Forms.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
        public bool outFlag = false;
        public int inID = 0;

        public frmVisitorOut()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            frmNumber frm = new frmNumber();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtNo.Text = frm.text;
                int NO = txtNo.Text == "" ? 0 : Convert.ToInt32(txtNo.Text);
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
                        if (_container.TRN_VISITOR.TRN_ATTACHEDMENT != null)
                        {
                            if (_container.TRN_VISITOR.TRN_ATTACHEDMENT.Count > 0)
                            {
                                if (_container.TRN_VISITOR.TRN_ATTACHEDMENT.FirstOrDefault().CONTACT_PHOTO != null)
                                {
                                    picImage.Image = ByteToImage(_container.TRN_VISITOR.TRN_ATTACHEDMENT.FirstOrDefault().CONTACT_PHOTO);
                                }
                                if (_container.TRN_VISITOR.TRN_ATTACHEDMENT.FirstOrDefault().ID_CARD_PHOTO != null)
                                {
                                    picCard.Image = ByteToImage(_container.TRN_VISITOR.TRN_ATTACHEDMENT.FirstOrDefault().ID_CARD_PHOTO);
                                }
                              
                            }

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
                    var res = new ContainerVisitor();
                    if (outFlag)
                    {
                        res = _service.UpdateVisitorOutByID(_container);
                    }
                    else
                    {
                         res = _service.UpdateVisitorOut(_container);
                    }
                   
                    if (res.Status)
                    {

                        res = _service.GetItem(_container);
                        if (res.Status)
                        {
                            var org_obj = _container.TRN_VISITOR;
                            int no = Convert.ToInt32(res.TRN_VISITOR.NO);

                            var obj = new TRN_VISITOR()
                            {

                                NO = org_obj.NO,
                                ID_CARD = org_obj.ID_CARD,

                                TYPE = org_obj.TYPE == "Appointment" ? "AppointmentOut" : "Out",
                                FIRST_NAME = org_obj.FIRST_NAME,
                                LAST_NAME = org_obj.LAST_NAME,
                                CAR_TYPE_ID = org_obj.CAR_TYPE_ID,
                                LICENSE_PLATE = org_obj.LICENSE_PLATE,
                                LICENSE_PLATE_PROVINCE_ID = org_obj.LICENSE_PLATE_PROVINCE_ID,
                                REASON_ID = org_obj.REASON_ID,
                                CONTACT_EMPLOYEE_ID = org_obj.CONTACT_EMPLOYEE_ID,

                                STATUS = 2,
                                CREATED_BY = LOGIN,
                                UPDATED_BY = LOGIN,
                                CREATED_DATE = DateTime.Now,
                                UPDATED_DATE = DateTime.Now,
                                YEAR = org_obj.YEAR,
                                MONTH = org_obj.MONTH,
                                TRN_ATTACHEDMENT = org_obj.TRN_ATTACHEDMENT,
                            };
                            if (isChangePhoto)
                            {
                                if (obj.TRN_ATTACHEDMENT.Count > 0)
                                {
                                    obj.TRN_ATTACHEDMENT.FirstOrDefault().VISITOR_ID = 0;
                                    obj.TRN_ATTACHEDMENT.FirstOrDefault().AUTO_ID = 0;
                                    obj.TRN_ATTACHEDMENT.FirstOrDefault().TRN_VISITOR = null;
                                    obj.TRN_ATTACHEDMENT.FirstOrDefault().CONTACT_PHOTO = ImageToByte(picSlip);
                                }
                                else
                                {
                                    var attach = new TRN_ATTACHEDMENT();
                                    attach.CONTACT_PHOTO = ImageToByte(picSlip);
                                    obj.TRN_ATTACHEDMENT = new List<TRN_ATTACHEDMENT>();
                                    obj.TRN_ATTACHEDMENT.Add(attach);
                                }
                            }
                            else
                            {
                                if (obj.TRN_ATTACHEDMENT.Count > 0)
                                {
                                    obj.TRN_ATTACHEDMENT.FirstOrDefault().VISITOR_ID = 0;
                                    obj.TRN_ATTACHEDMENT.FirstOrDefault().AUTO_ID = 0;
                                    obj.TRN_ATTACHEDMENT.FirstOrDefault().TRN_VISITOR = null;
                                    obj.TRN_ATTACHEDMENT.FirstOrDefault().CONTACT_PHOTO = org_obj.TRN_ATTACHEDMENT.FirstOrDefault().CONTACT_PHOTO;
                                }

                            }


                            var container = new ContainerVisitor { TRN_VISITOR = obj };
                            res = _service.Create(container);

                            if (res.Status)
                            {
                                string dir = DIRECTORY_OUT + "\\" + obj.NO + "\\";
                                Directory.CreateDirectory(dir);

                                if (obj.TRN_ATTACHEDMENT.Count > 0)
                                {
                                    SaveImage(picImage, dir + "PHOTO.jpg");
                                    SaveImage(picCard, dir + "ID_CARD.jpg");
                                }




                                if (isChangePhoto)
                                {
                                    SaveImage(picSlip, dir + "SLIP.jpg");
                                }



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
            catch (Exception ex)
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void SaveImage(PictureBox source, string path)
        {
            try
            {
                Image img = source.Image;
                using (var ms = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(img);
                    bmp.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public byte[] ImageToByte(PictureBox source)
        {
            try
            {
                Image img = source.Image;
                using (var ms = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(img, 240, 120);
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
                        picSlip.Image = frm.CAMERA;
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

        private void frmVisitorOut_Load(object sender, EventArgs e)
        {
            if (outFlag == true)
            {
                var res = _service.GetVisitorForOutByID(inID);

                if (res.Status)
                {
                    _container = res;


                    if (_container.TRN_VISITOR != null && _container.TRN_VISITOR.AUTO_ID > 0)
                    {
                        btnSave.Enabled = true;
                        txtNo.Text = _container.TRN_VISITOR.NO.ToString();
                        txtPersonInfo.Text = _container.TRN_VISITOR.FIRST_NAME + " " + _container.TRN_VISITOR.LAST_NAME;
                        if (_container.TRN_VISITOR.MAS_PROVINCE != null)
                        {
                            txtCarInfo.Text = _container.TRN_VISITOR.MAS_PROVINCE.NAME + " " + _container.TRN_VISITOR.LICENSE_PLATE;
                        }
                        if (_container.TRN_VISITOR.TRN_ATTACHEDMENT != null)
                        {
                            if (_container.TRN_VISITOR.TRN_ATTACHEDMENT.Count > 0)
                            {
                                if (_container.TRN_VISITOR.TRN_ATTACHEDMENT.FirstOrDefault().CONTACT_PHOTO != null)
                                {
                                    picImage.Image = ByteToImage(_container.TRN_VISITOR.TRN_ATTACHEDMENT.FirstOrDefault().CONTACT_PHOTO);
                                }
                                if (_container.TRN_VISITOR.TRN_ATTACHEDMENT.FirstOrDefault().ID_CARD_PHOTO != null)
                                {
                                    picCard.Image = ByteToImage(_container.TRN_VISITOR.TRN_ATTACHEDMENT.FirstOrDefault().ID_CARD_PHOTO);
                                }
                               
                            }

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
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtNo_Click(object sender, EventArgs e)
        {
            //frmNumber frm = new frmNumber();
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    txtNo.Text = frm.text;
            //    btnFind_Click(sender, e);
            //}

        }

        private void txtNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
