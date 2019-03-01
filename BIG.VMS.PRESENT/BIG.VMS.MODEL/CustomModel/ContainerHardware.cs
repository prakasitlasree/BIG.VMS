using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIG.VMS.MODEL.CustomModel
{
  public  class ContainerHardware
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public string ExceptionMessage { get; set; }

        public dynamic ResultObj { get; set; }

        public dynamic Filter { get; set; }

        public PIDCard PIDCard { get; set; }

    }
}
