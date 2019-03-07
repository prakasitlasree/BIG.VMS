﻿using BIG.VMS.DATASERVICE;
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
        }

        private void ResetScreen()
        {
            _container.PageInfo = new Pagination();
            BindGridData();
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
            //listCol.Add(new HeaderGrid { HEADER_TEXT = "ประเภท", FIELD = "TYPE", VISIBLE = true, ALIGN = align.Center, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "รหัสบัตรประชาชน", FIELD = "REQUEST_ID_CARD", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ทะเบียนรถ", FIELD = "REQUEST_LICENSE_PLATE", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ชื่อ", FIELD = "REQUEST_FIRST_NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.Fill });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "นามสกุล", FIELD = "REQUEST_LAST_NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.Fill });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "วันที่จะเข้า", FIELD = "CONTACT_DATE", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.Fill });



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
            gridAppointmentList.RowTemplate.Height = 30;
            for (int i = 0; i < gridAppointmentList.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    gridAppointmentList.Rows[i].DefaultCellStyle.BackColor = Color.Aquamarine;
                }
                else
                {
                    gridAppointmentList.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAppointment frm = new frmAppointment();
            if(frm.ShowDialog()== DialogResult.OK)
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
    }
}