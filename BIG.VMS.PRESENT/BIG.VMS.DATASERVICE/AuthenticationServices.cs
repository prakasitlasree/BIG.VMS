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
    public class AuthenticationServices : IService<ContainerAuthentication>
    {

        public ContainerAuthentication Retrieve(ContainerAuthentication authen)
        {
            var result = new ContainerAuthentication();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {
                    var filter = (AuthenticationFilter)authen.Filter;
                    var obj = ctx.MEMBER_LOGON.FirstOrDefault(x => x.USERNAME == filter.UserName && x.PASSWORD == filter.Password);

                    if (obj != null)
                    {
                        result.ResultObj = obj;
                        result.Status = true;
                    }
                    else
                    {
                        var chkUsername = ctx.MEMBER_LOGON.FirstOrDefault(x => x.USERNAME == filter.UserName);
                        if (chkUsername != null)
                        {
                            result.Message = " USERNAME ไม่ถูกต้อง";
                        }
                        else
                        {
                            result.Message = " PASSWORD ไม่ถูกต้อง";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.ExceptionMessage = ex.Message;
            }
            return result;
        }

        public ContainerAuthentication Create(ContainerAuthentication obj)
        {
            throw new NotImplementedException();
        }

        public ContainerAuthentication Update(ContainerAuthentication obj)
        {
            throw new NotImplementedException();
        }

        public ContainerAuthentication Delete(ContainerAuthentication obj)
        {
            throw new NotImplementedException();
        }

        public ContainerAuthentication GetItem(ContainerAuthentication obj)
        {
            throw new NotImplementedException();
        }
    }
}
