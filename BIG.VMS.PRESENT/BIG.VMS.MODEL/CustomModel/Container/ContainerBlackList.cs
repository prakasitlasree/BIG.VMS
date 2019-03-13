using BIG.VMS.MODEL.CustomModel.Filter;
using BIG.VMS.MODEL.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIG.VMS.MODEL.CustomModel.Container
{
    public class ContainerBlackList
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public string ExceptionMessage { get; set; }

        public dynamic ResultObj { get; set; }

        public BlacklistFilter Filter { get; set; }

        public TRN_BLACKLIST TRN_BLACKLIST { get; set; }

        public Pagination PageInfo { get; set; }
    }
}
