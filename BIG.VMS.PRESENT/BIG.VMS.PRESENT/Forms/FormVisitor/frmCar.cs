using BIG.VMS.DATASERVICE;
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
    public partial class frmCar : Form
    {
        private ComboBoxServices _comboService = new ComboBoxServices();
        private int carType = 0;
        private int carBrand = 0;
        private string carBrandText = "";
        public int SELECTED_CAR_ID { get; set; }
        public string SELECTED_CAR_TEXT { get; set; }
        public CarModelServices _service = new CarModelServices();


        public frmCar()
        {
            InitializeComponent();
        }

        private void frmCar_Load(object sender, EventArgs e)
        {
            InitialCarType();
        }

        private void InitialCarType()
        {
            var carType = _comboService.GetComboCarType();

            foreach (var item in carType)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Height = 100;
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.BackColor = Color.FromArgb(232, 249, 102);

                btn.Text = item.Text;
                btn.Tag = item.Value;

                btn.Click += new EventHandler(CarTypeSelected_EventHadler);

                panelCarType.Controls.Add(btn);
            }
        }

        private void CarTypeSelected_EventHadler(object sender, EventArgs e)
        {
            carType = Convert.ToInt32(((Control)sender).Tag.ToString());
            var text = ((Control)sender).Text.ToString();

            if (text == "เดินเท้า")
            {
                var res = _service.GetAutoIDFromCarModel("เดินเท้า");
                if (res.Status)
                {
                    SELECTED_CAR_TEXT = "เดินเท้า";
                    SELECTED_CAR_ID = (int)res.ResultObj;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else if (text == "ไม่ระบุ")
            {
                var res = _service.GetAutoIDFromCarModel("ไม่ระบุ");
                if (res.Status)
                {
                    SELECTED_CAR_TEXT = "ไม่ระบุ";
                    SELECTED_CAR_ID = (int)res.ResultObj;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

            var carBrand = _comboService.GetComboCarBrandByTypeID(carType);

            panelCarBrand.Controls.Clear();
            panelCarModel.Controls.Clear();

            foreach (var item in carBrand)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Height = 100;
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.BackColor = Color.FromArgb(241, 252, 156);

                btn.Text = item.Text;
                btn.Tag = item.Value;

                btn.Click += new EventHandler(CarBrandSelected_EventHadler);


                panelCarBrand.Controls.Add(btn);
            }
        }

        private void CarBrandSelected_EventHadler(object sender, EventArgs e)
        {
            carBrand = Convert.ToInt32(((Control)sender).Tag.ToString());
            carBrandText = ((Control)sender).Text.ToString();
            var carModel = _comboService.GetComboCarModelByBrandID(carBrand);
            panelCarModel.Controls.Clear();

            foreach (var item in carModel)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Height = 100;
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.BackColor = Color.FromArgb(246, 252, 201);

                btn.Click += new EventHandler(CarModelSelected_EventHadler);

                btn.Text = item.Text;
                btn.Tag = item.Value;

                panelCarModel.Controls.Add(btn);
            }
        }

        private void CarModelSelected_EventHadler(object sender, EventArgs e)
        {
            SELECTED_CAR_ID = Convert.ToInt32(((Control)sender).Tag.ToString());
            SELECTED_CAR_TEXT = carBrandText + " " + ((Control)sender).Text.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SearchCarType(string filter)
        {
            var carType = _comboService.GetComboCarType(filter);
            panelCarType.Controls.Clear();
            carBrandText = "";
            foreach (var item in carType)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Height = 100;
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.BackColor = Color.FromArgb(232, 249, 102);

                btn.Text = item.Text;
                btn.Tag = item.Value;

                btn.Click += new EventHandler(CarTypeSelected_EventHadler);

                panelCarType.Controls.Add(btn);
            }
        }

        private void SearchCarBrand(string filter)
        {
            var carBrand = _comboService.GetComboCarBrandByTypeID(carType, filter);
            carBrandText = "";
            panelCarBrand.Controls.Clear();

            foreach (var item in carBrand)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Height = 100;
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.BackColor = Color.FromArgb(241, 252, 156);

                btn.Text = item.Text;
                btn.Tag = item.Value;

                btn.Click += new EventHandler(CarBrandSelected_EventHadler);


                panelCarBrand.Controls.Add(btn);
            }
        }

        private void SearchCarModel(string filter)
        {


            var carModel = _comboService.GetComboCarModelByBrandID(carBrand, filter);

            panelCarModel.Controls.Clear();
            carBrandText = "";
            foreach (var item in carModel)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Height = 100;
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.BackColor = Color.FromArgb(246, 252, 201);

                btn.Text = item.Text;
                btn.Tag = item.Value;

                btn.Click += new EventHandler(CarModelSelected_EventHadler);


                panelCarModel.Controls.Add(btn);
            }
        }

        private void txtCarType_TextChanged(object sender, EventArgs e)
        {
            carType = 0;
            carBrand = 0;
            SELECTED_CAR_ID = 0;
            panelCarBrand.Controls.Clear();
            panelCarModel.Controls.Clear();
            SearchCarType(txtCarType.Text);
        }

        private void txtCarBrand_TextChanged(object sender, EventArgs e)
        {
            carBrand = 0;
            SELECTED_CAR_ID = 0;
            panelCarModel.Controls.Clear();
            SearchCarBrand(txtCarBrand.Text);
        }

        private void txtCarModel_TextChanged(object sender, EventArgs e)
        {
            SELECTED_CAR_ID = 0;
            SearchCarModel(txtCarModel.Text);
        }
    }
}


