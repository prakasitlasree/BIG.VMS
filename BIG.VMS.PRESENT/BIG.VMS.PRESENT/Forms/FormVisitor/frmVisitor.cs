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
using BIG.VMS.PRESENT.Forms.Master;
using System.IO;
using BIG.VMS.MODEL.CustomModel.Container;

namespace BIG.VMS.PRESENT.Forms.FormVisitor
{
    public partial class frmVisitor : Form
    {
        public FormMode formMode = new FormMode();
        public VisitorMode visitorMode = new VisitorMode();
        private readonly VisitorServices _service = new VisitorServices();
        private readonly BlackListServices _blService = new BlackListServices();
        private ContainerVisitor _container = new ContainerVisitor();
        private ComboBoxServices _comboService = new ComboBoxServices();
        private ContainerBlackList _blContainer = new ContainerBlackList();


        public TRN_VISITOR visitorObj = new TRN_VISITOR();
        public int contactEmployeeId = 0;
        public int provinceId = 0;
        public int carModelId = 0;
        public int reasonId = 0;

        public frmVisitor()
        {
            InitializeComponent();
        }

        private void frmVisitor_Load(object sender, EventArgs e)
        {
            try
            {
                InitialLoad();
                SetControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitialLoad()
        {
            _container = new ContainerVisitor();
            var res = _service.GetItem(_container);
            if (res.Status)
            {
                int no = Convert.ToInt32(res.TRN_VISITOR.NO);
                no = no + 1;
                txtNo.Text = no.ToString("D6");
            }
            else
            {
                MessageBox.Show(res.ExceptionMessage);
            }

        }

        private void SetControl()
        {
            if (formMode == FormMode.Add)
            {
                btnBlacklist.Visible = false;
            }
            if (visitorMode == VisitorMode.Regulary || formMode == FormMode.Edit)
            {

                txtIDCard.Text = visitorObj.ID_CARD;
                txtFirstName.Text = visitorObj.FIRST_NAME;
                txtLastName.Text = visitorObj.LAST_NAME;
                txtLicense.Text = visitorObj.LICENSE_PLATE;

                if (visitorObj.MAS_EMPLOYEE != null)
                {
                    contactEmployeeId = visitorObj.MAS_EMPLOYEE.AUTO_ID;
                    txtMeet.Text = visitorObj.MAS_EMPLOYEE.FIRST_NAME + " " + visitorObj.MAS_EMPLOYEE.LAST_NAME;
                }
                else
                {
                    txtMeet.Text = "";
                }
                if (visitorObj.MAS_REASON != null)
                {
                    reasonId = visitorObj.MAS_REASON.AUTO_ID;
                    txtTopic.Text = visitorObj.MAS_REASON.REASON;
                }
                else
                {
                    txtTopic.Text = "";
                }

                if (visitorObj.MAS_PROVINCE != null)
                {
                    provinceId = visitorObj.MAS_PROVINCE.AUTO_ID;
                    txtProvince.Text = visitorObj.MAS_PROVINCE.NAME;
                }
                else
                {
                    txtProvince.Text = "";
                }

                if (visitorObj.MAS_CAR_MODEL != null)
                {
                    carModelId = visitorObj.MAS_CAR_MODEL.AUTO_ID;
                    txtCar.Text = visitorObj.MAS_CAR_MODEL.NAME;
                }
                else
                {
                    txtCar.Text = "";
                }

                if (visitorObj.CONTACT_PHOTO != null)
                {
                    picPhoto.Image = ByteToImage(visitorObj.CONTACT_PHOTO);
                }
                if (visitorObj.ID_CARD_PHOTO != null)
                {
                    picCard.Image = ByteToImage(visitorObj.ID_CARD_PHOTO);
                }

            }
        }

        public Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        public byte[] ImageToByte(PictureBox source)
        {
            Image img = source.Image;
            using (var ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }

        private ContainerBlackList isBlackList(string idCard)
        {

            var data = _blService.GetBlackListByIdCard(idCard);
            if (data.TRN_BLACKLIST != null)
            {

            }
            return data;
        }

        private void Save()
        {

            if (formMode == FormMode.Add)
            {
                var obj = new TRN_VISITOR
                {
                    NO = txtNo.Text.Trim(),
                    ID_CARD = txtIDCard.Text.Trim(),
                    FIRST_NAME = txtFirstName.Text.Trim(),
                    LAST_NAME = txtLastName.Text.Trim(),
                    LICENSE_PLATE = txtLicense.Text.Trim(),
                    STATUS = 1,
                    CONTACT_EMPLOYEE_ID = contactEmployeeId,
                    CAR_MODEL_ID = carModelId,
                    REASON_ID = reasonId,
                    LICENSE_PLATE_PROVINCE_ID = provinceId,

                    CREATED_DATE = DateTime.Now,
                    UPDATED_DATE = DateTime.Now,

                };

                obj.CONTACT_PHOTO = ImageToByte(picPhoto);
                obj.ID_CARD_PHOTO = ImageToByte(picCard);

                if (visitorMode == VisitorMode.In)
                {
                    obj.TYPE = "In";
                }
                if (visitorMode == VisitorMode.Out)
                {
                    obj.TYPE = "Out";
                }
                if (visitorMode == VisitorMode.Appointment)
                {
                    obj.TYPE = "Appointment";
                }
                if (visitorMode == VisitorMode.Regulary)
                {
                    obj.TYPE = "Regulary";
                }

                var container = new ContainerVisitor { TRN_VISITOR = obj };

                var res = _service.Create(container);

                if (res.Status)
                {

                    MessageBox.Show(Message.MSG_SAVE_COMPLETE, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(res.Message + res.ExceptionMessage);
                }
            }
            if (formMode == FormMode.Edit)
            {
                var obj = new TRN_VISITOR
                {
                    AUTO_ID = visitorObj.AUTO_ID,

                    ID_CARD = txtIDCard.Text.Trim(),
                    FIRST_NAME = txtFirstName.Text.Trim(),
                    LAST_NAME = txtLastName.Text.Trim(),
                    LICENSE_PLATE = txtLicense.Text.Trim(),
                    CONTACT_EMPLOYEE_ID = contactEmployeeId,
                    CAR_MODEL_ID = carModelId,
                    REASON_ID = reasonId,
                    LICENSE_PLATE_PROVINCE_ID = provinceId,
                    UPDATED_DATE = DateTime.Now,
                    CONTACT_PHOTO = ImageToByte(picPhoto),
                    ID_CARD_PHOTO = ImageToByte(picCard),

                };

                var container = new ContainerVisitor { TRN_VISITOR = obj };

                var res = _service.Update(container);

                if (res.Status)
                {

                    MessageBox.Show(Message.MSG_SAVE_COMPLETE, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(res.Message + res.ExceptionMessage);
                }
            }


        }

        private void chkKeyIn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKeyIn.Checked)
            {
                txtFirstName.Enabled = true;
                txtLastName.Enabled = true;
                txtIDCard.Enabled = true;

            }
            else
            {
                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
                txtIDCard.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFirstName.Text) &&
                !string.IsNullOrEmpty(txtLastName.Text) &&
                !string.IsNullOrEmpty(txtIDCard.Text) &&
                !string.IsNullOrEmpty(txtLicense.Text) &&
                !string.IsNullOrEmpty(txtMeet.Text) &&
                !string.IsNullOrEmpty(txtProvince.Text) &&
                !string.IsNullOrEmpty(txtTopic.Text) &&
                !string.IsNullOrEmpty(txtCar.Text) &&
                txtIDCard.TextLength >= 13 &&
                contactEmployeeId > 0 && carModelId > 0 && provinceId > 0 && reasonId > 0)
            {
                if (IsValidCheckPersonID(txtIDCard.Text))
                {
                    var data = _blService.GetBlackListByIdCard(txtIDCard.Text);
                    if (data.TRN_BLACKLIST == null)
                    {
                        if (MessageBox.Show("ต้องการบันทึกข้อมูลใช่หรือไม่ ?", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            Save();
                        }
                    }
                    else
                    {
                        var blData = data.TRN_BLACKLIST;
                        var msg = "เลขบัตรประชาชน : " + blData.ID_CARD + Environment.NewLine + "ชื่อ-สกุล : " + blData.FIRST_NAME + " " + blData.LAST_NAME;
                        msg += Environment.NewLine + "เหตุผล : " + blData.REASON;
                        msg += Environment.NewLine + "ณ วันที่ : " + blData.CREATED_DATE;
                        MessageBox.Show(msg, "บุคคล Blacklist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("บัตรประชาชนไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }


        private void btnProvince_Click(object sender, EventArgs e)
        {
            frmProvince frm = new frmProvince();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                provinceId = frm.SELECTED_PROVINCE_ID;
                txtProvince.Text = frm.SELECTED_PROVINCE_TEXT;
            }
        }

        private void btnVehicle_Click(object sender, EventArgs e)
        {
            frmCar frm = new frmCar();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                carModelId = frm.SELECTED_CAR_ID;
                txtCar.Text = frm.SELECTED_CAR_TEXT;
            }
        }

        private void btnMeet_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                contactEmployeeId = frm.SELECTED_EMPLOYEE_ID;
                txtMeet.Text = frm.SELECTED_EMPLOYEE_TEXT;
            }
        }

        private void btnTopic_Click(object sender, EventArgs e)
        {
            frmReason frm = new frmReason();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                reasonId = frm.SELECTED_REASON_ID;
                txtTopic.Text = frm.SELECTED_REASON_TEXT;
            }
        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            var frm = new CardSelection();
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.CARD_TYPE == "PID")
                {
                    //บัตรประชาชน
                    txtFirstName.Text = frm.CARD.TH_FIRST_NAME;
                    txtLastName.Text = frm.CARD.TH_LAST_NAME;
                    txtIDCard.Text = frm.CARD.NO;
                    picCard.Image = (Image)frm.CARD.PHOTO;
                }
                else
                {
                    //ใบขับขี่
                    txtFirstName.Text = frm.DID.FIRST_NAME_EN;
                    txtLastName.Text = frm.DID.LAST_NAME_EN;
                    txtIDCard.Text = frm.DID.NO;
                }

                MessageBox.Show("อ่านข้อมูลจากบัตร เรียบร้อย!!!");
            }
        }

