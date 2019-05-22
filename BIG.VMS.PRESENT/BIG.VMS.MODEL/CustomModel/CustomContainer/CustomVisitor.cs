using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIG.VMS.MODEL.CustomModel.CustomContainer
{
    public class CustomVisitor
    {
        public int AUTO_ID { get; set; }
        public int? NO { get; set; }
        public string ID_CARD { get; set; }
        public string TYPE { get; set; }
        public string NAME { get; set; }      
        public string PROVINCE { get; set; }
        public string LICENSE_PLATE { get; set; }
        public string CAR_TYPE_NAME { get; set; }
        public string CONTACT_NAME { get; set; }
        public string DEPT_NAME { get; set; }
        public DateTime? TIME_IN { get; set; }
        public DateTime? TIME_OUT { get; set; }
        public string BLACKLIST { get; set; }
        public string TOPIC { get; set; }
        public byte[] ID_CARD_PHOTO { get; set; }
        public byte[] CONTACT_PHOTO { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public Nullable<int> CAR_MODEL_ID { get; set; }
        public Nullable<int> LICENSE_PLATE_PROVINCE_ID { get; set; }
        public Nullable<int> REASON_ID { get; set; }
        public Nullable<int> CONTACT_EMPLOYEE_ID { get; set; }
        public Nullable<int> STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public string FULL_NAME { get; set; }

        public string COMPANY_NAME { get; set; }
    }
}
