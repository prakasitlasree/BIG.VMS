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

namespace BIG.VMS.PRESENT
{
    public partial class PageBase : Form
    {
        public static string LOGIN { get; set; }
        public static string ROLE { get; set; }
        public static string DIRECTORY_IN = Application.StartupPath + "\\IMAGES\\" + DateTime.Now.Year + "_" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "\\" + DateTime.Now.Day + "\\IN\\";
        public static string DIRECTORY_OUT = Application.StartupPath + "\\IMAGES\\" + DateTime.Now.Year + "_" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "\\" + DateTime.Now.Day + "\\OUT\\";
        public PageBase()
        {
            InitializeComponent();
            this.BackColor = Color.White;

        }

        public string USER = string.Empty;

        public string GetUserLogin()
        {
            return USER;
        }

        public void AddRangeComboBox(ComboBox control, List<ComboBoxItem> data, bool isSelectAll = true)
        {
            if (isSelectAll)
            {
                ComboBoxItem defaultSelect = new ComboBoxItem
                {
                    Text = "เลือก",
                    Value = null,
                };

                data.Insert(0, defaultSelect);

                control.DisplayMember = "Text";
                control.ValueMember = "Value";
                control.DataSource = data;
                control.SelectedIndex = 0;

            }
            else
            {
                control.DisplayMember = "Text";
                control.ValueMember = "Value";
                control.DataSource = data;
            }
        }

        public void SetDataSourceHeader(DataGridView control, List<HeaderGrid> list_header, dynamic data)
        {
            if (data != null)
            {
                DataTable dt = ConvertToDataTable(data);
                control.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //control.DataSource = dt;
                List<string> columnNames = dt.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToList();

                int columnIndex = 0;


                foreach (var item in list_header)
                {
                    if (dt.Columns.Contains(item.FIELD))
                    {
                        dt.Columns[item.FIELD].SetOrdinal(columnIndex);
                        columnIndex++;
                    }

                }

                control.DataSource = dt;

                foreach (var item in columnNames)
                {
                    control.Columns[item].Visible = false;
                }
                foreach (var item in list_header)
                {
                    if (control.Columns.Contains(item.FIELD))
                    { 
                        control.Columns[item.FIELD].HeaderText = item.HEADER_TEXT;
                        control.Columns[item.FIELD].Visible = item.VISIBLE;
                        control.Columns[item.FIELD].DefaultCellStyle.Alignment = item.ALIGN == align.Center ? DataGridViewContentAlignment.MiddleCenter : (item.ALIGN == align.Left ? DataGridViewContentAlignment.MiddleLeft : (item.ALIGN == align.Right ? DataGridViewContentAlignment.BottomRight : DataGridViewContentAlignment.MiddleLeft));
                        control.Columns[item.FIELD].AutoSizeMode = item.AUTO_SIZE == autoSize.CellContent ? DataGridViewAutoSizeColumnMode.AllCells : (item.AUTO_SIZE == autoSize.Fill ? DataGridViewAutoSizeColumnMode.Fill : DataGridViewAutoSizeColumnMode.AllCells);

                    }
                }
            } 
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        private void PageBase_Load(object sender, EventArgs e)
        {

        }
    }
}
