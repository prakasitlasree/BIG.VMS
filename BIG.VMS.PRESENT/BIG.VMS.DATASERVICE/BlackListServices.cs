using BIG.VMS.DAL;
using BIG.VMS.MODEL;
using BIG.VMS.MODEL.CustomModel.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIG.VMS.DATASERVICE
{
    public class BlackListServices : IService<ContainerBlackList>
    {
        public ContainerBlackList Create(ContainerBlackList obj)
        {
            var result = new ContainerBlackList();
            using (var ctx = new BIG_VMSEntities())
            {

                try
                {
                    ctx.TRN_BLACKLIST.Add(obj.TRN_BLACKLIST);
                    ctx.SaveChanges();
                    result.Status = true;
                    result.Message = "Save Successful";
                }
                catch (Exception ex)
                {
                    result.Status = false;
                    result.Message = ex.Message.ToString();
                }

            }

            return result;
        }

        public ContainerBlackList GetBlackListByIdCard(string IdCard)
        {
            var result = new ContainerBlackList();
            bool isBlackList = false;
            using (var ctx = new BIG_VMSEntities())
            {

                try
                {
                    var blackList = ctx.TRN_BLACKLIST.Where(o => o.ID_CARD == IdCard).FirstOrDefault();
                    if (blackList != null)
                    {
                        isBlackList = true;
                        result.ResultObj = isBlackList;
                        result.TRN_BLACKLIST = blackList;
                    }
                    else
                    {
                        result.ResultObj = isBlackList;
                    }
                    result.Status = true;

                }
                catch (Exception ex)
                {
                    result.Status = false;
                    result.Message = ex.Message.ToString();
                }

            }

            return result;
        }

        public ContainerBlackList Delete(ContainerBlackList obj)
        {
            var result = new ContainerBlackList();
            using (var ctx = new BIG_VMSEntities())
            {

                try
                {
                    var deleteData = ctx.TRN_BLACKLIST.Where(o => o.AUTO_ID == obj.TRN_BLACKLIST.AUTO_ID).FirstOrDefault();
                    ctx.TRN_BLACKLIST.Remove(deleteData);
                    ctx.SaveChanges();
                    result.Status = true;
                    result.Message = "Delete Successful";
                }
                catch (Exception ex)
                {
                    result.Status = false;
                    result.Message = ex.Message.ToString();
                }

            }

            return result;
        }

        public ContainerBlackList GetItem(ContainerBlackList obj)
        {
            throw new NotImplementedException();
        }

        public ContainerBlackList Retrieve(ContainerBlackList obj)
        {
            var result = new ContainerBlackList();
            using (var ctx = new BIG_VMSEntities())
            {

                try
                {
                    var blackList = ctx.TRN_BLACKLIST.ToList();
                    if (obj.Filter != null)
                    {
                        if (!string.IsNullOrEmpty(obj.Filter.ID_CARD))
                        {
                            blackList = blackList.Where(o => o.ID_CARD == obj.Filter.ID_CARD).ToList();
                        }
                    }
                    result.ResultObj = blackList;
                    result.Status = true;

                }
                catch (Exception ex)
                {
                    result.Status = false;
                    result.Message = ex.Message.ToString();
                }

            }

            return result;
        }

        public ContainerBlackList Update(ContainerBlackList obj)
        {
            throw new NotImplementedException();
        }
    }
}
