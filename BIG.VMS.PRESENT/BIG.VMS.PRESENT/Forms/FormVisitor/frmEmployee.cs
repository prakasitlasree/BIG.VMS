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

        public int SELECTED_EMPLOYEE_ID { get; set; }
        public string SELECTED_EMPLOYEE_TEXT { get; set; }
        public int SELECTED_REASON_ID { get; set; }
        public string SELECTED_REASON_TEXT { get; set; }


        private bool flgSelectEmployee = false;
        private bool flgSelectReason = false;


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
            var employee = _comboService.GetComboEmployeeByDepartmentID(deptID, filter);

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

        private void SearchReason(string filter)
        {
            var reason = _comboService.GetComboReason(filter);
            panelReason.Controls.Clear();
            foreach (var item in reason)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Height = 100;
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.BackColor = Color.FromArgb(241, 252, 156);

                btn.Text = item.Text;
                btn.Tag = item.Value;

                btn.Click += new EventHandler(ReasonSelected_EventHadler);

                panelReason.Controls.Add(btn);
            }
        }

        private void ReasonSelected_EventHadler(object sender, EventArgs e)
        {
            SELECTED_REASON_ID = Convert.ToInt32(((Control)sender).Tag.ToString());
            SELECTED_REASON_TEXT = ((Control)sender).Text.ToString();
            foreach (Control c in panelReason.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.ForeColor = Color.Black;
                }
            }
            ((Button)((Control)sender)).ForeColor = Color.Red;

            flgSelectReason = true;
            if (flgSelectEmployee)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void DepartmentSelected_EventHadler(object sender, EventArgs e)
        {
            deptID = Convert.ToInt32(((Control)sender).Tag.ToString());

            var employee = _comboService.GetComboEmployeeByDepartmentID(deptID);
            var reason = _comboService.GetComboReasonByDepartmentID(deptID);

            panelEmployee.Controls.Clear();
            panelReason.Controls.Clear();


            #region Cascade Employee
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
            #endregion

            #region Cascade Employee
            foreach (var item in reason)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Height = 100;
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.BackColor = Color.FromArgb(246, 252, 201);

                btn.Text = item.Text;
                btn.Tag = item.Value;

                btn.Click += new EventHandler(ReasonSelected_EventHadler);

                panelReason.Controls.Add(btn);
            }
            #endregion

            foreach (Control c in panelDept.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.ForeColor = Color.Black;
                }
            }
            
            ((Button)((Control)sender)).ForeColor = Color.Red;

            flgSelectReason = false;
            flgSelectEmployee = false;
        }

        private void EmployeeSelected_EventHadler(object sender, EventArgs e)
        {
            SELECTED_EMPLOYEE_ID = Convert.ToInt32(((Control)sender).Tag.ToString());
            SELECTED_EMPLOYEE_TEXT = ((Control)sender).Text.ToString();

            flgSelectEmployee = true;
            if (flgSelectReason)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
           
        }

        private void txtDepartment_TextChanged(object sender, EventArgs e)
        {
            deptID = 0;
            SELECTED_EMPLOYEE_ID = 0;
            panelEmployee.Controls.Clear();
            SearchDepartment(txtDepartment.Text);

          
        }

        private void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            SELECTED_EMPLOYEE_ID = 0;
            SearchEmployee(txtEmployee.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchReason(txtReason.Text);
        }
    }
}
