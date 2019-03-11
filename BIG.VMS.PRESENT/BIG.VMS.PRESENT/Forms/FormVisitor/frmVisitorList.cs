﻿using BIG.VMS.DATASERVICE;
using BIG.VMS.MODEL;
using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.MODEL.CustomModel.CustomContainer;
using BIG.VMS.MODEL.EntityModel;
using BIG.VMS.PRESENT.Forms.FormReport;
using BIG.VMS.PRESENT.Forms.FormVisitor;
using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frmVisitorList : PageBase
    {
        private readonly VisitorServices _service = new VisitorServices();
        private ContainerVisitor _container = new ContainerVisitor();
        private ComboBoxServices _comboService = new ComboBoxServices();

        public frmVisitorList()
        {
            InitializeComponent();
        }

        private void frmAllvisitor_Load(object sender, EventArgs e)
        {

            InitialComboBox();
            InitialEventHandler();
            _container.PageInfo = new Pagination();
            BindGridData();
            CustomGrid();

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

            if (comboType.SelectedIndex == 0)
            {
                //filter.TYPE = "In";
            }
            else if (comboType.SelectedIndex == 1)
            {
                filter.TYPE = "In";
            }
            else if (comboType.SelectedIndex == 2)
            {
                filter.TYPE = "Out";
            }
            else if (comboType.SelectedIndex == 3)
            {
                filter.TYPE = "Regulary";
            }
            _container.Filter = filter;
            _container = _service.Retrieve(_container);
            SetDataSourceHeader(gridVisitorList, ListHeader(), _container.ResultObj);
            SetPageControl(_container);

        }

        private void CustomGrid()
        {
            gridVisitorList.RowTemplate.Height = 30;
            for (int i = 0; i < gridVisitorList.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    gridVisitorList.Rows[i].DefaultCellStyle.BackColor = Color.Aquamarine;
                }
                else
                {
                    gridVisitorList.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ResetScreen();
        }

        private void ResetScreen()
        {
            _container.PageInfo = new Pagination();
            BindGridData();
            CustomGrid();
        }

        private List<HeaderGrid> ListHeader()
        {
            List<HeaderGrid> listCol = new List<HeaderGrid>();
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ID", FIELD = "AUTO_ID", VISIBLE = false, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });

            listCol.Add(new HeaderGrid { HEADER_TEXT = "เลขที่", FIELD = "NO", VISIBLE = true, ALIGN = align.Center, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "วันที่ทำการ", FIELD = "CREATED_DATE", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
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
            comboType.SelectedIndex = 0;

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

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmVisitor frm = new frmVisitor();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.formMode = FormMode.Add;
            frm.visitorMode = VisitorMode.In;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ResetScreen();
            }


        }

        private void btnOut_Click(object sender, EventArgs e)
        {

            frmVisitorOut frm = new frmVisitorOut();
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ResetScreen();
            }
        }

        private void btnRegular_Click(object sender, EventArgs e)
        {
            frmRegulary frm = new frmRegulary();
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ResetScreen();
            }
        }

        private void btnAhead_Click(object sender, EventArgs e)
        {
            frmAppointmenList frm = new frmAppointmenList();
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ResetScreen();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReportList frm = new frmReportList();
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void gridVisitorList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                if (e.RowIndex > -1)
                {
                    if (e.ColumnIndex == 0)
                    {
                        #region ===================== edit =====================
                        var id = Convert.ToInt32(gridVisitorList.Rows[e.RowIndex].Cells["AUTO_ID"].Value);
                        var obj = _service.GetVisitorByAutoID(id);
                        frmVisitor frm = new frmVisitor();
                        frm.visitorObj = obj.TRN_VISITOR;
                        frm.formMode = FormMode.Edit;

                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            ResetScreen();
                        }
                        #endregion
                    }
                    else if (e.ColumnIndex == 1)
                    {
                        #region ===================== delete =====================
                        if (MessageBox.Show(Message.MSG_DELETE_CONFIRM, "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            var id = Convert.ToInt32(gridVisitorList.Rows[e.RowIndex].Cells["AUTO_ID"].Value);
                            ContainerVisitor obj = new ContainerVisitor
                            {
                                TRN_VISITOR = new TRN_VISITOR
                                {
                                    AUTO_ID = id
                                }
                            };
                            var res = _service.Delete(obj);
                            if (res.Status)
                            {
                                MessageBox.Show(Message.MSG_SAVE_COMPLETE, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ResetScreen();
                            }
                            else
                            {
                                MessageBox.Show(res.ExceptionMessage, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            } 
                        }
                        #endregion
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        #region ===================== print =====================
                        var id = Convert.ToInt32(gridVisitorList.Rows[e.RowIndex].Cells["AUTO_ID"].Value);
                        var obj = _service.GetVisitorByAutoIDForReport(id);
                        if (obj.ResultObj.Count > 0)
                        {
                            List<CustomVisitor> listData = (List<CustomVisitor>)obj.ResultObj;
                            DataTable dt = ConvertToDataTable(listData);
                            if (listData.FirstOrDefault().CONTACT_PHOTO != null)
                            {
                                DataTable dtMap = new DataTable("myMember");
                                dtMap.Columns.Add(new DataColumn("Picture_Steam", typeof(System.Byte[])));
                                DataRow dr = dtMap.NewRow();
                                dr["Picture_Steam"] = listData.FirstOrDefault().CONTACT_PHOTO;
                                dtMap.Rows.Add(dr);
                            }

                            if (listData.FirstOrDefault().ID_CARD_PHOTO != null)
                            {
                                DataTable dtMap = new DataTable("myMember");
                                dtMap.Columns.Add(new DataColumn("Picture_Steam", typeof(System.Byte[])));
                                DataRow dr = dtMap.NewRow();
                                dr["Picture_Steam"] = listData.FirstOrDefault().ID_CARD_PHOTO;
                                dtMap.Rows.Add(dr);
                            }

                            ReportDocument rpt = new ReportDocument(); 
                            string path = System.Reflection.Assembly.GetExecutingAssembly().Location; 
                            var directory = System.IO.Path.GetDirectoryName(path); 
                            directory =  directory.Replace("\\bin\\Debug", "\\Forms\\FormReport\\VisitorReport.rpt");
                            rpt.Load(directory);

                            rpt.SetDataSource(dt);
                            frmReportViewer frm = new frmReportViewer();
                            frm.crystalReportViewer1.ReportSource = rpt;
                            frm.Show();

#endregion
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
