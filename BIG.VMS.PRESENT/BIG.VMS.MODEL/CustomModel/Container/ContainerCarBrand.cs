using BIG.VMS.MODEL.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIG.VMS.MODEL.CustomModel.Container
{
    public class ContainerCarBrand
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public string ExceptionMessage { get; set; }

        public dynamic ResultObj { get; set; }

        public dynamic Filter { get; set; }

        public MAS_CAR_BRAND MAS_CAR_BRAND { get; set; }

        public Pagination PageInfo { get; set; }
    }
}
