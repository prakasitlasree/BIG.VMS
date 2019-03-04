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

namespace BIG.VMS.PRESENT.Forms.FormIn
{
    public partial class frmIn : PageBase
    {
        private readonly VisitorServices _service = null;
        private ContainerVisitor _container = null;
        private ComboBoxServices _comboService = new ComboBoxServices();
        public frmIn()
        {
            _service = new VisitorServices();
            InitializeComponent();
        }
        public bool ThumbnailCallback()
        {
            return false;
        }
        private void frmIn_Load(object sender, EventArgs e)
        {
            try
            {
                InitialLoad();
                InitialComboBox();
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
                Txt_No.Text = no.ToString("D6");
            }
            else
            {
                MessageBox.Show(res.ExceptionMessage);
            }         

        }

        private void InitialComboBox()
        {
            var comboEmployeeData = _comboService.GetComboEmployee();
            AddRangeComboBox(combMeet, comboEmployeeData);
            var comboProvinceData = _comboService.GetComboProvince();
            AddRangeComboBox(comboCarProvince, comboProvinceData);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {

            var obj = new TRN_VISITOR
            {
                NO = Txt_No.Text.Trim(),
                ID_CARD = Txt_IDCard.Text.Trim(),
                LICENSE_PLATE = Txt_LicensePlate.Text.Trim(),
                TOPIC = Txt_Topic.Text.Trim(),
                TYPE = "IN",  
                //CREATED_BY      
                CREATED_DATE = DateTime.Now,
                UPDATED_DATE = DateTime.Now,
                //UPDATED_BY      
            };

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

        private void btnReadCard_Click(object sender, EventArgs e)
        {

        }

        private void brn_UploadImgCard_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    try
                    {
                        var myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                        var myBitmap = new Bitmap(file);
                        var myImg = myBitmap.GetThumbnailImage(150, 149, myCallback, IntPtr.Zero);
                        picCard.Image = myImg;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnUploadCam_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    try
                    {
                        var myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                        var myBitmap = new Bitmap(file);
                        var myImg = myBitmap.GetThumbnailImage(150, 149, myCallback, IntPtr.Zero);
                        picPhoto.Image = myImg; 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void bthCardDelete_Click(object sender, EventArgs e)
        {
            picCard.Image = BIG.VMS.PRESENT.Properties.Resources.emploee; 
        }

        private void btnDeleteCam_Click(object sender, EventArgs e)
        {
            picPhoto.Image = BIG.VMS.PRESENT.Properties.Resources.emploee;  
        }

        private void btnVehicle_Click(object sender, EventArgs e)
        {

        }
    }
}
