using BIG.VMS.DATASERVICE;
using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.MODEL.CustomModel.Filter;
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
    public partial class frmAppointmenList : PageBase
    {
        private readonly AppointmentServices _service = new AppointmentServices();
        private ContainerAppointment _container = new ContainerAppointment();
        public frmAppointmenList()
        {
            InitializeComponent();
        }

        private void frmAppointmentList_Load(object sender, EventArgs e)
        {
            InitialEventHandler();
            ResetScreen();
            gridAppointmentList.DataBindingComplete += BindingComplete;
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



        private void InitialEventHandler()
        {

            btnNext.Click += new EventHandler(Pagination_EventHadler);
            btnLast.Click += new EventHandler(Pagination_EventHadler);
            btnFirst.Click += new EventHandler(Pagination_EventHadler);
            btnPrevious.Click += new EventHandler(Pagination_EventHadler);


        }

        private void BindGridData()
        {
            var filter = new AppointmentFilter()
            {

                ID_CARD = txtIDCard.Text,
                FIRST_NAME = txtName.Text,
                LAST_NAME = txtLastName.Text,
                LICENSE_PLATE = txtLicense.Text,

            };

            if (chkDate.Checked)
            {
                filter.CONTACT_DATE = dtContactDate.Value;
            }

            _container.Filter = filter;
            _container = _service.Retrieve(_container);
            SetDataSourceHeader(gridAppointmentList, ListHeader(), _container.ResultObj);
            SetPageControl(_container);

        }

        private List<HeaderGrid> ListHeader()
        {
            List<HeaderGrid> listCol = new List<HeaderGrid>();
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ID", FIELD = "AUTO_ID", VISIBLE = false, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            //listCol.Add(new HeaderGrid { HEADER_TEXT = "เลขที่", FIELD = "NO", VISIBLE = true, ALIGN = align.Center, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "บัตรประชาชน", FIELD = "REQUEST_ID_CARD", VISIBLE = true, ALIGN = align.Center, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ชื่อ-สกุล", FIELD = "REQUEST_NAME", VISIBLE = true, ALIGN = align.Center, AUTO_SIZE = autoSize.Fill });
            //listCol.Add(new HeaderGrid { HEADER_TEXT = "ประเภทรถ", FIELD = "REQUEST_CAR_NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            //listCol.Add(new HeaderGrid { HEADER_TEXT = "ทะเบียนรถ", FIELD = "LICENSE_PLATE", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "บุคคลที่ต้องการพบ", FIELD = "CONTACT_EMPLOYEE_NAME", VISIBLE = true, ALIGN = align.Center, AUTO_SIZE = autoSize.Fill });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "วัตถุประสงค์", FIELD = "REASON_NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "วันที่เข้าพบ", FIELD = "CONTACT_DATE", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "สถานะ", FIELD = "STATUS", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ผู้บันทึก", FIELD = "UPDATED_BY", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });


            return listCol;
        }

        private void SetPageControl(ContainerAppointment obj)
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

        private void CustomGrid()
        {

            foreach (DataGridViewRow row in gridAppointmentList.Rows)
            {
                if (row.Cells["STATUS"].Value.ToString() == "เข้าพบแล้ว")
                {
                    row.Cells[0].Value = Properties.Resources.approve;
                }
            }
            gridAppointmentList.RowTemplate.Height = 30;
            for (int i = 0; i < gridAppointmentList.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    gridAppointmentList.Rows[i].DefaultCellStyle.BackColor = Color.MistyRose;
                }
                else
                {
                    gridAppointmentList.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }

            gridAppointmentList.Columns[0].DefaultCellStyle.ForeColor = Color.White;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAppointment frm = new frmAppointment();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ResetScreen();
            }
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ResetScreen();
        }

        private void gridAppointmentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 0 && gridAppointmentList.Rows[e.RowIndex].Cells["STATUS"].Value.ToString() != "เข้าพบแล้ว")
                {

                    var id = Convert.ToInt32(gridAppointmentList.Rows[e.RowIndex].Cells["AUTO_ID"].Value);
                    ContainerAppointment container = new ContainerAppointment();
                    var filter = new AppointmentFilter();
                    TRN_VISITOR visitorObj = new TRN_VISITOR();
                    filter.AUTO_ID = id;
                    container.Filter = filter;
                    var obj = _service.GetItem(container);
                    visitorObj.CONTACT_EMPLOYEE_ID = obj.TRN_APPOINTMENT.CONTACT_EMPLOYEE_ID;
                    visitorObj.FIRST_NAME = obj.TRN_APPOINTMENT.REQUEST_FIRST_NAME;
                    visitorObj.LAST_NAME = obj.TRN_APPOINTMENT.REQUEST_LAST_NAME;
                    visitorObj.ID_CARD = obj.TRN_APPOINTMENT.REQUEST_ID_CARD;
                    visitorObj.REASON_ID = obj.TRN_APPOINTMENT.REASON_ID;
                    visitorObj.MAS_EMPLOYEE = obj.TRN_APPOINTMENT.MAS_EMPLOYEE;
                    visitorObj.MAS_REASON = obj.TRN_APPOINTMENT.MAS_REASON;
                    frmVisitor frm = new frmVisitor();
                    frm.visitorObj = visitorObj;
                    frm.formMode = FormMode.Add;
                    frm.visitorMode = VisitorMode.Appointment;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        var res = _service.UpdateStatus(id);
                    }

                    //var res = _service.UpdateStatus(id);
                    //if (res.Status)
                    //{
                    //    MessageBox.Show(Message.MSG_SAVE_COMPLETE, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    ResetScreen();
                    //}
                    //else
                    //{
                    //    MessageBox.Show(res.ExceptionMessage, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                }
            }

        }

        private void gridAppointmentList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnComein_Click(object sender, EventArgs e)
        {
            frmSelectAppointment frm = new frmSelectAppointment();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
