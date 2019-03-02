using BIG.VMS.MODEL.EntityModel;

namespace BIG.VMS.MODEL.CustomModel
{
    public class ContainerVisitor
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public string ExceptionMessage { get; set; }

        public dynamic ResultObj { get; set; }

        public VisitorFilter Filter { get; set; }

        public TRN_VISITOR TRN_VISITOR { get; set; }
    }
}
