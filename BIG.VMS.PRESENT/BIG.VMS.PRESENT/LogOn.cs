using System;
using System.Windows.Forms;
using BIG.VMS.MODEL.EntityModel;
using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.DATASERVICE;

namespace BIG.VMS.PRESENT
{
    public partial class LogOn : PageBase
    {
        public LogOn()
        {
            InitializeComponent();
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            var service = new AuthenticationServices();
            var filter = new AuthenticationFilter { UserName = txtUsername.Text, Password = txtPassword.Text };
            var container = new ContainerAuthentication { Filter = filter };
            var res = service.Retrieve(container);
            if (res.Status)
            {
                //USER = txtUsername.Text;
                var obj = (MEMBER_LOGON)res.ResultObj;
                var frm = new FrmMain();
                LOGIN = txtUsername.Text;
                frm.User = txtUsername.Text;
                frm.Show(this);
                this.Hide();

                OnClearScreen();
            }
            else
            {
                MessageBox.Show(res.Message + res.ExceptionMessage);
            }
        }

        private void LogOn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(Message.MSG_SHUTDOWN_SYSTEM, Message.MSG_WARNING_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #region  ========= PRIVATE ===========

        private void OnClearScreen()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;

            txtUsername.Focus();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            var service = new AuthenticationServices();
            var filter = new AuthenticationFilter { UserName ="admin", Password = "1234"};
            var container = new ContainerAuthentication { Filter = filter };
            var res = service.Retrieve(container);
            if (res.Status)
            {
                //USER = txtUsername.Text;
                var obj = (MEMBER_LOGON)res.ResultObj;
                var frm = new FrmMain();
                LOGIN = txtUsername.Text;
                frm.User = txtUsername.Text;
                frm.Show(this);
                this.Hide();

                OnClearScreen();
            }
            else
            {
                MessageBox.Show(res.Message + res.ExceptionMessage);
            }
        }
        
    }
}
