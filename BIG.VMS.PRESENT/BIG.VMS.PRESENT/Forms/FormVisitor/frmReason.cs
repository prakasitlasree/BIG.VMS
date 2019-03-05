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
    public partial class frmReason : Form
    {
        private ComboBoxServices _comboService = new ComboBoxServices();
        private int resonId = 0;

        public int SELECTED_REASON_ID { get; set; }
        public string SELECTED_REASON_TEXT { get; set; }

        public frmReason()
        {
            InitializeComponent();
        }

        private void frmReason_Load(object sender, EventArgs e)
        {
            InitialReason();
        }

        private void InitialReason()
        {
            var reason = _comboService.GetComboReason();

            foreach (var item in reason)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Height = 100;
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.BackColor = Color.FromArgb(241, 252, 156);

                btn.Text = item.Text;
                btn.Tag = item.Value;

                btn.Click += new EventHandler(ReasonSelected_EventHadler);

                panelReason.Controls.Add(btn);
            }
        }

        private void SearchReason(string filter)
        {
            var reason = _comboService.GetComboReason(filter);
            panelReason.Controls.Clear();
            foreach (var item in reason)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Height = 100;
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.BackColor = Color.FromArgb(241, 252, 156);

                btn.Text = item.Text;
                btn.Tag = item.Value;

                btn.Click += new EventHandler(ReasonSelected_EventHadler);

                panelReason.Controls.Add(btn);
            }
        }

        private void ReasonSelected_EventHadler(object sender, EventArgs e)
        {
            SELECTED_REASON_ID = Convert.ToInt32(((Control)sender).Tag.ToString());
            SELECTED_REASON_TEXT = ((Control)sender).Text.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            SearchReason(txtReason.Text);
        }
    }
}
