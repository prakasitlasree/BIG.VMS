using BIG.VMS.DATASERVICE;
using BIG.VMS.MODEL.CustomModel;
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

namespace BIG.VMS.PRESENT.Forms.FormOut
{
    public partial class frmOut : Form
    {
        private readonly VisitorServices _service = null;
        private ContainerVisitor _container = null;
        public frmOut()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("", Message.MSG_SAVE_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Save();
            }
        }

        private void frmOut_Load(object sender, EventArgs e)
        {
            try
            {
                InitialLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void InitialLoad()
        {
            _container = new ContainerVisitor();
            var res = _service.GetItem(_container);
            if (res.Status)
            {
                int no = Convert.ToInt32(res.TRN_VISITOR.NO);
                no = no + 1;
                txtNo.Text = no.ToString("D6");
            }
            else
            {
                MessageBox.Show(res.ExceptionMessage);
            }

        }

        private void Save()
        {

            var obj = new TRN_VISITOR
            {
                NO = txtNo.Text.Trim(),
                ID_CARD = txtIDCard.Text.Trim(),
                LICENSE_PLATE = txtLicensePLate.Text.Trim(),
                //TOPIC = txtTopic.Text.Trim(),
                TYPE = "OUT",
                //CREATED_BY      
                CREATED_DATE = DateTime.Now,
                UPDATED_DATE = DateTime.Now,
                //UPDATED_BY      
            };

            var container = new ContainerVisitor { TRN_VISITOR = obj };

            var res = _service.Create(container);

            if (res.Status)
            {
                MessageBox.Show(Message.MSG_SAVE_COMPLETE);
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
