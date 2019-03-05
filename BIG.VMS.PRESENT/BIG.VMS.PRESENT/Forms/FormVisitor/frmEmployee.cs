using BIG.VMS.DATASERVICE;
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
    public partial class frmEmployee : Form
    {
        private ComboBoxServices _comboService = new ComboBoxServices();
        private int deptID = 0;
        private int employeeID = 0;
        public int selectedEmployeeID { get; set; }
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            InitialDepartment();
        }

        private void InitialDepartment()
        {
            var department = _comboService.GetComboDepartment();

            foreach (var item in department)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Height = 100;
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.BackColor = Color.FromArgb(241, 252, 156);

                btn.Text = item.Text;
                btn.Tag = item.Value;

                btn.Click += new EventHandler(DepartmentSelected_EventHadler);

                panelDept.Controls.Add(btn);
            }
        }

        private void SearchDepartment(string filter)
        {
            var department = _comboService.GetComboDepartment(filter);

            panelDept.Controls.Clear();

            foreach (var item in department)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Height = 100;
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.BackColor = Color.FromArgb(246, 252, 201);

                btn.Text = item.Text;
                btn.Tag = item.Value;

                btn.Click += new EventHandler(DepartmentSelected_EventHadler);

                panelDept.Controls.Add(btn);
            }
        }

        private void SearchEmployee(string filter)
        {
            var employee = _comboService.GetComboEmployeeByDepartmentID(deptID,filter);

            panelEmployee.Controls.Clear();

            foreach (var item in employee)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Height = 100;
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.BackColor = Color.FromArgb(241, 252, 156);

                btn.Text = item.Text;
                btn.Tag = item.Value;

                btn.Click += new EventHandler(EmployeeSelected_EventHadler);

                panelEmployee.Controls.Add(btn);
            }
        }

        private void DepartmentSelected_EventHadler(object sender, EventArgs e)
        {
            deptID = Convert.ToInt32(((Control)sender).Tag.ToString());

            var employee = _comboService.GetComboEmployeeByDepartmentID(deptID);

            panelEmployee.Controls.Clear();

            foreach (var item in employee)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Height = 100;
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.BackColor = Color.FromArgb(246, 252, 201);

                btn.Text = item.Text;
                btn.Tag = item.Value;

                btn.Click += new EventHandler(EmployeeSelected_EventHadler);

                panelEmployee.Controls.Add(btn);
            }
        }

        private void EmployeeSelected_EventHadler(object sender, EventArgs e)
        {
            selectedEmployeeID = Convert.ToInt32(((Control)sender).Tag.ToString());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtDepartment_TextChanged(object sender, EventArgs e)
        {
            deptID = 0;
            employeeID = 0;
            panelEmployee.Controls.Clear();
            SearchDepartment(txtDepartment.Text);
        }

        private void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            employeeID = 0;
            SearchEmployee(txtEmployee.Text);
        }
    }
}
