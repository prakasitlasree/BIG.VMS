using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIG.VMS.DAL;
using BIG.VMS.MODEL;
using BIG.VMS.MODEL.EntityModel;

namespace BIG.VMS.DATASERVICE
{
    public class AuthenticationServices   
    {
        public ContainerAuthentication GetItem(string username,string password)
        {
            ContainerAuthentication result = new ContainerAuthentication();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                { 
                   var obj = ctx.MEMBER_LOGON.FirstOrDefault(x => x.USERNAME == username && x.PASSWORD == password);

                    if (obj != null)
                    {
                        result.ResultObj = obj;
                        result.Status = true;
                    }
                    else
                    {
                        result.Message = " USERNAME & PASSWORD ไม่ถูกต้อง";
                        result.Status = false;
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
 
    }
}
