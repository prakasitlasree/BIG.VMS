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
            DGVPrinter printer = new DGVPrinter();

            CultureInfo _cultureTHInfo = new CultureInfo("th-TH");

            printer.Title = "รายงาน ณ วันที่ " + Convert.ToDateTime(dtFrom.Value, _cultureTHInfo).ToShortDateString();

            printer.SubTitle = "รายงานเข้า-ออก";

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                          StringFormatFlags.NoClip;

            printer.PageNumbers = true;

            printer.PageNumberInHeader = true;

            printer.PorportionalColumns = true;

            printer.HeaderCellAlignment = StringAlignment.Center;

            printer.Footer = "BIG VMS";

            printer.FooterSpacing = 15;

            printer.PageSettings.Landscape = true;

            printer.PrintDataGridView(gridReportList);
        }

        private void frmReportList_Load(object sender, EventArgs e)
        {
            BindGridData();
        }

        private void BindGridData()
        {
            var filter = new VisitorFilter()
            {
                TYPE = "IN",
                DATE_FROM = (dtFrom.Value == null || dtFrom.Value == DateTime.MinValue) ? DateTime.Now : dtFrom.Value,
                DATE_TO = (dtTo.Value == null || dtTo.Value == DateTime.MinValue) ? DateTime.Now : dtTo.Value

            };

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
                DataTable data = (DataTable)(gridReportList.DataSource);

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
                    data.Columns.Remove("CAR_MODEL_ID");
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
    }
}
