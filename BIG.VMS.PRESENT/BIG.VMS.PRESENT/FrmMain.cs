using BIG.VMS.PRESENT.Forms.FormIn;
using BIG.VMS.PRESENT.Forms.Home;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BIG.VMS.PRESENT
{
    public partial class FrmMain : Form
    {
        public string User { get; set; }
        public FrmMain()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = User;
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

        private void Home_Click(object sender, EventArgs e)
        {
            frmHome frm = new frmHome();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
        }

        
    }
}
