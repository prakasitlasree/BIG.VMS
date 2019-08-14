using BIG.VMS.DATASERVICE;
using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.MODEL.CustomModel.Filter;
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
    public partial class frmVisitorOutList : PageBase
    {

        public VisitorServices _service = new VisitorServices();
        public ContainerVisitor _container = new ContainerVisitor();
        public frmVisitorOutList()
        {
            InitializeComponent();
        }


        private void frmListExist_Load(object sender, EventArgs e)
        {
            ResetScreen();
            InitialEventHandler();
            gridVisitorOut.DataBindingComplete += BindingComplete;
        }

        private void InitialEventHandler()
        {

            btnNext.Click += new EventHandler(Pagination_EventHadler);
            btnLast.Click += new EventHandler(Pagination_EventHadler);
            btnFirst.Click += new EventHandler(Pagination_EventHadler);
            btnPrevious.Click += new EventHandler(Pagination_EventHadler);


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


        private void CustomGrid()
        {

            foreach (DataGridViewRow row in gridVisitorOut.Rows)
            {
                if (row.Cells["STATUS"].Value.ToString() == "เข้าพบแล้ว")
                {
                    row.Cells[0].Value = Properties.Resources.approve;
                }
            }
            gridVisitorOut.RowTemplate.Height = 30;
            for (int i = 0; i < gridVisitorOut.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    gridVisitorOut.Rows[i].DefaultCellStyle.BackColor = Color.MistyRose;
                }
                else
                {
                    gridVisitorOut.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }

            gridVisitorOut.Columns[0].DefaultCellStyle.ForeColor = Color.White;
        }

        private void BindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CustomGrid();
        }

        private void ResetScreen()
        {
            _container.PageInfo = new Pagination();
            BindGridData();
            CustomGrid();
        }

        private void BindGridData()
        {
            var filter = new VisitorFilter()
            {

                ID_CARD = txtIDCard.Text,
                FIRST_NAME = txtName.Text,
                LAST_NAME = txtLastName.Text,
                LICENSE_PLATE = txtLicense.Text,

            };

            if (chkDate.Checked)
            {
                filter.DATE_FROM = dtContactDate.Value;
            }

            _container.Filter = filter;
            _container = _service.GetListVisitorNotOut(_container);
            SetDataSourceHeader(gridVisitorOut, ListHeader(), _container.ResultObj);
            SetPageControl(_container);

        }

        private List<HeaderGrid> ListHeader()
        {
            List<HeaderGrid> listCol = new List<HeaderGrid>();
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ID", FIELD = "AUTO_ID", VISIBLE = false, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "เลขที่", FIELD = "NO", VISIBLE = true, ALIGN = align.Center, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ประเภท", FIELD = "TYPE", VISIBLE = true, ALIGN = align.Center, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "บัตรประชาชน", FIELD = "ID_CARD", VISIBLE = true, ALIGN = align.Center, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ชื่อ-สกุล", FIELD = "NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ประเภทรถ", FIELD = "CAR_TYPE_NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ทะเบียนรถ", FIELD = "LICENSE_PLATE", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "บุคคลที่ต้องการพบ", FIELD = "CONTACT_NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "แผนก", FIELD = "DEPT_NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "วัตถุประสงค์", FIELD = "TOPIC", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "วันที่บันทึก", FIELD = "CREATED_DATE", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ผู้บันทึก", FIELD = "CREATED_BY", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "วันที่แก้ไข", FIELD = "UPDATED_DATE", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ผู้แก้ไข", FIELD = "UPDATED_BY", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            return listCol;
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

            if (obj.PageInfo.PAGE >= obj.PageInfo.TOTAL_PAGE)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ResetScreen();
        }

        private void gridVisitorOut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 0)
                {
                    var id = Convert.ToInt32(gridVisitorOut.Rows[e.RowIndex].Cells["AUTO_ID"].Value);
                    frmVisitorOut frm = new frmVisitorOut();
                    frm.outFlag = true;
                    frm.inID = id;
                    if(frm.ShowDialog() == DialogResult.OK)
                    {
                        ResetScreen();
                    }
                }
            }
        }
    }
}
