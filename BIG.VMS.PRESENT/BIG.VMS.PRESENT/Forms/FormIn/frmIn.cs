using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIG.VMS.PRESENT.Forms.FormIn
{
    public partial class frmIn : PageBase
    {
        public frmIn()
        {
            InitializeComponent();
        }

        private void frmIn_Load(object sender, EventArgs e)
        {
            try
            {
                InitialLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitialLoad()
        {
            txtNo.Text = "001";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {

        }
    }
}
