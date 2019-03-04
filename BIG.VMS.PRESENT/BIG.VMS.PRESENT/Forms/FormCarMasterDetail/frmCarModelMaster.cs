using BIG.VMS.DATASERVICE;
using BIG.VMS.MODEL.CustomModel.Container;
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

namespace BIG.VMS.PRESENT.Forms.FormCarMasterDetail
{
    public partial class frmCarModelMaster : PageBase
    {

        private ComboBoxServices _comboService = new ComboBoxServices();
        private CarModelServices _service = new CarModelServices();
        public frmCarModelMaster()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCarModelMaster_Load(object sender, EventArgs e)
        {
            InitialComboBox();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboCarBrand.SelectedValue != null && !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtCarColor.Text))
            {
                if (MessageBox.Show("", "ต้องการบันทึกข้อมูลใช่หรือไม่", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Save();
                }

            }
            else
            {
                MessageBox.Show("", "กรอกข้อมูลให้ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void InitialComboBox()
        {

            AddRangeComboBox(comboCarType, _comboService.GetComboCarType());

        }

        private void comboCarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddRangeComboBox(comboCarBrand, _comboService.GetComboCarBrandByTypeID(Convert.ToInt32(comboCarType.SelectedValue)));
        }

        private void Save()
        {
            var obj = new MAS_CAR_MODEL
            {
                BRAND_ID = comboCarBrand.SelectedValue == null ? (int?)null : Convert.ToInt32(comboCarBrand.SelectedValue),
                NAME = txtName.Text.Trim(),
                COLOR = txtCarColor.Text.Trim()


            };

            ContainerCarModel container = new ContainerCarModel { MAS_CAR_MODEL = obj };
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
    }
}
