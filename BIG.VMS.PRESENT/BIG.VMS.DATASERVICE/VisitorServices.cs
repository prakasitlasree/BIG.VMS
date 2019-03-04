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
        public ContainerVisitor GetItem(ContainerVisitor obj)
        {
            var result = new ContainerVisitor();
            try
            {
                using (var ctx = new BIG_VMSEntities())
                {
                    var reTrnVisitor = ctx.TRN_VISITOR.OrderByDescending(x => x.NO).FirstOrDefault();
                    if (reTrnVisitor != null)
                    {


                        result.TRN_VISITOR = reTrnVisitor;
                        result.Status = true;

                    }
                    else
                    {
                        TRN_VISITOR visit = new TRN_VISITOR()
                        {
                            AUTO_ID = 0,
                            NO = "0",
                        };
                        result.TRN_VISITOR = visit;
                        result.Status = true;
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
                    result.Message = ex.Message.ToString();
                }

            }

            return result;
        }

        public ContainerVisitor Delete(ContainerVisitor obj)
        {
            var result = new ContainerVisitor();
            using (var ctx = new BIG_VMSEntities())
            {

                try
                {
                    var deleteData = ctx.TRN_VISITOR.Where(o => o.AUTO_ID == obj.TRN_VISITOR.AUTO_ID).FirstOrDefault();
                    ctx.TRN_VISITOR.Remove(deleteData);
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

        public ContainerVisitor Retrieve(ContainerVisitor obj)
        {
            var result = new ContainerVisitor();

            using (var ctx = new BIG_VMSEntities())
            {

                try
                {
                    var listData = GetListVisitorQuery(obj).ToList();

                    if (obj.PageInfo != null)
                    {
                        obj.PageInfo.TOTAL_PAGE = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(listData.Count) / Convert.ToDouble(obj.PageInfo.PAGE_SIZE)));

                        listData = listData.Skip(obj.PageInfo.PAGE_SIZE * (obj.PageInfo.PAGE - 1))
                                           .Take(obj.PageInfo.PAGE_SIZE)
                                           .ToList();

                        result.PageInfo = obj.PageInfo;
                    }
                    else
                    {
                        Pagination page = new Pagination();
                        page.TOTAL_PAGE = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(listData.Count) / Convert.ToDouble(page.PAGE_SIZE)));
                        listData = listData.Skip(page.PAGE_SIZE * (page.PAGE - 1))
                                          .Take(page.PAGE_SIZE)
                                          .ToList();

                        result.PageInfo = page;
                    }

                    result.ResultObj = listData;
                    result.Status = true;
                    result.Message = "Retrive Data Successful";
                }
                catch (Exception ex)
                {
                    result.Status = false;
                    result.Message = ex.Message.ToString();
                }

            }

            return result;
        }

        public ContainerVisitor Update(ContainerVisitor obj)
        {
            var result = new ContainerVisitor();
            using (var ctx = new BIG_VMSEntities())
            {

                try
                {
                    var updateData = ctx.TRN_VISITOR.Where(o => o.AUTO_ID == obj.TRN_VISITOR.AUTO_ID).FirstOrDefault();
                    updateData = obj.TRN_VISITOR;
                    ctx.SaveChanges();
                    result.Status = true;
                    result.Message = "Update Successful";
                }
                catch (Exception ex)
                {
                    result.Status = false;
                    result.Message = ex.Message.ToString();
                }

            }

            return result;
        }

        public IQueryable<TRN_VISITOR> GetListVisitorQuery(ContainerVisitor obj)
        {

            try
            {
                var ctx = new BIG_VMSEntities();
                
                    var filter = obj.Filter;
                    IQueryable<TRN_VISITOR> query = ctx.TRN_VISITOR;
                    if (obj.Filter != null)
                    {

                        if (!string.IsNullOrEmpty(filter.ID_CARD))
                        {
                            query = query.Where(o => o.ID_CARD == filter.ID_CARD);
                        }
                        if (!string.IsNullOrEmpty(filter.TYPE))
                        {
                            query = query.Where(o => o.TYPE == filter.TYPE);
                        }
                        if (!string.IsNullOrEmpty(filter.LICENSE_PLATE))
                        {
                            query = query.Where(o => o.LICENSE_PLATE == filter.LICENSE_PLATE);
                        }
                        if (!string.IsNullOrEmpty(filter.NO))
                        {
                            query = query.Where(o => o.NO == filter.NO);
                        }

                        return query;
                    }
                    else
                    {
                        return query;
                    }            

            }
            catch
            {
                throw;
            }
        }
    }
}
