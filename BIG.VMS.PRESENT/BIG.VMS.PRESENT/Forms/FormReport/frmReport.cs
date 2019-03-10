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

namespace BIG.VMS.PRESENT.Forms.FormReport
{
    public partial class frmReport : PageBase
    {
        private readonly VisitorServices _service = new VisitorServices();
        private ContainerVisitor _container = new ContainerVisitor();
        private ComboBoxServices _comboService = new ComboBoxServices();

        public frmReport()
        {
            InitializeComponent();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            BindGridData();
        }

        private void BindGridData()
        {
            var filter = new VisitorFilter()
            {
                //TYPE = "IN",
                DATE_FROM = (dtFrom.Value == null || dtFrom.Value == DateTime.MinValue) ? DateTime.Now : dtFrom.Value,
                DATE_TO = (dtTo.Value == null || dtTo.Value == DateTime.MinValue) ? DateTime.Now : dtTo.Value

            };

            _container.Filter = filter;
            _container = _service.GetVisitorForReport(_container);

            SetDataSourceHeader(gridListVisitor, ListHeader(), _container.ResultObj);


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

        private void gridListVisitor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridListVisitor.Rows)
            {
                if (this.gridListVisitor.SelectedRows.Count == 1)
                {
                    // get information of 1st column from the row
                    string selectedUser = this.gridListVisitor.SelectedRows[0].Cells[0].ToString();
                }
            }
        }
    }
}
