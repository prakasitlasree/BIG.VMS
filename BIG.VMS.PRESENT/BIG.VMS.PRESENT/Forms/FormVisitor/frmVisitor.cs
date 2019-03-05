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
    public partial class frmVisitor : Form
    {
        public FormMode formMode = new FormMode();
        public VisitorMode visitorMode = new VisitorMode();
        private readonly VisitorServices _service = new VisitorServices();
        private ContainerVisitor _container = new ContainerVisitor();
        private ComboBoxServices _comboService = new ComboBoxServices();

        public int contactEmployeeId = 0;
        public int provinceId = 0;
        public int carModelId = 0;

        public frmVisitor()
        {
            InitializeComponent();
        }

        private void frmVisitor_Load(object sender, EventArgs e)
        {
            try
            {
                InitialLoad();

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

        private void Save()
        {

            var obj = new TRN_VISITOR
            {
                NO = txtNo.Text.Trim(),
                ID_CARD = txtIDCard.Text.Trim(),
                FIRST_NAME = txtFirstName.Text.Trim(),
                LAST_NAME = txtLastName.Text.Trim(),
                LICENSE_PLATE = txtLicense.Text.Trim(),
                //TOPIC = txtTopic.Text.Trim(),
                CONTACT_EMPLOYEE_ID = contactEmployeeId,
                CAR_MODEL_ID = carModelId,
                LICENSE_PLATE_PROVINCE_ID = provinceId,

                CREATED_DATE = DateTime.Now,
                UPDATED_DATE = DateTime.Now,

            };

            if (visitorMode == VisitorMode.In)
            {
                obj.TYPE = "เข้า";
            }
            if (visitorMode == VisitorMode.Out)
            {
                obj.TYPE = "ออห";
            }
            if (visitorMode == VisitorMode.Appointment)
            {
                obj.TYPE = "นัดล่วงหน้า";
            }
            if (visitorMode == VisitorMode.ComeOften)
            {
                obj.TYPE = "มาประจำ";
            }

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
                !string.IsNullOrEmpty(txtCar.Text))
            {
                if (MessageBox.Show("ต้องการบันทึกข้อมูลใช่หรือไม่ ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Save();
                }

            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        }
    }
}
