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
    public partial class frmKeyboard : Form
    {
        public frmKeyboard()
        {
            InitializeComponent();
        }
        public string license { get; set; }
        private void frmKeyboard_Load(object sender, EventArgs e)
        {
            List<string> thaiChar = new List<string>(new string[] { "ก", "ข", "ฃ", "ค", "ฅ", "ฆ", "ง", "จ", "ฉ", "ช", "ซ",
                                                                    "ฌ", "ญ", "ฎ", "ฏ", "ฐ", "ฑ", "ฒ", "ณ", "ด", "ต", "ถ", "ท", "ธ", "น", "บ", "ป",
                                                                    "ผ", "ฝ", "พ", "ฟ", "ภ", "ม", "ย", "ร", "ล", "ว", "ศ", "ษ", "ส", "ห", "ฬ", "อ", "ฮ" });
            List<string> numChar = new List<string>(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            for (int i = 0; i < thaiChar.Count; i++)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Fill;
                btn.Font = new Font(btn.Font.FontFamily, 17);
                btn.BackColor = Color.FromArgb(204, 229, 255);
                btn.Text = thaiChar[i];
                btn.Name = "thai" + i;
                tableLayoutPanel1.Controls.Add(btn);
                btn.Click += new EventHandler(selectCharEvent);
            }

            for (int i = 0; i < numChar.Count; i++)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Fill;
                btn.Font = new Font(btn.Font.FontFamily, 17);
                btn.BackColor = Color.FromArgb(255, 153, 153);
                btn.Text = numChar[i];
                btn.Name = "num" + i;
                tableLayoutPanel2.Controls.Add(btn);
                btn.Click += new EventHandler(selectCharEvent);
            }
        }

        private void selectCharEvent(object sender, EventArgs e)
        {

            var text = ((Control)sender).Text.ToString();
            txtLicense.Text += text;


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLicense.Text = "";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            license = txtLicense.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
