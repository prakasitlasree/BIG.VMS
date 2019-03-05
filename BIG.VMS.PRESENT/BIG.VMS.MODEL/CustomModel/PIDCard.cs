using System.Drawing;

namespace BIG.VMS.MODEL.CustomModel
{
    public class PIDCard
    {
        /// <summary>
        /// NO,    
        /// </summary>
        public string NO { get; set; }

        /// <summary>
        /// TITLE_T,    //Thai title#
        /// </summary>
        public string TH_TITLE { get; set; }

        /// <summary>
        ///  NAME_T,     //Thai name#
        /// </summary>
        public string TH_FIRST_NAME { get; set; }

        /// <summary>
        ///   MIDNAME_T,  //Thai mid name#
        /// </summary>

        public string TH_MID_NAME { get; set; }

        /// <summary>
        /// SURNAME_T,  //Thai surname#
        /// </summary>
        public string TH_LAST_NAME { get; set; }
         
        /// <summary>
        /// TITLE_E,    //Eng title#
        /// </summary>
        public string EN_TITLE { get; set; }

        /// <summary>
        /// NAME_E,     //Eng name#
        /// </summary>
        public string EN_FIRST_NAME { get; set; }

        /// <summary>
        ///  MIDNAME_E,  //Eng mid name#
        /// </summary>
        public string EN_MID_NAME { get; set; }

        /// <summary>
        /// SURNAME_E,  //Eng surname#
        /// </summary>
        public string EN_LAST_NAME { get; set; }

        public Bitmap PHOTO { get; set; }

        /// <summary>
        /// HOME_NO,    //12/34#
        /// </summary>
        public string HOME_NO { get; set; }

        /// <summary>
        /// MOO,        //10#
        /// </summary>
        public string MOO { get; set; }

        /// <summary>
        /// TROK,       //ตรอกxxx#
        /// </summary>
        public string TROK { get; set; }

        /// <summary>
        /// SOI,        //ซอยxxx#
        /// </summary>
        public string SOI { get; set; }

        /// <summary>
        ///  ROAD,       //ถนนxxx#
        /// </summary>
        public string ROAD { get; set; }

        /// <summary>
        /// TUMBON,     //ตำบลxxx#
        /// </summary>
        public string TUMBON { get; set; }

        /// <summary>
        /// AMPHOE,     //อำเภอxxx#
        /// </summary>
        public string AMPHOE { get; set; }

        /// <summary>
        ///  PROVINCE,   //จังหวัดxxx#
        /// </summary>
        public string PROVINCE { get; set; }

        /// <summary>
        /// GENDER,     //1#			//1=male,2=female
        /// </summary>
        public string GENDER { get; set; }

        /// <summary>
        /// BIRTH_DATE, //25200131#	    //YYYYMMDD 
        /// </summary>
        public string BIRTH_DATE { get; set; }

        /// <summary>
        ///  ISSUE_PLACE,//xxxxxxx#      //
        /// </summary>
        public string ISSUE_PLACE { get; set; }

        /// <summary>
        /// ISSUE_DATE, //25580131#     //YYYYMMDD 
        /// </summary>
        public string ISSUE_DATE { get; set; }

        /// <summary>
        /// EXPIRY_DATE,//25680130      //YYYYMMDD 
        /// </summary>
        public string EXPIRY_DATE { get; set; }
        /// <summary>
        /// ISSUE_NUM,  //12345678901234 //14-Char
        /// </summary>
        public string ISSUE_NUM { get; set; }
    }
}
