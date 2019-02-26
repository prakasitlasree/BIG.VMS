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

namespace BIG.VMS.PRESENT.Forms.FormIn
{
    public partial class frmIn : PageBase
    {

        public frmIn()
        {
            InitializeComponent();
        }

        private void frmIn_Load(object sender, EventArgs e)
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
            Txt_No.Text = "001";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            var service = new VisitorServices();
            TRN_VISITOR obj = new TRN_VISITOR
            {
                NO = Txt_No.Text.Trim(),
                ID_CARD = Txt_IDCard.Text.Trim(),
                LICENSE_PLATE = Txt_LicensePlate.Text.Trim(),
                TOPIC = Txt_Topic.Text.Trim(),
            };
            var container = new ContainerVisitor { TRN_VISITOR = obj };

            var res = service.Create(container);
            if (res.Status)
            {
                
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
