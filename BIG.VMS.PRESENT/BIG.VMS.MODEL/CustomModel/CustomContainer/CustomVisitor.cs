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
        public string NO { get; set; }
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
    }
}
