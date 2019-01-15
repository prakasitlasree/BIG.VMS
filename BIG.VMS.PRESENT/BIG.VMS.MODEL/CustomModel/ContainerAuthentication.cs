using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIG.VMS.MODEL;
using BIG.VMS.MODEL.EntityModel;

namespace BIG.VMS.MODEL
{
    public class ContainerAuthentication  
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public dynamic ResultObj { get; set; }
    }
}
