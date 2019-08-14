using BIG.VMS.DATASERVICE;
using BIG.VMS.MODEL.CustomModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;
using System.Globalization;
using ClosedXML.Excel;
using BIG.VMS.MODEL.CustomModel.CustomContainer;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;

namespace BIG.VMS.PRESENT.Forms.FormReport
{
    public partial class frmReportList : PageBase
    {

        private readonly VisitorServices _service = new VisitorServices();
        private ContainerVisitor _container = new ContainerVisitor();
        private ComboBoxServices _comboService = new ComboBoxServices();

        public frmReportList()
        {
            InitializeComponent();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable data = (DataTable)(gridReportList.DataSource);
                DataTable headerTable = new DataTable("Customers");
                DataColumn dtColumn;
                DataRow myDataRow;

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "COMPANY_NAME";
                headerTable.Columns.Add(dtColumn);

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "USER_PRINT";
                headerTable.Columns.Add(dtColumn);

                myDataRow = headerTable.NewRow();
                myDataRow["COMPANY_NAME"] = "BIG Visitor Management";
                myDataRow["USER_PRINT"] = LOGIN;
                headerTable.Rows.Add(myDataRow);

                ReportDocument rpt = new ReportDocument();
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                var appPath = Application.StartupPath + "\\" + "VisitorListReport.rpt";
                rpt.Load(appPath);
                rpt.Database.Tables[0].SetDataSource(data);
                rpt.Database.Tables[1].SetDataSource(headerTable);

                using (Form form = new Form())
                {

                    CrystalReportViewer tempViewer = new CrystalReportViewer();
                    tempViewer.ActiveViewIndex = -1;
                    tempViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    tempViewer.Dock = System.Windows.Forms.DockStyle.Fill;
                    tempViewer.Name = "tempViewer";
                    tempViewer.SelectionFormula = "";
                    tempViewer.TabIndex = 0;
                    tempViewer.ViewTimeSelectionFormula = "";
                    tempViewer.ReportSource = rpt;
                    tempViewer.AutoSize = true;
                    tempViewer.Refresh();
                    form.Controls.Add(tempViewer);
                    form.Size = this.Size;
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void frmReportList_Load(object sender, EventArgs e)
        {
            BindGridData();
            var combo = new ComboBoxServices();
            AddRangeComboBox(ddlDept, combo.GetComboDepartment(), true);
        }

        private void BindGridData()
        {
            var filter = new VisitorFilter()
            {

                DATE_FROM = (dtFrom.Value == null || dtFrom.Value == DateTime.MinValue) ? DateTime.Now : dtFrom.Value,
                DATE_TO = (dtTo.Value == null || dtTo.Value == DateTime.MinValue) ? DateTime.Now : dtTo.Value

            };

            if (radAll.Checked)
            {
                filter.TYPE = nameof(VisitorMode.All);
            }
            if (radIn.Checked)
            {
                filter.TYPE = nameof(VisitorMode.In);
            }
            if (radOut.Checked)
            {
                filter.TYPE = nameof(VisitorMode.Out);
            }
            filter.DEPT_ID = Convert.ToInt32(ddlDept.SelectedValue);

            _container.Filter = filter;
            _container = _service.GetVisitorForReport(_container);

            SetDataSourceHeader(gridReportList, ListHeader(), _container.ResultObj);


        }

        private List<HeaderGrid> ListHeader()
        {
            List<HeaderGrid> listCol = new List<HeaderGrid>();

            listCol.Add(new HeaderGrid { HEADER_TEXT = "ID", FIELD = "AUTO_ID", VISIBLE = false, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "เลขที่", FIELD = "NO", VISIBLE = true, ALIGN = align.Center, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "วันที่ทำการ", FIELD = "TIME_IN", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ประเภท", FIELD = "TYPE", VISIBLE = true, ALIGN = align.Center, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "รหัสบัตรประชาชน", FIELD = "ID_CARD", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ชื่อ-นามสกุล", FIELD = "NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            //listCol.Add(new HeaderGrid { HEADER_TEXT = "นามสกุล", FIELD = "LAST_NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "จังหวัด", FIELD = "PROVINCE", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ทะเบียนรถ", FIELD = "LICENSE_PLATE", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ประเภทรถ", FIELD = "CAR_TYPE_NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "บุคคลที่ต้องการพบ", FIELD = "CONTACT_NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "แผนก", FIELD = "DEPT_NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            //listCol.Add(new HeaderGrid { HEADER_TEXT = "นามสกุลบุคคลที่ต้องการพบ", FIELD = "CONTACT_EMP_LAST_NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });



            return listCol;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tableData = (DataTable)(gridReportList.DataSource);
                DataTable data = new DataTable();
                data = tableData.Copy();
                var col = data.Columns;
                if (col.Contains("ID_CARD_PHOTO"))
                {
                    data.Columns.Remove("ID_CARD_PHOTO");
                    data.Columns.Remove("AUTO_ID");
                    data.Columns.Remove("CONTACT_PHOTO");
                    data.Columns.Remove("TIME_OUT");
                    data.Columns.Remove("BLACKLIST");
                    data.Columns.Remove("TOPIC");
                    data.Columns.Remove("FIRST_NAME");
                    data.Columns.Remove("LAST_NAME");
                    data.Columns.Remove("CAR_TYPE_ID");
                    data.Columns.Remove("LICENSE_PLATE_PROVINCE_ID");
                    data.Columns.Remove("REASON_ID");
                    data.Columns.Remove("CONTACT_EMPLOYEE_ID");
                    data.Columns.Remove("STATUS");
                    data.Columns.Remove("FULL_NAME");
                    data.Columns.Remove("COMPANY_NAME");

                    data.Columns["NO"].ColumnName = "เลขที่";
                    data.Columns["TIME_IN"].ColumnName = "วันที่ทำการ";
                    data.Columns["TYPE"].ColumnName = "ประเภท";
                    data.Columns["ID_CARD"].ColumnName = "รหัสบัตรประชาชน";
                    data.Columns["NAME"].ColumnName = "ชื่อ-นามสกุล";
                    data.Columns["PROVINCE"].ColumnName = "จังหวัด";
                    data.Columns["LICENSE_PLATE"].ColumnName = "ทะเบียนรถ";
                    data.Columns["CAR_TYPE_NAME"].ColumnName = "ประเภทรถ";
                    data.Columns["CONTACT_NAME"].ColumnName = "บุคคลที่ต้องการพบ";
                    data.Columns["DEPT_NAME"].ColumnName = "แผนก";
                    data.Columns["CREATED_BY"].ColumnName = "ผู้บันทึก";
                    data.Columns["CREATED_DATE"].ColumnName = "วันที่บันทึก";
                    data.Columns["UPDATED_BY"].ColumnName = "ผู้แก้ไข";
                    data.Columns["UPDATED_DATE"].ColumnName = "วันที่แก้ไข";
                }

                var wb = new XLWorkbook();
                wb.Worksheets.Add(data, "Sheet1");
                var path = "C:\\VisitorReport";
                System.IO.Directory.CreateDirectory(path);
                var filePath = "\\VisitorReport" + DateTime.Now.ToString("dd-MM-yyyy HHmm") + ".xlsx";
                var savePath = path + filePath;
                wb.SaveAs(savePath);
                MessageBox.Show("บันทึกไฟล์ไปที่ " + savePath, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public DateTime ChangeTime(DateTime dateTime, int hours, int minutes, int seconds, int milliseconds)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }

        private void btnPrintToday_Click(object sender, EventArgs e)
        {

            var filter = new VisitorFilter()
            {

                DATE_FROM = ChangeTime(DateTime.Now, 0, 0, 0, 1),
                DATE_TO = ChangeTime(DateTime.Now, 23, 59, 59, 59),

            };

            _container.Filter = filter;
            _container = _service.GetVisitorForReport(_container);

            if (_container.ResultObj.Count > 0)
            {
                List<CustomVisitor> listData = (List<CustomVisitor>)_container.ResultObj;
                DataTable dt = ConvertToDataTable(listData);

                DataTable headerTable = new DataTable("Customers");
                DataColumn dtColumn;
                DataRow myDataRow;

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "COMPANY_NAME";
                headerTable.Columns.Add(dtColumn);

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "USER_PRINT";
                headerTable.Columns.Add(dtColumn);

                myDataRow = headerTable.NewRow();
                myDataRow["COMPANY_NAME"] = "BIG Visitor Management";
                myDataRow["USER_PRINT"] = LOGIN;
                headerTable.Rows.Add(myDataRow);


                ReportDocument rpt = new ReportDocument();
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                var appPath = Application.StartupPath + "\\" + "VisitorListReport.rpt";
                rpt.Load(appPath);
                rpt.Database.Tables[0].SetDataSource(dt);
                rpt.Database.Tables[1].SetDataSource(headerTable);

                using (Form form = new Form())
                {

                    CrystalReportViewer tempViewer = new CrystalReportViewer();

                    tempViewer.ActiveViewIndex = -1;
                    tempViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    tempViewer.Dock = System.Windows.Forms.DockStyle.Fill;
                    tempViewer.Name = "tempViewer";
                    tempViewer.SelectionFormula = "";
                    tempViewer.TabIndex = 0;
                    tempViewer.ViewTimeSelectionFormula = "";
                    tempViewer.ReportSource = rpt;
                    tempViewer.AutoSize = true;
                    tempViewer.Refresh();
                    form.Controls.Add(tempViewer);
                    form.Size = this.Size;
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.ShowDialog();
                }

            }

            SetDataSourceHeader(gridReportList, ListHeader(), _container.ResultObj);
        }

        private void btnPrintMonth_Click(object sender, EventArgs e)
        {
            var timeNow = DateTime.Now;
            var firstDayOfMonth = new DateTime(timeNow.Year, timeNow.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            var filter = new VisitorFilter()
            {

                DATE_FROM = ChangeTime(firstDayOfMonth, 0, 0, 0, 1),
                DATE_TO = ChangeTime(lastDayOfMonth, 23, 59, 59, 59),

            };

            _container.Filter = filter;
            _container = _service.GetVisitorForReport(_container);

            if (_container.ResultObj.Count > 0)
            {
                List<CustomVisitor> listData = (List<CustomVisitor>)_container.ResultObj;
                DataTable dt = ConvertToDataTable(listData);
                DataTable headerTable = new DataTable("Customers");
                DataColumn dtColumn;
                DataRow myDataRow;

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "COMPANY_NAME";
                headerTable.Columns.Add(dtColumn);

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "USER_PRINT";
                headerTable.Columns.Add(dtColumn);

                myDataRow = headerTable.NewRow();
                myDataRow["COMPANY_NAME"] = "BIG Visitor Management";
                myDataRow["USER_PRINT"] = LOGIN;
                headerTable.Rows.Add(myDataRow);

                ReportDocument rpt = new ReportDocument();
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                var appPath = Application.StartupPath + "\\" + "VisitorListReport.rpt";
                rpt.Load(appPath);
                rpt.Database.Tables[0].SetDataSource(dt);
                rpt.Database.Tables[1].SetDataSource(headerTable);

                using (Form form = new Form())
                {

                    CrystalReportViewer tempViewer = new CrystalReportViewer();
                    tempViewer.ActiveViewIndex = -1;
                    tempViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    tempViewer.Dock = System.Windows.Forms.DockStyle.Fill;
                    tempViewer.Name = "tempViewer";
                    tempViewer.SelectionFormula = "";
                    tempViewer.TabIndex = 0;
                    tempViewer.ViewTimeSelectionFormula = "";
                    tempViewer.ReportSource = rpt;
                    tempViewer.AutoSize = true;
                    tempViewer.Refresh();
                    form.Controls.Add(tempViewer);
                    form.Size = this.Size;
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.ShowDialog();
                }

            }

            SetDataSourceHeader(gridReportList, ListHeader(), _container.ResultObj);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
