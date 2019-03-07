using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BIG.VMS.MODEL.CustomModel;

namespace BIG.VMS.PRESENT.Forms.Master
{
    public partial class CardSelection : Form
    {
        public string CARD_READER { get; set; }
        public PIDCard CARD { get; set; }
        public string CARD_TYPE { get; set; }
        public DIDCard DID { get; set; }

        public CardSelection()
        {
            InitializeComponent();
            ListCardReader();
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
        }

        private void btn_NID_Click(object sender, EventArgs e)
        {
            ReadPIDCard();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region  method 

        private void ListCardReader()
        {
            byte[] szReaders = new byte[1024 * 2];
            int size = szReaders.Length;
            int numreader = RDNID.getReaderListRD(szReaders, size);
            if (numreader <= 0)
                return;
            string s = CardHelper.ByteToString(szReaders);
            string[] readlist = s.Split(';');
            if (readlist != null)
            {
                for (int i = 0; i < readlist.Length; i++)
                {
                    CARD_READER = readlist[i];
                }
            }
        }

        protected int ReadPIDCard()
        {
            try
            { 
                string strTerminal = CARD_READER;
                CARD = new PIDCard();
                CARD_TYPE = "PID";
                IntPtr obj = CardHelper.SelectReader(strTerminal);

                int nInsertCard = 0;
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
                 
                byte[] id = new byte[30];
                int res = RDNID.getNIDNumberRD(obj, id);
                if (res != DefineConstants.NID_SUCCESS)
                    return res;
                string NIDNum = CardHelper.ByteToString(id);


                byte[] data = new byte[1024];
                res = RDNID.getNIDTextRD(obj, data, data.Length);
                if (res != DefineConstants.NID_SUCCESS)
                    return res;

                string NIDData = CardHelper.ByteToString(data);
                if (NIDData == "")
                {
                    MessageBox.Show("Read Text error");
                }
                else
                {
                    string[] fields = NIDData.Split('#');
                    CARD.NO = NIDNum;
                    CARD.TH_TITLE = fields[(int)Enums.NID_FIELD.TITLE_T];
                    CARD.TH_FIRST_NAME = fields[(int)Enums.NID_FIELD.NAME_T];
                    CARD.TH_MID_NAME = fields[(int)Enums.NID_FIELD.MIDNAME_T];
                    CARD.TH_LAST_NAME = fields[(int)Enums.NID_FIELD.SURNAME_T];
                    CARD.EN_TITLE = fields[(int)Enums.NID_FIELD.TITLE_E];
                    CARD.EN_FIRST_NAME = fields[(int)Enums.NID_FIELD.NAME_E];
                    CARD.EN_MID_NAME = fields[(int)Enums.NID_FIELD.MIDNAME_E];
                    CARD.EN_LAST_NAME = fields[(int)Enums.NID_FIELD.SURNAME_E];
                    CARD.BIRTH_DATE = CardHelper.DateFormat(fields[(int)Enums.NID_FIELD.BIRTH_DATE]);
                    CARD.HOME_NO = fields[(int)Enums.NID_FIELD.HOME_NO];
                    CARD.MOO = fields[(int)Enums.NID_FIELD.MOO];
                    CARD.TROK = fields[(int)Enums.NID_FIELD.TROK];
                    CARD.SOI = fields[(int)Enums.NID_FIELD.SOI];
                    CARD.ROAD = fields[(int)Enums.NID_FIELD.ROAD];
                    CARD.TUMBON = fields[(int)Enums.NID_FIELD.TUMBON];
                    CARD.AMPHOE = fields[(int)Enums.NID_FIELD.AMPHOE];
                    CARD.PROVINCE = fields[(int)Enums.NID_FIELD.PROVINCE];

                    if (fields[(int)Enums.NID_FIELD.GENDER] == "1")
                    {
                        CARD.GENDER = "ชาย";
                    }
                    else
                    {
                        CARD.GENDER = "หญิง";
                    }
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
                    CARD.PHOTO = new Bitmap(img, 270 - 2, 180 - 2);
                }
                RDNID.disconnectCardRD(obj);
                RDNID.deselectReaderRD(obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return 0;

        }

        #endregion

        private void btn_driving_licence_Click(object sender, EventArgs e)
        {
            DrivingLicenseCardInfo frm = new DrivingLicenseCardInfo();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DID = new DIDCard();
                CARD_TYPE = "DID"; //Driving card ID
                string[] temp = frm.DID_INFO.Split('$');
                if (temp.Length >= 3)
                {
                    string[] no = temp[2].Replace("\r\n","").Split('?');
                    string[] no2 = no[1].Replace("\r\n", "").Split('=');
                    DID.NO = no2[0].Replace(";", "").ToString();
                    DID.FIRST_NAME_EN = temp[1].ToString();
                    DID.LAST_NAME_EN = temp[0].Trim().Replace("%", "").Replace("^", "").Replace(" ",""); 
                } 
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
