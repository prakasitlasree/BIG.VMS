using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIG.VMS.PRESENT.Forms.Master
{
    public partial class DrivingLicenseCardInfo : Form
    {
        public string DID_INFO { get; set; }
        public DrivingLicenseCardInfo()
        {
            InitializeComponent();
        }

        private void DrivingLicenseCardInfo_Load(object sender, EventArgs e)
        {
            txtCardinfo.Focus();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
           
            DID_INFO = txtCardinfo.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txtCardinfo.Text = string.Empty;
            txtCardinfo.Focus();
        }
    }
}
