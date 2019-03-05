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

namespace BIG.VMS.PRESENT.Forms.FormAppoinment
{
    public partial class frmAppoinmentKeyIn : PageBase
    {
        private readonly AppointmentServices _service = new AppointmentServices();
        private ContainerVisitor _container = new ContainerVisitor();
        private ComboBoxServices _comboServices = new ComboBoxServices();
        public frmAppoinmentKeyIn()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("", Message.MSG_SAVE_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Save();
            }
            
        }

        private void Save()
        {
            var obj = new TRN_APPOINTMENT
            {
                REQUEST_FIRST_NAME = txtFirstName.Text,
                REQUEST_LAST_NAME = txtSurName.Text,
                REQUEST_ID_CARD = txtIDCard.Text,
                REQUEST_LICENSE_PLATE = txtCarLicense.Text,
                //REQUEST_LICENSE_PLATE_PROVINCE_ID = Convert.ToInt32(comboProvince.SelectedValue),            
                //REQUEST_CAR_MODEL_ID = Convert.ToInt32(comboVehicleModel.SelectedValue),
                //STATUS
                //CONTACT_TOPIC = txtPurpose.Text,
                //CONTACT_EMPLOYEE_ID = Convert.ToInt32(comboMeetName.SelectedValue),
                CONTACT_DATE = dtMeetDate.Value,
                
                CREATED_DATE = DateTime.Now,
                UPDATED_DATE = DateTime.Now,
                
            };

            var container = new ContainerAppointment { TRN_APPOINTMENT = obj };

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

        private void txtSurName_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAppoinmentKeyIn_Load(object sender, EventArgs e)
        {
           
            InitialComboBox();
        }
        private void InitialComboBox()
        {
            AddRangeComboBox(comboDept, _comboServices.GetComboDepartment());
            AddRangeComboBox(comboVehicleModel, _comboServices.GetComboCarModel());
            AddRangeComboBox(comboProvince, _comboServices.GetComboProvince());
            AddRangeComboBox(comboProvince, _comboServices.GetComboEmployee());
        }
        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            var deptId = Convert.ToInt32(comboDept.SelectedValue);
            AddRangeComboBox(comboMeetName, _comboServices.GetComboEmployeeByDepartmentID(deptId));
        }
    }
}
