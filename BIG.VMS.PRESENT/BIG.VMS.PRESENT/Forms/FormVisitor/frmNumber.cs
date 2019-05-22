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
    public partial class frmNumber : Form
    {
        public frmNumber()
        {
            InitializeComponent();
        }
        public string text { get; set; }
        private void frmNumber_Load(object sender, EventArgs e)
        {
            button1.Click += new EventHandler(selectCharEvent);
            button2.Click += new EventHandler(selectCharEvent);
            button3.Click += new EventHandler(selectCharEvent);
            button4.Click += new EventHandler(selectCharEvent);
            button5.Click += new EventHandler(selectCharEvent);
            button6.Click += new EventHandler(selectCharEvent);
            button7.Click += new EventHandler(selectCharEvent);
            button8.Click += new EventHandler(selectCharEvent);
            button9.Click += new EventHandler(selectCharEvent);
            button10.Click += new EventHandler(selectCharEvent);
        }

        private void selectCharEvent(object sender, EventArgs e)
        {

            var text = ((Control)sender).Text.ToString();
            txtText.Text += text;


        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            text = txtText.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
