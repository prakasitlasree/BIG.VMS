﻿using BIG.VMS.DATASERVICE;
using BIG.VMS.MODEL;
using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.MODEL.CustomModel.CustomContainer;
using BIG.VMS.MODEL.EntityModel;
using BIG.VMS.PRESENT.Forms.FormReport;
using BIG.VMS.PRESENT.Forms.FormVisitor;
using BIG.VMS.PRESENT.Forms.FormVisitorBypass;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            ResetScreen();
            gridVisitorList.DataBindingComplete += BindingComplete;

        }

        private void SetControl()
        {
            if (ROLE == "ธุรการ")
            {
                btnIn.Visible = false;
                btnOut.Visible = false;
                gridVisitorList.Columns[0].Visible = false;
                gridVisitorList.Columns[1].Visible = false;
                gridVisitorList.Columns[2].Visible = false;
            }

          

        }

        private void BindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CustomGrid();
        }

        private void BindGridData()
        {
            var filter = new VisitorFilter()
            {

                ID_CARD = txtIDCard.Text,
                LICENSE_PLATE = txtLicense.Text,
                NO = txtNo.Text == "" ? 0 : Convert.ToInt32(txtNo.Text),
                FIRST_NAME = txtName.Text,
                LAST_NAME = txtLastName.Text

            };

            if (comboType.SelectedIndex == 0)
            {
                
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
                filter.TYPE = "Appointment";
            }
            else if (comboType.SelectedIndex == 4)
            {
                filter.TYPE = "AppointmentOut";
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
                    gridVisitorList.Rows[i].DefaultCellStyle.BackColor = Color.SeaShell;
                }
                else
                {
                    gridVisitorList.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                
            }
            foreach (DataGridViewRow row in gridVisitorList.Rows)
            {
                if (row.Cells["TYPE"].Value.ToString() == "ออก" || row.Cells["TYPE"].Value.ToString() == "นัดล่วงหน้า(ออก)")
                {
                    
                    
                    row.Cells[2].Value = Properties.Resources.approve;
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
            SetControl();

            TransactionModel obj = _service.GetVistorTracsaction();
            lblAllCount.Text = obj.ALL_VISITOR_IN.ToString();
            lblTodayIn.Text = obj.TODAY_VISITOR_IN.ToString();
            lblTodayOut.Text = obj.TODAY_VISITOR_OUT.ToString();
        }

        private List<HeaderGrid> ListHeader()
        {
            List<HeaderGrid> listCol = new List<HeaderGrid>();
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ID", FIELD = "AUTO_ID", VISIBLE = false, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "เลขที่", FIELD = "NO", VISIBLE = true, ALIGN = align.Center, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ประเภท", FIELD = "TYPE", VISIBLE = true, ALIGN = align.Center, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "บัตรประชาชน", FIELD = "ID_CARD", VISIBLE = true, ALIGN = align.Center, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ชื่อ-สกุล", FIELD = "FULL_NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
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
            frmSelectInType frm = new frmSelectInType();
            frm.StartPosition = FormStartPosition.CenterParent;          
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
            //frm.WindowState = FormWindowState.Maximized;
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
                        if (obj.TRN_VISITOR.TYPE == "Appointment")
                        {
                            frm.visitorMode = VisitorMode.Appointment;
                        }
                        if (obj.TRN_VISITOR.TYPE == "In")
                        {
                            frm.visitorMode = VisitorMode.In;
                        }
                        if (obj.TRN_VISITOR.TYPE == "Out")
                        {
                            frm.visitorMode = VisitorMode.Out;
                        }
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
                        var type = gridVisitorList.Rows[e.RowIndex].Cells["TYPE"].Value.ToString();
                        if(type != "ออก" && type != "นัดล่วงหน้า(ออก)")
                        {
                            #region ===================== print =====================
                            var id = Convert.ToInt32(gridVisitorList.Rows[e.RowIndex].Cells["AUTO_ID"].Value);
                            var obj = _service.GetVisitorByAutoIDForReport(id);
                            var reportPara = _service.GetReportParameter();
                            if (obj.ResultObj.Count > 0)
                            {
                                List<CustomVisitor> listData = (List<CustomVisitor>)obj.ResultObj;
                                DataTable dt = ConvertToDataTable(listData);

                                ReportDocument rpt = new ReportDocument();
                                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                                if(listData.FirstOrDefault().BY_PASS == "N" || listData.FirstOrDefault().BY_PASS == null)
                                {
                                    //var appPath = Application.StartupPath + "\\" + "ReportSlip.rpt";
                                    //var appPath = Application.StartupPath + "\\" + "ReportSlip_New.rpt";
                                    //var appPath = Application.StartupPath + "\\" + "ReportSlip_Bando.rpt";
                                    //var appPath = Application.StartupPath + "\\" + "ReportSlip_JBF.rpt";
                                    var appPath = Application.StartupPath + "\\" + "ReportSlip_Charoen.rpt";
                                    rpt.Load(appPath);
                                    rpt.SetDataSource(dt);
                                    rpt.PrintToPrinter(1, true, 0, 0);
                                }
                                else
                                {
                                    //var appPath = Application.StartupPath + "\\" + "ReportSlipByPass.rpt";
                                    //var appPath = Application.StartupPath + "\\" + "ReportSlipByPass_New.rpt";
                                    //var appPath = Application.StartupPath + "\\" + "ReportSlipByPass_Bando.rpt";
                                    //var appPath = Application.StartupPath + "\\" + "ReportSlipByPass_JBF.rpt";
                                    var appPath = Application.StartupPath + "\\" + "ReportSlipByPass_Charoen.rpt";
                                    rpt.Load(appPath);
                                    rpt.SetDataSource(dt);
                                    rpt.PrintToPrinter(1, true, 0, 0);
                                }
                              
                              
                            }
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

        private void btnBlacklist_Click(object sender, EventArgs e)
        {
            frmBlacklistList frm = new frmBlacklistList();
            frm.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void btnListExit_Click(object sender, EventArgs e)
        {
            frmVisitorOutList frm = new frmVisitorOutList();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmVisitorByPass frm = new frmVisitorByPass();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.formMode = FormMode.Add;
            frm.visitorMode = VisitorMode.In;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ResetScreen();
            }
        }
    }
}
