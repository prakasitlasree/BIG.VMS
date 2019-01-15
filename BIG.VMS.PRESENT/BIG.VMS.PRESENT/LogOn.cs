using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BIG.VMS.MODEL;
using BIG.VMS.MODEL.EntityModel;
using BIG.VMS.DATASERVICE;

namespace BIG.VMS.PRESENT
{
    public partial class LogOn : Form
    {
        public LogOn()
        {
            InitializeComponent();
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            var service = new AuthenticationServices();
            var res = service.GetItem(txtUsername.Text, txtPassword.Text);
            if (res.Status)
            {
                var obj = (MEMBER_LOGON)res.ResultObj;
                MessageBox.Show(res.Status.ToString() + "" + obj.FIRST_NAME);
            }
            else
            {
                MessageBox.Show(res.Message + res.ExceptionMessage);
            }
        }
    }
}
