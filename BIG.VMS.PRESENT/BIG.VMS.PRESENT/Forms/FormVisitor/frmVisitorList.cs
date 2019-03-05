using BIG.VMS.DATASERVICE;
using BIG.VMS.MODEL;
using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.PRESENT.Forms.FormVisitor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIG.VMS.PRESENT.Forms.Home
{
    public partial class frmAllvisitor : PageBase
    {
        private readonly VisitorServices _service = new VisitorServices();
        private ContainerVisitor _container = new ContainerVisitor();
        private ComboBoxServices _comboService = new ComboBoxServices();
        public frmAllvisitor()
        {
            InitializeComponent();
        }

        private void frmAllvisitor_Load(object sender, EventArgs e)
        {

            InitialComboBox();
            InitialEventHandler();
            _container.PageInfo = new Pagination();
            BindGridData();
        }

        private void BindGridData()
        {
            var filter = new VisitorFilter()
            {
                //TYPE = "IN",
                ID_CARD = txtIDCard.Text,
                LICENSE_PLATE = txtLicense.Text,
                NO = txtNo.Text
            };
            _container.Filter = filter;
            _container = _service.Retrieve(_container);
            //gridVisitorList.DataSource = _container.ResultObj;
            SetDataSourceHeader(gridVisitorList, ListHeader(), _container.ResultObj);
            SetPageControl(_container);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _container.PageInfo = new Pagination();
            BindGridData();
        }

        private List<HeaderGrid> ListHeader()
        {
            List<HeaderGrid> listCol = new List<HeaderGrid>();
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ID", FIELD = "AUTO_ID", VISIBLE = false, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "เลขที่", FIELD = "NO", VISIBLE = true, ALIGN = align.Center, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ประเภท", FIELD = "TYPE", VISIBLE = true, ALIGN = align.Center, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "รหัสบัตรประชาชน", FIELD = "ID_CARD", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ทะเบียนรถ", FIELD = "LICENSE_PLATE", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ชื่อ", FIELD = "FIRST_NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.Fill });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "นามสกุล", FIELD = "LAST_NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.Fill });

            return listCol;
        }

        private void InitialComboBox()
        {

            //AddRangeComboBox(comboType, _comboService.GetComboVisitorType());


        }

        private void InitialEventHandler()
        {

            btnNext.Click += new EventHandler(Pagination_EventHadler);
            btnLast.Click += new EventHandler(Pagination_EventHadler);
            btnFirst.Click += new EventHandler(Pagination_EventHadler);
            btnPrevious.Click += new EventHandler(Pagination_EventHadler);


        }

        private void SetPageControl(ContainerVisitor obj)
        {
            if (obj.PageInfo == null)
            {
                obj.PageInfo = new Pagination();
            }

            if (obj.PageInfo.PAGE == 1)
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
            }

            if (obj.PageInfo.PAGE == obj.PageInfo.TOTAL_PAGE)
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }

            txtPage.Text = "หน้า : " + obj.PageInfo.PAGE.ToString() + "/" + obj.PageInfo.TOTAL_PAGE.ToString();
        }

        private void Pagination_EventHadler(object sender, EventArgs e)
        {
            string controlName = ((Control)sender).Name.ToString();

            switch (controlName)
            {
                case "btnNext":
                    {
                        _container.PageInfo.PAGE += 1;
                        BindGridData();
                    }
                    break;
                case "btnPrevious":
                    {
                        _container.PageInfo.PAGE -= 1;
                        BindGridData();
                    }
                    break;
                case "btnFirst":
                    {
                        _container.PageInfo.PAGE = 1;
                        BindGridData();
                    }
                    break;
                case "btnLast":
                    {
                        _container.PageInfo.PAGE = _container.PageInfo.TOTAL_PAGE;
                        BindGridData();
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var x = frm.SELECTED_EMPLOYEE_ID;
               
            }
        }
    }
}