        private void BtnTakePhoto_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new CameraSelection();
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {

                    MessageBox.Show("ถ่ายรูป เรียบร้อย!!!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private bool IsValidCheckPersonID(string pid)
        {

            char[] numberChars = pid.ToCharArray();

            int total = 0;
            int mul = 13;
            int mod = 0, mod2 = 0;
            int nsub = 0;
            int numberChars12 = 0;

            for (int i = 0; i < numberChars.Length - 1; i++)
            {
                int num = 0;
                int.TryParse(numberChars[i].ToString(), out num);

                total = total + num * mul;
                mul = mul - 1;

                //Debug.Log(total + " - " + num + " - "+mul);
            }

            mod = total % 11;
            nsub = 11 - mod;
            mod2 = nsub % 10;

            int.TryParse(numberChars[12].ToString(), out numberChars12);

            //Debug.Log(numberChars12);

            if (mod2 != numberChars12)
                return false;
            else
                return true;
        }

        private void btnDeleteCam_Click(object sender, EventArgs e)
        {

        }

        private void brn_UploadImgCard_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select an image file to encrypt.";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                picCard.Image = Image.FromFile(path);
            }
        }

        private void bthCardDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnBlacklist_Click(object sender, EventArgs e)
        {
            frmBlackList frm = new frmBlackList();
            frm.FIRST_NAME = txtFirstName.Text;
            frm.LAST_NAME = txtLastName.Text;
            frm.ID_CARD = txtIDCard.Text;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnUploadCam_Click(object sender, EventArgs e)
        {

        }
    }
}
