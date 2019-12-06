using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BIG.VMS.MODEL.CustomModel;
using ThaiNationalIDCard;

namespace BIG.VMS.PRESENT.Forms.Master
{
    public partial class CardSelection : Form
    {
        public string CARD_READER { get; set; }
        public bool READ_CARD_STATUS { get; set; }
        public PIDCard CARD { get; set; }
        public string CARD_TYPE { get; set; }
        public DIDCard DID { get; set; }
        private ThaiIDCard idcard;

        public CardSelection()
        {
            InitializeComponent();
            //ListCardReader();
            //string fileName = CardHelper.StartupPath + "\\RDNIDLib.DLD";
            //if (System.IO.File.Exists(fileName) == false)
            //{
            //    //MessageBox.Show("RDNIDLib.DLD not found");
            //}

            //System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            //byte[] _lic = CardHelper.String2Byte(fileName); 
        }

        private void CardSelection_Load(object sender, EventArgs e)
        {
            idcard = new ThaiIDCard();
        }

        private void btn_NID_Click(object sender, EventArgs e)
        {
            //ReadPIDCard();
            ReadNewPIDCard();
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

        //new function by prkasit on Nov'14 2019
        private void ReadNewPIDCard()
        {
            try
            {
                CARD = new PIDCard();
                CARD_TYPE = "PID";
                Personal personal = idcard.readAllPhoto();
                if (personal != null)
                {
                    CARD.NO = personal.Citizenid;
                    CARD.TH_TITLE = personal.Th_Prefix;
                    CARD.TH_FIRST_NAME = personal.Th_Firstname;
                    CARD.TH_LAST_NAME = personal.Th_Lastname;
                    CARD.EN_TITLE = personal.En_Prefix;
                    CARD.EN_FIRST_NAME = personal.En_Firstname;
                    CARD.EN_LAST_NAME = personal.En_Lastname;
                    CARD.BIRTH_DATE = CardHelper.DateFormat(personal.Birthday.ToString("yyyyMMdd"));
                    CARD.HOME_NO = personal.addrHouseNo;
                    CARD.MOO = personal.addrVillageNo;
                    CARD.SOI = personal.addrLane;
                    CARD.ROAD = personal.addrRoad;
                    CARD.TUMBON = personal.addrTambol;
                    CARD.AMPHOE = personal.addrAmphur;
                    CARD.PROVINCE = personal.addrProvince;
                    CARD.GENDER = personal.Sex; 
                    CARD.PHOTO = personal.PhotoBitmap;
                    CARD.CARD_IMAGE = personal.PhotoBitmap;

                    try
                    {
                        byte[] byteImage = null;
                         
                        
                        byteImage = personal.PhotoRaw;// stream.ToArray();

                        CARD.BYTE_IMAGE = byteImage;
                         
                         
                    }
                    catch (Exception ex)
                    {
                    }
                    READ_CARD_STATUS = true;
                }
                else if (idcard.ErrorCode() > 0)
                {
                    MessageBox.Show(idcard.Error());
                }
            }
            catch (Exception ex)
            {
                READ_CARD_STATUS = false;
                MessageBox.Show("ไม่พบเครื่องอ่านบัตรประชาชน หรืออ่านบัตรไม่สำเร็จ!!! " + ex.Message);
            }
        }

        protected int ReadPIDCard()
        {
            try
            {
                string strTerminal = CARD_READER;
                if (string.IsNullOrEmpty(CARD_READER))
                {
                    strTerminal = "Identiv uTrust 2700 R Smart Card Reader 0";
                }
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
                {
                    return res;
                }
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
                    CARD.CARD_IMAGE = img;
                    CARD.BYTE_IMAGE = byteImage;
                }
                RDNID.disconnectCardRD(obj);
                RDNID.deselectReaderRD(obj);
                READ_CARD_STATUS = true;
            }
            catch (Exception ex)
            {
                READ_CARD_STATUS = false;
                MessageBox.Show("ไม่พบเครื่องอ่านบัตรประชาชน หรืออ่านบัตรไม่สำเร็จ!!! " + ex.Message);

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
                try
                {
                    string[] temp = frm.DID_INFO.Split('$');
                    if (temp.Length > 0)
                    {
                        string[] str = { };
                        string[] str2 = { };
                        try
                        {
                            string[] no = temp[2].Replace("\r\n", "").Split('?');
                            str = no;
                        }
                        catch (Exception)
                        {

                        }
                        try
                        {
                            string[] no2 = str[1].Replace("\r\n", "").Split('=');
                            str2 = no2;
                        }
                        catch (Exception)
                        {

                        }
                        try
                        {
                            DID.NO = str2[0].Replace(";", "").ToString().Substring(6);
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            DID.FIRST_NAME_EN = temp[1].ToString();
                        }
                        catch (Exception)
                        {

                        }
                        try
                        {
                            DID.LAST_NAME_EN = temp[0].Trim().Replace("%", "").Replace("^", "").Replace(" ", "");
                        }
                        catch (Exception)
                        {

                        }


                    }
                    READ_CARD_STATUS = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    DID.NO = "99999999999999";
                    DID.FIRST_NAME_EN = "ERROR";
                    DID.LAST_NAME_EN = "ERROR";
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
        }

        
    }
}
