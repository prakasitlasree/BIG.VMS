using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIG.VMS.MODEL.CustomModel.CustomContainer
{
    public class CustomAppointment
    {
        public int AUTO_ID { get; set; }
        public string REQUEST_ID_CARD { get; set; }
        public string REQUEST_FIRST_NAME { get; set; }
        public string REQUEST_LAST_NAME { get; set; }
        public string REQUEST_LICENSE_PLATE { get; set; }
        public Nullable<int> REQUEST_LICENSE_PLATE_PROVINCE_ID { get; set; }
        public Nullable<int> REQUEST_CAR_MODEL_ID { get; set; }
        public Nullable<int> CONTACT_EMPLOYEE_ID { get; set; }
        public Nullable<int> REASON_ID { get; set; }
        public Nullable<System.DateTime> CONTACT_DATE { get; set; }
        public string STATUS { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }


        public string REQUEST_NAME { get; set; }
        public string CONTACT_EMPLOYEE_NAME { get; set; }
        public string REQUEST_CAR_NAME { get; set; }
        public string REASON_NAME { get; set; }

    }
}
