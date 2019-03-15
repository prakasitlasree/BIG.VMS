using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace BIG.VMS.PRESENT.Forms.Master
{
    public partial class ReadCard : Form
    {
        RDNID mRDNIDWRAPPER = new RDNID();
          
        public ReadCard()
        {
            InitializeComponent();

            string fileName = CardHelper.StartupPath + "\\RDNIDLib.DLD";
            if (System.IO.File.Exists(fileName) == false)
            {
                MessageBox.Show("RDNIDLib.DLD not found");
            }

            System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = String.Format("R&D NID Card Plus C# {0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);


            byte[] _lic = CardHelper.String2Byte(fileName);

            int nres = 0;
            nres = RDNID.openNIDLibRD(_lic);
            if (nres != 0)
            {
                String m;
                m = String.Format(" error no {0} ", nres);
                MessageBox.Show(m);
            }
             
            ListCardReader();

        }

        private void ListCardReader()
        {
            byte[] szReaders = new byte[1024 * 2];
            int size = szReaders.Length;
            int numreader = RDNID.getReaderListRD(szReaders, size);
            if (numreader <= 0)
                return;
            String s = CardHelper.ByteToString(szReaders);
            String[] readlist = s.Split(';');
            if (readlist != null)
            {
                for (int i = 0; i < readlist.Length; i++)
                {
                    m_ListReaderCard.Items.Add(readlist[i]);
                }

                m_ListReaderCard.SelectedIndex = 0;
            }
        }
         
        protected int ReadPIDCard()
        {
            String strTerminal = m_ListReaderCard.GetItemText(m_ListReaderCard.SelectedItem);

            IntPtr obj = CardHelper.SelectReader(strTerminal);


            Int32 nInsertCard = 0;
            nInsertCard = RDNID.connectCardRD(obj);
            if (nInsertCard != 0)
            {
                String m;
                m = String.Format(" error no {0} ", nInsertCard);
                MessageBox.Show(m);

                RDNID.disconnectCardRD(obj);
                RDNID.deselectReaderRD(obj);
                return nInsertCard;
            }


            //BindDataToScreen();
            byte[] id = new byte[30];
            int res = RDNID.getNIDNumberRD(obj, id);
            if (res != DefineConstants.NID_SUCCESS)
                return res;
            String NIDNum = CardHelper.ByteToString(id);



            byte[] data = new byte[1024];
            res = RDNID.getNIDTextRD(obj, data, data.Length);
            if (res != DefineConstants.NID_SUCCESS)
                return res;

            String NIDData = CardHelper.ByteToString(data);
            if (NIDData == "")
            {
                MessageBox.Show("Read Text error");
            }
            else
            {
                string[] fields = NIDData.Split('#');

                m_txtID.Text = NIDNum;                             // or use m_txtID.Text = fields[(int)NID_FIELD.NID_Number];

                string fullname = fields[(int)Enums.NID_FIELD.TITLE_T] + " " +
                                     fields[(int)Enums.NID_FIELD.NAME_T] + " " +
                                     fields[(int)Enums.NID_FIELD.MIDNAME_T] + " " +
                                     fields[(int)Enums.NID_FIELD.SURNAME_T];
                m_txtFullNameT.Text = fullname;

                fullname = fields[(int)Enums.NID_FIELD.TITLE_E] + " " +
                                    fields[(int)Enums.NID_FIELD.NAME_E] + " " +
                                    fields[(int)Enums.NID_FIELD.MIDNAME_E] + " " +
                                    fields[(int)Enums.NID_FIELD.SURNAME_E];
                m_txtFullNameE.Text = fullname;

                m_txtBrithDate.Text = CardHelper.DateFormat(fields[(int)Enums.NID_FIELD.BIRTH_DATE]);

                m_txtAddress.Text = fields[(int)Enums.NID_FIELD.HOME_NO] + "   " +
                                      fields[(int)Enums.NID_FIELD.MOO] + "   " +
                                      fields[(int)Enums.NID_FIELD.TROK] + "   " +
                                      fields[(int)Enums.NID_FIELD.SOI] + "   " +
                                      fields[(int)Enums.NID_FIELD.ROAD] + "   " +
                                      fields[(int)Enums.NID_FIELD.TUMBON] + "   " +
                                      fields[(int)Enums.NID_FIELD.AMPHOE] + "   " +
                                      fields[(int)Enums.NID_FIELD.PROVINCE] + "   "
                                      ;
                if (fields[(int)Enums.NID_FIELD.GENDER] == "1")
                {
                    m_txtGender.Text = "ชาย";
                }
                else
                {
                    m_txtGender.Text = "หญิง";
                }
                m_txtIssueDate.Text = CardHelper.DateFormat(fields[(int)Enums.NID_FIELD.ISSUE_DATE]);
                m_txtExpiryDate.Text = CardHelper.DateFormat(fields[(int)Enums.NID_FIELD.EXPIRY_DATE]);
                if ("99999999" == m_txtExpiryDate.Text)
                    m_txtExpiryDate.Text = "99999999 ตลอดชีพ";
                string m_txtIssueNum = fields[(int)Enums.NID_FIELD.ISSUE_NUM];
            }

            byte[] NIDPicture = new byte[1024 * 5];
            int imgsize = NIDPicture.Length;
            res = RDNID.getNIDPhotoRD(obj, NIDPicture, out imgsize);
            if (res != DefineConstants.NID_SUCCESS)
                return res;

            byte[] byteImage = NIDPicture;
            if (byteImage == null)
            {
                MessageBox.Show("Read Photo error");
            }
            else
            {
                //m_picPhoto
                Image img = Image.FromStream(new MemoryStream(byteImage));
                Bitmap MyImage = new Bitmap(img, m_picPhoto.Width - 2, m_picPhoto.Height - 2);
                m_picPhoto.Image = (Image)MyImage;
            }

            RDNID.disconnectCardRD(obj);
            RDNID.deselectReaderRD(obj);
            return 0;
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            ReadPIDCard();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
