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
    public partial class frmCarBrandMaster : PageBase
    {
        private ComboBoxServices _comboService = new ComboBoxServices();
        private CarBrandServices _service = new CarBrandServices();
        public frmCarBrandMaster()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCarBrandMaster_Load(object sender, EventArgs e)
        {
            InitialComboBox();
        }
        private void InitialComboBox()
        {

            AddRangeComboBox(comboCarType, _comboService.GetComboCarType());

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboCarType.SelectedValue != null && !string.IsNullOrEmpty(txtCarBrand.Text))
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

        private void Save()
        {
            var obj = new MAS_CAR_BRAND
            {
                TYPE_ID = comboCarType.SelectedValue == null ? (int?)null : Convert.ToInt32(comboCarType.SelectedValue),
                NAME = txtCarBrand.Text.Trim()

            };
            var container = new ContainerCarBrand { MAS_CAR_BRAND = obj };
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

