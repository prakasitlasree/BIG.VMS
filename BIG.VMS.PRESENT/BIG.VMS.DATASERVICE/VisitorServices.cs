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
                
                try
                {
                    ctx.TRN_VISITOR.Add(obj.TRN_VISITOR);
                    ctx.SaveChanges();
                    result.Status = true;
                    result.Message = "Save Successful";
                }
                catch (Exception ex)
                {
                    result.Status = false;
                    result.Message = ex.Message.ToString() ;
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
