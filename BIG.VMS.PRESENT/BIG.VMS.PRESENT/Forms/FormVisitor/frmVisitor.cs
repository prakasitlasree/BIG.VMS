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
using BIG.VMS.MODEL.CustomModel.CustomContainer;
using CrystalDecisions.CrystalReports.Engine;
using BIG.VMS.PRESENT.Forms.FormReport;
using System.Drawing.Imaging;
using CrystalDecisions.Shared;

namespace BIG.VMS.PRESENT.Forms.FormVisitor
{
    public partial class frmVisitor : PageBase
    {
        public FormMode formMode = new FormMode();
        public VisitorMode visitorMode = new VisitorMode();
        private readonly VisitorServices _service = new VisitorServices();

        private ContainerVisitor _container = new ContainerVisitor();
        private ComboBoxServices _comboService = new ComboBoxServices();
        private ContainerBlackList _blContainer = new ContainerBlackList();
        private readonly BlackListServices _blService = new BlackListServices();

        private Image defaultImage;
        private Image defaultPhoto;
        public TRN_VISITOR visitorObj = new TRN_VISITOR();
        public int contactEmployeeId = 0;
        public int provinceId = 0;
        public int carModelId = 0;
        public int reasonId = 0;
        public bool isChangeCardPhoto;
        public bool isChangePhoto = false;

        public Image CARD_IMAGE { get; set; }

        public byte[] BYTE_IMAGE { get; set; }

        public frmVisitor()
        {
            InitializeComponent();
        }

