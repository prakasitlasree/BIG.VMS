using BIG.VMS.DATASERVICE;
using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.MODEL.EntityModel;
using BIG.VMS.PRESENT.Forms.FormCarMasterDetail;
using BIG.VMS.PRESENT.Forms.Home;
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
    public partial class frmVisitor : PageBase
    {
        public FormMode formMode = new FormMode();
        public VisitorMode visitorMode = new VisitorMode();
        private readonly VisitorServices _service = new VisitorServices();
        private ContainerVisitor _container = null;
        private ComboBoxServices _comboService = new ComboBoxServices();
        public frmVisitor()
        {
            InitializeComponent();
        }



        private void frmVisitor_Load(object sender, EventArgs e)
        {
            SetControl();
            if (formMode == FormMode.Add)
            {
                InitialLoad();
                InitialComboBox();
            }
        }

        private void SetControl()
        {

            if (formMode == FormMode.View)
            {
                foreach (var control in this.Controls)
                {
                    if (control is TextBox)
                    {
                        ((TextBox)control).Enabled = false;
                    }
                    else if (control is Button)
                    {
                        ((Button)control).Enabled = false;
                    }
                }
            }

            if (visitorMode == VisitorMode.In)
            {
                lblMode.Text = "เข้า";
                // btnMeet.Visible = false;
                //btnVehicle.Visible = false;
                lblMeetDate.Visible = false;
                dtMeetDate.Visible = false;
                comboCarType.Visible = false;
                comboCarBrand.Visible = false;
                comboCarModel.Visible = false;
                btnAddCarBrand.Visible = false;
                btnAddCarModel.Visible = false;
            }
            else if (visitorMode == VisitorMode.Out)
            {
                lblMode.Text = "ออก";
                //btnMeet.Visible = false;
                //btnVehicle.Visible = false;
                Txt_Topic.Visible = false;
                lblMeetDate.Visible = false;
                dtMeetDate.Visible = false;
                tableLayoutCar.Visible = false;
                tableLayoutMeet.Visible = false;
                comboCarType.Visible = false;
                comboCarBrand.Visible = false;
                comboCarModel.Visible = false;
                btnAddCarBrand.Visible = false;
                btnAddCarModel.Visible = false;

            }
            else if (visitorMode == VisitorMode.Appointment)
            {
                lblMode.Text = "นัดล่วงหน้า";
                //btnBlacklist.Visible = false;
            }
            else if (visitorMode == VisitorMode.ComeOften)
            {
                lblMode.Text = "มาประจำ";
                //btnMeet.Visible = false;
                //btnVehicle.Visible = false;
                lblMeetDate.Visible = false;
                dtMeetDate.Visible = false;
                comboCarType.Visible = false;
                comboCarBrand.Visible = false;
                comboCarModel.Visible = false;
                btnAddCarBrand.Visible = false;
                btnAddCarModel.Visible = false;
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

            AddRangeComboBox(comboDept, _comboService.GetComboDepartment());
            AddRangeComboBox(comboProvince, _comboService.GetComboProvince());
            AddRangeComboBox(comboCarType, _comboService.GetComboCarType());
        }
        private void comboCarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddRangeComboBox(comboCarBrand, _comboService.GetComboCarBrandByTypeID(Convert.ToInt32(comboCarType.SelectedValue)));
        }

        private void comboCarBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddRangeComboBox(comboCarModel, _comboService.GetComboCarModelByBrandID(Convert.ToInt32(comboCarBrand.SelectedValue)));
        }


        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddRangeComboBox(comboEmployee, _comboService.GetComboEmployeeByDepartmentID(Convert.ToInt32(comboDept.SelectedValue)));
        }

        private void chkCar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCar.Checked)
            {
                comboProvince.Enabled = true;
                txtLicenseText.Enabled = true;
                txtLicenseNumber.Enabled = true;
                dtMeetDate.Enabled = true;
                comboCarModel.Enabled = true;
                comboCarType.Enabled = true;
                comboCarBrand.Enabled = true;
                btnAddCarBrand.Enabled = true;
                btnAddCarModel.Enabled = true;
            }
            else
            {
                comboProvince.Enabled = false;
                txtLicenseText.Enabled = false;
                txtLicenseNumber.Enabled = false;
                dtMeetDate.Enabled = false;
                comboCarModel.Enabled = false;
                comboCarType.Enabled = false;
                comboCarBrand.Enabled = false;
                btnAddCarBrand.Enabled = false;
                btnAddCarModel.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidCheckPersonID(Txt_IDCard.Text))
            {
                DialogResult result = MessageBox.Show("ต้องการบันทึกข้อมูลใช่หรอไม่", Message.MSG_SAVE_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Save();
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("บัตรประชาชนไม่ถูกต้อง", Message.MSG_SAVE_CONFIRM, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void Save()
        {

            var obj = new TRN_VISITOR
            {
                NO = Txt_No.Text.Trim(),
                ID_CARD = Txt_IDCard.Text.Trim(),
                LICENSE_PLATE = txtLicenseText.Text.Trim() + " " + txtLicenseNumber.Text.Trim(),
                TOPIC = Txt_Topic.Text.Trim(),

                LICENSE_PLATE_PROVINCE_ID = comboProvince.SelectedValue == null ? (int?)null : Convert.ToInt32(comboProvince.SelectedValue),
                CONTACT_EMPLOYEE_ID = comboEmployee.SelectedValue == null ? (int?)null : Convert.ToInt32(comboEmployee.SelectedValue),

                CREATED_DATE = DateTime.Now,
                UPDATED_DATE = DateTime.Now,
            };


            #region === VISITOR ===
            if (visitorMode == VisitorMode.In)
            {
                obj.TYPE = "IN";
            }
            else if (visitorMode == VisitorMode.Out)
            {
                obj.TYPE = "OUT";
            }
            else if (visitorMode == VisitorMode.ComeOften)
            {
                obj.TYPE = "COME OFTEN";
            }
            else if (visitorMode == VisitorMode.Appointment)
            {
                obj.TYPE = "APPOINTMENT";
                SaveAppointment();
            }
            #endregion

            var container = new ContainerVisitor { TRN_VISITOR = obj };

            var res = _service.Create(container);

            if (res.Status)
            {
                MessageBox.Show(Message.MSG_SAVE_COMPLETE);
                this.DialogResult = DialogResult.OK;

                frmAllvisitor frm = new frmAllvisitor();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this.ParentForm;
                frm.Show();

                //this.Close();
                this.Close();

            }
            else
            {
                MessageBox.Show(res.Message + res.ExceptionMessage);
            }

        }

        private void SaveAppointment()
        {
            var obj = new TRN_APPOINTMENT
            {
                REQUEST_FIRST_NAME = Txt_Name.Text,
                REQUEST_LAST_NAME = Txt_LastName.Text,
                REQUEST_ID_CARD = Txt_IDCard.Text,
                REQUEST_LICENSE_PLATE = txtLicenseText.Text.Trim() + " " + txtLicenseNumber.Text.Trim(),
                REQUEST_LICENSE_PLATE_PROVINCE_ID = comboProvince.SelectedValue == null ? (int?)null : Convert.ToInt32(comboProvince.SelectedValue),
                REQUEST_CAR_MODEL_ID = comboCarModel.SelectedValue == null ? (int?)null : Convert.ToInt32(comboCarModel.SelectedValue),
                //STATUS
                CONTACT_TOPIC = Txt_Topic.Text,
                CONTACT_EMPLOYEE_ID = comboEmployee.SelectedValue == null ? (int?)null : Convert.ToInt32(comboEmployee.SelectedValue),
                CONTACT_DATE = dtMeetDate.Value,

                CREATED_DATE = DateTime.Now,
                UPDATED_DATE = DateTime.Now,

            };

            var container = new ContainerAppointment { TRN_APPOINTMENT = obj };
            AppointmentServices _service = new AppointmentServices();
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

        private void btnAddCarBrand_Click(object sender, EventArgs e)
        {
            frmCarBrandMaster frm = new frmCarBrandMaster();
            frm.ShowDialog();
        }

        private void btnAddCarModel_Click(object sender, EventArgs e)
        {
            frmCarModelMaster frm = new frmCarModelMaster();
            frm.ShowDialog();
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

            //Debug.Log(mod);
            //Debug.Log(nsub);
            //Debug.Log(mod2);


            int.TryParse(numberChars[12].ToString(), out numberChars12);

            //Debug.Log(numberChars12);

            if (mod2 != numberChars12)
                return false;
            else
                return true;
        }
    }
}
