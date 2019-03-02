using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIG.VMS.MODEL.CustomModel.Filter
{
   public  class AppointmentFilter
    {
        public string NAME { get; set; }
        public DateTime CONTACT_DATE { get; set; }
        public string ID_CARD { get; set; }
        public string LICENSE_PLATE { get; set; }
        public string CONTACT_EMPLOYEE_NAME { get; set; }
    }
}
