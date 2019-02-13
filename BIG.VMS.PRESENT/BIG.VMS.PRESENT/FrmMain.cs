using System;
using System.Drawing;
using System.Windows.Forms;

namespace BIG.VMS.PRESENT
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //============ เปลี่ยนสี MDI form ===============
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient)
                {
                    ctrl.BackColor = Color.Gainsboro;
                }
            }
            //============================================
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(Message.LOGOUT,Message.MSG_WARNING_CAPTION, MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            { 
                OnCloseAllChildrenForm();

                if (Owner != null)
                {
                    Owner.Show();
                }
                else
                {
                    Dispose(true);
                    Application.ExitThread();
                    Application.Exit();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        #region  ============= Private ================
        private void OnCloseAllChildrenForm()
        {
            foreach (var c in MdiChildren)
            {
                c.Close();
            }
        }


        #endregion
    }
}
