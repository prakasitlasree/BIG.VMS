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
            var result = new ContainerAuthentication();
            try
            {
                using (var ctx = new BIG_VMSEntities())
                {
                   var obj = ctx.MEMBER_LOGON.Where(x => x.USERNAME == username && x.PASSWORD == password).FirstOrDefault();
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
                throw ex;
            }
            return result;
        }

        public void AddItem()
        {
            throw new NotImplementedException();
        }

        public void AddList()
        {
            throw new NotImplementedException();
        }

        public void DeleteItem()
        {
            throw new NotImplementedException();
        }

        public void DeleteList()
        {
            throw new NotImplementedException();
        }

      

        public void GetList()
        {
            throw new NotImplementedException();
        }

        public void GetListInclude()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem()
        {
            throw new NotImplementedException();
        }

        public void UpdateList()
        {
            throw new NotImplementedException();
        }
 
    }
}
