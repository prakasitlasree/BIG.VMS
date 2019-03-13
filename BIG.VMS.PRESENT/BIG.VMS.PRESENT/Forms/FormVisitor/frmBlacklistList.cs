using BIG.VMS.DATASERVICE;
using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.MODEL.CustomModel.Container;
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
    public partial class frmBlacklistList : PageBase
    {
        private readonly BlackListServices _service = new BlackListServices();
        private ContainerBlackList _container = new ContainerBlackList();
        public frmBlacklistList()
        {
            InitializeComponent();
        }

        private void frmBlacklistList_Load(object sender, EventArgs e)
        {
            ResetScreen();
        }

        private void BindGridData()
        {
            var filter = new BlacklistFilter()
            {

                ID_CARD = txtIDCard.Text,


            };

            _container.Filter = filter;
            _container = _service.Retrieve(_container);
            SetDataSourceHeader(gridBlackList, ListHeader(), _container.ResultObj);


        }

        private void CustomGrid()
        {

            gridBlackList.RowTemplate.Height = 30;
            for (int i = 0; i < gridBlackList.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    gridBlackList.Rows[i].DefaultCellStyle.BackColor = Color.Aquamarine;
                }
                else
                {
                    gridBlackList.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private List<HeaderGrid> ListHeader()
        {
            List<HeaderGrid> listCol = new List<HeaderGrid>();
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ID", FIELD = "AUTO_ID", VISIBLE = false, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "รหัสบัตรประชาชน", FIELD = "ID_CARD", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "ชื่อ", FIELD = "FIRST_NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "นามสกุล", FIELD = "LAST_NAME", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "เหตุผล", FIELD = "REASON", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.Fill });
            listCol.Add(new HeaderGrid { HEADER_TEXT = "วันที่บันทึก", FIELD = "CREATED_DATE", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.CellContent });
            //listCol.Add(new HeaderGrid { HEADER_TEXT = "สถานะ", FIELD = "STATUS", VISIBLE = true, ALIGN = align.Left, AUTO_SIZE = autoSize.Fill });



            return listCol;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ResetScreen();
        }

        private void gridBlackList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                #region ===================== delete =====================
                if (MessageBox.Show(Message.MSG_DELETE_CONFIRM, "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(gridBlackList.Rows[e.RowIndex].Cells["AUTO_ID"].Value);
                    ContainerBlackList obj = new ContainerBlackList
                    {
                        TRN_BLACKLIST = new TRN_BLACKLIST
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
        }

        private void ResetScreen()
        {
            BindGridData();
            CustomGrid();

        }
    }
}
