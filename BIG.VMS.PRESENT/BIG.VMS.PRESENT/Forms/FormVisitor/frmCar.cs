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
        public int SELECTED_CAR_ID { get; set; }
        public string SELECTED_CAR_TEXT { get; set; }

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

            var carModel = _comboService.GetComboCarModelByBrandID(carBrand);
            panelCarModel.Controls.Clear();

            foreach (var item in carModel)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Height = 100;
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.BackColor = Color.FromArgb(246, 252, 201);



                btn.Text = item.Text;
                btn.Tag = item.Value;

                panelCarModel.Controls.Add(btn);
            }
        }

        private void SearchCarType(string filter)
        {
            var carType = _comboService.GetComboCarType(filter);
            panelCarType.Controls.Clear();
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

            foreach (var item in carModel)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Height = 100;
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.BackColor = Color.FromArgb(246, 252, 201);

                btn.Text = item.Text;
                btn.Tag = item.Value;

                btn.Click += new EventHandler(CarBrandSelected_EventHadler);


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


