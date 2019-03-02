using BIG.VMS.MODEL.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIG.VMS.PRESENT
{
    public class FormHelper
    {
        public void AddRangeComboBox(ComboBox control,List<ComboBoxItem> data, bool isSelectAll)
        {
            if (isSelectAll)
            {
                ComboBoxItem defaultSelect = new ComboBoxItem
                {
                    Text = "====== เลือก ======",
                    Value = null,
                };

                data.Insert(0, defaultSelect);

                control.DisplayMember = "Text";
                control.ValueMember = "Value";
                control.DataSource = data;

            }
            else
            {
                control.DisplayMember = "Text";
                control.ValueMember = "Value";
                control.DataSource = data;
            }
        }
    }
}
