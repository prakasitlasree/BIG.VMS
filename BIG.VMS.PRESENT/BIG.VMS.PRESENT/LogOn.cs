using System;
using System.Windows.Forms;
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
                FrmMain frm = new FrmMain();
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
            if (MessageBox.Show(Message.MSG_SHUTDOWN_SYSTEM,Message.MSG_WARNING_CAPTION,MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
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
    }
}