        private void frmVisitor_Load(object sender, EventArgs e)
        {
            try
            {
                defaultImage = picCard.Image;
                Image defaultPhoto = picPhoto.Image;
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
            try
            {
                // _container = new ContainerVisitor();
                if (formMode == FormMode.Add)
                {
                    var res = _service.GetLastUserNo();
                    if (res.Status)
                    {
                        int no = Convert.ToInt32(res.TRN_VISITOR.NO);
                        no = no + 1;
                        txtNo.Text = no.ToString();
                    }
                    else
                    {
                        MessageBox.Show(res.ExceptionMessage);
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        Timer tmr = null;

        private void StartTimer()
        {

            tmr = new Timer();
            tmr.Interval = 1000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;

        }

        void tmr_Tick(object sender, EventArgs e)
        {

            label6.Text = DateTime.Now.ToString();

        }

        private void SetControl()
        {
            try
            {
                if (formMode == FormMode.Add)
                {
                    StartTimer();
                    btnBlacklist.Visible = false;
                }
                if (visitorMode == VisitorMode.Appointment || formMode == FormMode.Edit)
                {
                    #region === hid control ===
                    if (formMode == FormMode.Edit)
                    {
                        brn_UploadImgCard.Visible = false;
                        btnRefresh.Visible = false;
                        bthCardDelete.Visible = false;
                        txtNo.Text = visitorObj.NO.ToString();
                    }

                    if (visitorMode == VisitorMode.Appointment)
                    {
                        label5.Text = "นัดล่วงหน้า";
                    }
                    if (visitorMode == VisitorMode.In)
                    {
                        label5.Text = "เข้า";
                    }
                    if (visitorMode == VisitorMode.Out)
                    {
                        label5.Text = "ออก";
                    }

                    #endregion

                    txtIDCard.Text = visitorObj.ID_CARD;
                    txtFirstName.Text = visitorObj.FIRST_NAME;
                    txtLastName.Text = visitorObj.LAST_NAME;
                    txtLicense.Text = visitorObj.LICENSE_PLATE;
                    label6.Text = visitorObj.CREATED_DATE.ToString();
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
                        txtLicense.Text = "";
                        txtLicense.Enabled = false;
                        Lbl_LicensePlate.Visible = false;
                        txtLicense.Visible = false;
                        Lbl_Vahicle.Visible = false;
                        txtProvince.Visible = false;
                        btnProvince.Visible = false;
                        btnLicense.Visible = false;
                        tableLayoutPanel2.Visible = false;
                        tableLayoutPanel8.Visible = false;
                        provinceId = 0;
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

                    if (visitorObj.TRN_ATTACHEDMENT != null)
                    {
                        if (visitorObj.TRN_ATTACHEDMENT.Count > 0)
                        {
                            if (visitorObj.TRN_ATTACHEDMENT.FirstOrDefault().CONTACT_PHOTO != null)
                            {
                                picPhoto.Image = ByteToImage(visitorObj.TRN_ATTACHEDMENT.FirstOrDefault().CONTACT_PHOTO);
                            }
                            if (visitorObj.TRN_ATTACHEDMENT.FirstOrDefault().ID_CARD_PHOTO != null)
                            {
                                picCard.Image = ByteToImage(visitorObj.TRN_ATTACHEDMENT.FirstOrDefault().ID_CARD_PHOTO);
                            }
                        }


                    }


                }
            }
            catch (Exception)
            {

                throw;
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


        public byte[] ImageToByte(Image source)
        {
            try
            {
                if (source != null)
                {
                    Image img = source;
                    using (var ms = new MemoryStream())
                    {
                        Bitmap bmp = new Bitmap(img);
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        return ms.ToArray();

                    }
                }
                else
                {

                    return BYTE_IMAGE;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private ContainerBlackList isBlackList(string idCard)
        {
            try
            {
                var data = _blService.GetBlackListByIdCard(idCard);

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private TRN_VISITOR GetObjectfromControl()
        {
            try
            {
                var obj = new TRN_VISITOR
                {
                    NO = Convert.ToInt32(txtNo.Text),
                    ID_CARD = txtIDCard.Text.Trim(),
                    FIRST_NAME = txtFirstName.Text.Trim(),
                    LAST_NAME = txtLastName.Text.Trim(),
                    LICENSE_PLATE = txtLicense.Text.Trim(),
                    STATUS = 1,
                    CONTACT_EMPLOYEE_ID = contactEmployeeId,
                    CAR_MODEL_ID = carModelId,
                    REASON_ID = reasonId,

                    CREATED_DATE = DateTime.Now,
                    UPDATED_DATE = DateTime.Now,
                    YEAR = DateTime.Now.Year,
                    MONTH = DateTime.Now.Month

                };

                if (provinceId == 0)
                {
                    obj.LICENSE_PLATE_PROVINCE_ID = null;
                }
                else
                {
                    obj.LICENSE_PLATE_PROVINCE_ID = provinceId;
                }

                if (formMode == FormMode.Add)
                {
                    obj.CREATED_BY = LOGIN;
                    obj.UPDATED_BY = LOGIN;
                }
                if (formMode == FormMode.Edit)
                {
                    obj.UPDATED_BY = LOGIN;
                    obj.AUTO_ID = visitorObj.AUTO_ID;
                    if (isChangePhoto || isChangeCardPhoto)
                    {
                        var attachment = new TRN_ATTACHEDMENT();

                        if (isChangePhoto)
                        {
                            attachment.CONTACT_PHOTO = ImageToByte(picPhoto);
                        }
                        else
                        {
                            if (visitorObj.TRN_ATTACHEDMENT.Count > 0)
                            {
                                attachment.CONTACT_PHOTO = visitorObj.TRN_ATTACHEDMENT.FirstOrDefault().CONTACT_PHOTO;
                            }
                        }
                        if (isChangeCardPhoto)
                        {
                            attachment.ID_CARD_PHOTO = ImageToByte(picCard);
                        }
                        else
                        {
                            if (visitorObj.TRN_ATTACHEDMENT.Count > 0)
                            {
                                attachment.ID_CARD_PHOTO = visitorObj.TRN_ATTACHEDMENT.FirstOrDefault().ID_CARD_PHOTO;
                            }

                        }


                        obj.TRN_ATTACHEDMENT = new List<TRN_ATTACHEDMENT>();
                        obj.TRN_ATTACHEDMENT.Add(attachment);
                    }


                }

                return obj;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Save()
        {
       
            try
            {

                if (formMode == FormMode.Add)
                {
                    var obj = GetObjectfromControl();
                    string dir = DIRECTORY_IN + "\\" + obj.NO + "\\";
                    Directory.CreateDirectory(dir);
                    var attachment = new TRN_ATTACHEDMENT();
                    if (isChangePhoto || isChangeCardPhoto)
                    {
                        
                        if (isChangePhoto)
                        {
                            attachment.CONTACT_PHOTO = ImageToByte(picPhoto);
                        }
                        else
                        {
                            attachment.CONTACT_PHOTO = BYTE_IMAGE;
                        }
                        if (isChangeCardPhoto)
                        {
                            attachment.ID_CARD_PHOTO = ImageToByte(picCard);
                        }
                        else
                        {
                            attachment.ID_CARD_PHOTO = BYTE_IMAGE;
                        }
                        obj.TRN_ATTACHEDMENT = new List<TRN_ATTACHEDMENT>();
                        obj.TRN_ATTACHEDMENT.Add(attachment);
                        attachment.PHOTO_URL = dir;
                    }

                    if (visitorMode == VisitorMode.In)
                    {
                        obj.TYPE = VisitorMode.In.ToString();                              
                        picCard.Image.Save(dir+"ID_CARD.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        picPhoto.Image.Save(dir+ "PHOTO.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);


                    }
                    if (visitorMode == VisitorMode.Out)
                    {
                        obj.TYPE = VisitorMode.Out.ToString();
                    }
                    if (visitorMode == VisitorMode.Appointment)
                    {
                        obj.TYPE = VisitorMode.Appointment.ToString();
                        picCard.Image.Save(dir + "ID_CARD.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        picPhoto.Image.Save(dir + "PHOTO.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    if (visitorMode == VisitorMode.Regulary)
                    {
                        obj.TYPE = VisitorMode.Regulary.ToString();
                    }

                    var container = new ContainerVisitor { TRN_VISITOR = obj };

                    var res = _service.Create(container);

                    if (res.Status)
                    {
                        PrintSlip(res.ResultObj.AUTO_ID,obj.NO);
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
                    var obj = GetObjectfromControl();

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
            catch (Exception)
            {

                throw;
            }

        }

        private void PrintSlip(int id,int? no)
        {
            var obj = _service.GetVisitorByAutoIDForReport(id);
            var reportPara = _service.GetReportParameter();
            if (obj.ResultObj.Count > 0)
            {
                List<CustomVisitor> listData = (List<CustomVisitor>)obj.ResultObj;
                DataTable dt = ConvertToDataTable(listData);

                ReportDocument rpt = new ReportDocument();
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                var appPath = Application.StartupPath + "\\" + "ReportSlip.rpt";

                rpt.Load(appPath);
                rpt.SetDataSource(dt);
                rpt.PrintToPrinter(1, true, 0, 0);

                
                rpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                rpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                string dir = DIRECTORY_IN + "\\" + no + "\\";
                objDiskOpt.DiskFileName = dir + "SLIP.pdf";
                rpt.ExportOptions.DestinationOptions = objDiskOpt;
                rpt.Export();
            }
        }

        private bool IsValidCheckPersonID(string pid)
        {
            try
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
                }

                mod = total % 11;
                nsub = 11 - mod;
                mod2 = nsub % 10;

                int.TryParse(numberChars[12].ToString(), out numberChars12);
                if (mod2 != numberChars12)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool IsNeedProvice()
        {
            if (txtCar.Text == "เดินเท้า" || txtCar.Text == "ไม่ระบุ")
            {
                return true;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtCar.Text) && !string.IsNullOrEmpty(txtLicense.Text))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private bool IsChangePicCard()
        {
            if (formMode == FormMode.Add)
            {

                if (defaultImage != picCard.Image)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        #region ============= EVENTS  =============
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
            try
            {
                if (!string.IsNullOrEmpty(txtFirstName.Text) &&
                    !string.IsNullOrEmpty(txtLastName.Text) &&
                    !string.IsNullOrEmpty(txtIDCard.Text) &&
                    !string.IsNullOrEmpty(txtMeet.Text) &&
                    !string.IsNullOrEmpty(txtTopic.Text) &&
                    !string.IsNullOrEmpty(txtCar.Text) &&
                    IsNeedProvice() &&
                    contactEmployeeId > 0 && carModelId > 0 && reasonId > 0)
                {
                    //if (IsValidCheckPersonID(txtIDCard.Text))
                    //{
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
                    //}
                    //else
                    //{
                    //    MessageBox.Show("บัตรประชาชนไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                }

                else
                {
                    MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            try
            {
                frmCar frm = new frmCar();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    carModelId = frm.SELECTED_CAR_ID;
                    txtCar.Text = frm.SELECTED_CAR_TEXT;
                    if (frm.SELECTED_CAR_TEXT == "เดินเท้า" || frm.SELECTED_CAR_TEXT == "ไม่ระบุ")
                    {
                        txtLicense.Text = "";
                        txtLicense.Enabled = false;
                        Lbl_LicensePlate.Visible = false;
                        txtLicense.Visible = false;
                        Lbl_Vahicle.Visible = false;
                        txtProvince.Visible = false;
                        btnProvince.Visible = false;
                        btnLicense.Visible = false;
                        tableLayoutPanel2.Visible = false;
                        tableLayoutPanel8.Visible = false;
                        provinceId = 0;
                    }
                    else
                    {
                        Lbl_LicensePlate.Visible = true;
                        txtLicense.Visible = true;
                        txtLicense.Enabled = true;
                        Lbl_Vahicle.Visible = true;
                        txtProvince.Visible = true;
                        btnProvince.Visible = true;
                        btnLicense.Visible = true;
                        tableLayoutPanel2.Visible = true;
                        tableLayoutPanel8.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnMeet_Click(object sender, EventArgs e)
        {
            try
            {
                frmEmployee frm = new frmEmployee();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    contactEmployeeId = frm.SELECTED_EMPLOYEE_ID;
                    txtMeet.Text = frm.SELECTED_EMPLOYEE_TEXT;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnTopic_Click(object sender, EventArgs e)
        {
            try
            {
                frmReason frm = new frmReason();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    reasonId = frm.SELECTED_REASON_ID;
                    txtTopic.Text = frm.SELECTED_REASON_TEXT;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new CardSelection();
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.READ_CARD_STATUS)
                    {
                        if (frm.CARD_TYPE == "PID")
                        {
                            //บัตรประชาชน
                            txtFirstName.Text = frm.CARD.TH_FIRST_NAME;
                            txtLastName.Text = frm.CARD.TH_LAST_NAME;
                            txtIDCard.Text = frm.CARD.NO;
                            picCard.Image = (Image)frm.CARD.PHOTO;
                            CARD_IMAGE = frm.CARD.CARD_IMAGE;
                            BYTE_IMAGE = frm.CARD.BYTE_IMAGE;
                            isChangeCardPhoto = false;
                            MessageBox.Show("อ่านข้อมูลจากบัตรประชาชน เรียบร้อย!!!");
                        }
                        else
                        {
                            //ใบขับขี่
                            txtFirstName.Text = frm.DID.FIRST_NAME_EN;
                            txtLastName.Text = frm.DID.LAST_NAME_EN;
                            txtIDCard.Text = frm.DID.NO;
                            MessageBox.Show("อ่านข้อมูลจากใบขับขี่ เรียบร้อย!!!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

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



        private void brn_UploadImgCard_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                dialog.InitialDirectory = @"C:\";
                dialog.Title = "Please select an image file to encrypt.";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string path = dialog.FileName;
                    picCard.Image = Image.FromFile(path);
                    CARD_IMAGE = null;
                    BYTE_IMAGE = null;
                    isChangeCardPhoto = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bthCardDelete_Click(object sender, EventArgs e)
        {
            picCard.Image = Properties.Resources.emploee;
        }

        private void btnDeleteCam_Click(object sender, EventArgs e)
        {
            picPhoto.Image = Properties.Resources.emploee;
        }

        private void btnBlacklist_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUploadCam_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                dialog.InitialDirectory = @"C:\";
                dialog.Title = "Please select an image file to encrypt.";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string path = dialog.FileName;
                    picPhoto.Image = Image.FromFile(path);
                    isChangePhoto = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //picCard
        }

        private void txtIDCard_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIDCard_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnLicense_Click(object sender, EventArgs e)
        {
            frmKeyboard frm = new frmKeyboard();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtLicense.Text = frm.text;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
