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

namespace BIG.VMS.PRESENT.Forms.FormVisitor
{
    public partial class frmRegulary : Form
    {
        public FormMode formMode = new FormMode();
        public VisitorMode visitorMode = new VisitorMode();
        private readonly VisitorServices _service = new VisitorServices();
        private ContainerVisitor _container = new ContainerVisitor();
        private ComboBoxServices _comboService = new ComboBoxServices();
        private List<TRN_VISITOR> listRegulary = new List<TRN_VISITOR>();

        public frmRegulary()
        {
            InitializeComponent();
        }

        private void frmRegulary_Load(object sender, EventArgs e)
        {
            InitialLoad();
        }

        private void InitialLoad()
        {
            _container = new ContainerVisitor();
            var res = _service.GetRegularyVisitor();

            if (res.Status)
            {
                listRegulary = (List<TRN_VISITOR>)res.ResultObj;
                panelRegulary.Controls.Clear();
                foreach (var item in listRegulary)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Top;
                    btn.Height = 100;
                    btn.Font = new Font(btn.Font.FontFamily, 20);
                    btn.BackColor = Color.FromArgb(232, 249, 102);

                    btn.Text = item.FIRST_NAME + " " + item.LAST_NAME;
                    btn.Tag = item.AUTO_ID;

                    btn.Click += new EventHandler(VisitorSelected_EventHadler);

                    panelRegulary.Controls.Add(btn);
                }
            }
            else
            {

            }

        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            var listSearch = listRegulary.Where(o => o.FIRST_NAME.Contains(txtSearch.Text) || o.LAST_NAME.Contains(txtSearch.Text));
            panelRegulary.Controls.Clear();
            foreach (var item in listSearch)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Height = 100;
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.BackColor = Color.FromArgb(232, 249, 102);

                btn.Text = item.FIRST_NAME + " " + item.LAST_NAME;
                btn.Tag = item.AUTO_ID;

                btn.Click += new EventHandler(VisitorSelected_EventHadler);

                panelRegulary.Controls.Add(btn);
            }
        }

        private void VisitorSelected_EventHadler(object sender, EventArgs e)
        {
            var Id = Convert.ToInt32(((Control)sender).Tag.ToString());
            var obj = _service.GetVisitorByAutoID(Id);
            frmVisitor frm = new frmVisitor();
            frm.visitorObj = obj.TRN_VISITOR;
            frm.formMode = FormMode.Add;
            frm.visitorMode = VisitorMode.Regulary;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
