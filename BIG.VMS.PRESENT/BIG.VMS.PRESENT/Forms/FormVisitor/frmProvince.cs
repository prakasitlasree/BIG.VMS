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
    public partial class frmProvince : Form
    {
        private ComboBoxServices _comboService = new ComboBoxServices();
        public int SELECTED_PROVINCE_ID { get; set; }
        public string SELECTED_PROVINCE_TEXT { get; set; }

        public frmProvince()
        {
            InitializeComponent();
        }

        private void frmProvince_Load(object sender, EventArgs e)
        {
            InitialProvince();
        }

        private void InitialProvince()
        {

            int fontSize = 12;
            var province = _comboService.GetComboProvince();

            for (int i = 0; i < province.Count; i++)
            {
                if (i < 10)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Left;
                    btn.Width = 98;
                    btn.Font = new Font(btn.Font.FontFamily, fontSize);
                    btn.BackColor = Color.FromArgb(232, 249, 102);
                    btn.Text = province[i].Text;
                    btn.Tag = province[i].Value;

                    row1.Controls.Add(btn);
                    btn.Click += new EventHandler(ProvinceSelected_EventHadler);

                }
                else if (i >= 10 && i < 20)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Left;
                    btn.Width = 98;
                    btn.Font = new Font(btn.Font.FontFamily, fontSize);
                    btn.BackColor = Color.FromArgb(232, 249, 102);
                    btn.Text = province[i].Text;
                    btn.Tag = province[i].Value;

                    row2.Controls.Add(btn);
                    btn.Click += new EventHandler(ProvinceSelected_EventHadler);
                }

                else if (i >= 20 && i < 30)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Left;
                    btn.Width = 98;
                    btn.Font = new Font(btn.Font.FontFamily, fontSize);
                    btn.BackColor = Color.FromArgb(232, 249, 102);
                    btn.Text = province[i].Text;
                    btn.Tag = province[i].Value;

                    row3.Controls.Add(btn);
                    btn.Click += new EventHandler(ProvinceSelected_EventHadler);

                }
                else if (i >= 30 && i < 40)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Left;
                    btn.Width = 98;
                    btn.Font = new Font(btn.Font.FontFamily, fontSize);
                    btn.BackColor = Color.FromArgb(232, 249, 102);
                    btn.Text = province[i].Text;
                    btn.Tag = province[i].Value;

                    row4.Controls.Add(btn);
                    btn.Click += new EventHandler(ProvinceSelected_EventHadler);

                }
                else if (i >= 40 && i < 50)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Left;
                    btn.Width = 98;
                    btn.Font = new Font(btn.Font.FontFamily, fontSize);
                    btn.BackColor = Color.FromArgb(232, 249, 102);
                    btn.Text = province[i].Text;
                    btn.Tag = province[i].Value;

                    row5.Controls.Add(btn);
                    btn.Click += new EventHandler(ProvinceSelected_EventHadler);

                }
                else if (i >= 60 && i < 70)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Left;
                    btn.Width = 98;
                    btn.Font = new Font(btn.Font.FontFamily, fontSize);
                    btn.BackColor = Color.FromArgb(232, 249, 102);
                    btn.Text = province[i].Text;
                    btn.Tag = province[i].Value;

                    row6.Controls.Add(btn);
                    btn.Click += new EventHandler(ProvinceSelected_EventHadler);

                }
                else if (i >= 70 && i < 80)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Left;
                    btn.Width = 98;
                    btn.Font = new Font(btn.Font.FontFamily, fontSize);
                    btn.BackColor = Color.FromArgb(232, 249, 102);
                    btn.Text = province[i].Text;
                    btn.Tag = province[i].Value;

                    row7.Controls.Add(btn);
                    btn.Click += new EventHandler(ProvinceSelected_EventHadler);

                }

            }


        }

        private void SearchProvince(string filter)
        {
            row1.Controls.Clear();
            row2.Controls.Clear();
            row3.Controls.Clear();
            row4.Controls.Clear();
            row5.Controls.Clear();
            row6.Controls.Clear();
            row7.Controls.Clear();

            int fontSize = 12;
            var province = _comboService.GetComboProvince(filter);

            for (int i = 0; i < province.Count; i++)
            {
                if (i < 10)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Left;
                    btn.Width = 98;
                    btn.Font = new Font(btn.Font.FontFamily, fontSize);
                    btn.BackColor = Color.FromArgb(232, 249, 102);
                    btn.Text = province[i].Text;
                    btn.Tag = province[i].Value;

                    row1.Controls.Add(btn);
                    btn.Click += new EventHandler(ProvinceSelected_EventHadler);

                }
                else if (i >= 10 && i < 20)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Left;
                    btn.Width = 98;
                    btn.Font = new Font(btn.Font.FontFamily, fontSize);
                    btn.BackColor = Color.FromArgb(232, 249, 102);
                    btn.Text = province[i].Text;
                    btn.Tag = province[i].Value;

                    row2.Controls.Add(btn);
                    btn.Click += new EventHandler(ProvinceSelected_EventHadler);
                }

                else if (i >= 20 && i < 30)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Left;
                    btn.Width = 98;
                    btn.Font = new Font(btn.Font.FontFamily, fontSize);
                    btn.BackColor = Color.FromArgb(232, 249, 102);
                    btn.Text = province[i].Text;
                    btn.Tag = province[i].Value;

                    row3.Controls.Add(btn);
                    btn.Click += new EventHandler(ProvinceSelected_EventHadler);

                }
                else if (i >= 30 && i < 40)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Left;
                    btn.Width = 98;
                    btn.Font = new Font(btn.Font.FontFamily, fontSize);
                    btn.BackColor = Color.FromArgb(232, 249, 102);
                    btn.Text = province[i].Text;
                    btn.Tag = province[i].Value;

                    row4.Controls.Add(btn);
                    btn.Click += new EventHandler(ProvinceSelected_EventHadler);

                }
                else if (i >= 40 && i < 50)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Left;
                    btn.Width = 98;
                    btn.Font = new Font(btn.Font.FontFamily, fontSize);
                    btn.BackColor = Color.FromArgb(232, 249, 102);
                    btn.Text = province[i].Text;
                    btn.Tag = province[i].Value;

                    row5.Controls.Add(btn);
                    btn.Click += new EventHandler(ProvinceSelected_EventHadler);

                }
                else if (i >= 60 && i < 70)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Left;
                    btn.Width = 98;
                    btn.Font = new Font(btn.Font.FontFamily, fontSize);
                    btn.BackColor = Color.FromArgb(232, 249, 102);
                    btn.Text = province[i].Text;
                    btn.Tag = province[i].Value;

                    row6.Controls.Add(btn);
                    btn.Click += new EventHandler(ProvinceSelected_EventHadler);

                }
                else if (i >= 70 && i < 80)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Left;
                    btn.Width = 98;
                    btn.Font = new Font(btn.Font.FontFamily, fontSize);
                    btn.BackColor = Color.FromArgb(232, 249, 102);
                    btn.Text = province[i].Text;
                    btn.Tag = province[i].Value;

                    row7.Controls.Add(btn);
                    btn.Click += new EventHandler(ProvinceSelected_EventHadler);

                }

            }


        }

        private void txtProvice_TextChanged(object sender, EventArgs e)
        {
            SearchProvince(txtProvice.Text);
        }

        private void ProvinceSelected_EventHadler(object sender, EventArgs e)
        {
            SELECTED_PROVINCE_ID = Convert.ToInt32(((Control)sender).Tag.ToString());
            SELECTED_PROVINCE_TEXT = ((Control)sender).Text.ToString();
            lblSelectedProvince.Text = ((Control)sender).Text.ToString();

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
