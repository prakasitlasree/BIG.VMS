using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIG.VMS.DAL;
using BIG.VMS.MODEL;
using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.MODEL.EntityModel;

namespace BIG.VMS.DATASERVICE
{
    public class VisitorServices : IService<ContainerVisitor>
    {
        public ContainerVisitor Create(ContainerVisitor obj)
        {
            var result = new ContainerVisitor();
            using (var ctx = new BIG_VMSEntities())
            {
                ctx.TRN_VISITOR.Add(obj.TRN_VISITOR);
                var saveObj = ctx.SaveChanges();
                if (saveObj == 1)
                {
                    result.ResultObj = obj.TRN_VISITOR;
                    result.Status = true;
                    result.Message = "Save Successful";
                } 
            }

            return result;
        }

        public ContainerVisitor Delete(ContainerVisitor obj)
        {
            throw new NotImplementedException();
        }

        public ContainerVisitor Retrieve(ContainerVisitor obj)
        {
            throw new NotImplementedException();
        }

        public ContainerVisitor Update(ContainerVisitor obj)
        {
            throw new NotImplementedException();
        }
    }
}
