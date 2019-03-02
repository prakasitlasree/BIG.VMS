﻿using BIG.VMS.MODEL.CustomModel;
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

        private void PageBase_Load(object sender, EventArgs e)
        {
            
        }
    }
}
