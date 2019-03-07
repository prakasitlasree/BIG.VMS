using BIG.VMS.DATASERVICE;
using BIG.VMS.MODEL.CustomModel.Container;
using BIG.VMS.MODEL.EntityModel;
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
    public partial class frmBlackList : Form
    {
        public string ID_CARD;
        public string FIRST_NAME;
        public string LAST_NAME;
        BlackListServices _service = new BlackListServices();

        public frmBlackList()
        {
            InitializeComponent();
        }

        private void frmBlackList_Load(object sender, EventArgs e)
        {
            txtFirstName.Text = FIRST_NAME;
            txtLastName.Text = LAST_NAME;
            txtIDCard.Text = ID_CARD;
        }

        private void btnBlacklist_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReason.Text))
            {
                if (MessageBox.Show("ต้องการบันทึกข้อมูลใช่หรือไม่ ?", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Save();
                }
            }
        }

        private void Save()
        {
            var obj = new TRN_BLACKLIST
            {
                ID_CARD = ID_CARD,
                FIRST_NAME = FIRST_NAME,
                LAST_NAME = LAST_NAME,
                STATUS = "",
                REASON = txtReason.Text,
                CREATED_DATE = DateTime.Now,
                UPDATED_DATE = DateTime.Now,

            };

            var container = new ContainerBlackList { TRN_BLACKLIST = obj };

            var res = _service.Create(container);

            if (res.Status)
            {

                MessageBox.Show(Message.MSG_SAVE_COMPLETE, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(res.Message + res.ExceptionMessage);
            }
        }
    }
}
