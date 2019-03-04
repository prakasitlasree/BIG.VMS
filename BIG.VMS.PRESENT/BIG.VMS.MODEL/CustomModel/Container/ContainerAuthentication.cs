using BIG.VMS.MODEL.EntityModel;

namespace BIG.VMS.MODEL.CustomModel
{
    public class ContainerAuthentication  
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public string ExceptionMessage { get; set; }

        public dynamic ResultObj { get; set; }

        public  dynamic Filter { get; set; }

        public MEMBER_LOGON MEMBER_LOGON { get; set; }
    }
}
