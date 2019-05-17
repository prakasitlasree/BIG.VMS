using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIG.VMS.DAL;
using BIG.VMS.MODEL;
using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.MODEL.EntityModel;
using BIG.VMS.MODEL.CustomModel.CustomContainer;
using System.Globalization;

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
                    result.ResultObj = obj.TRN_VISITOR;
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
                    var list = GetListVisitorQuery(obj).OrderByDescending(o => o.UPDATED_DATE).ToList();

                    var listData = new List<CustomVisitor>();
                    listData = (from item in list
                                select new CustomVisitor
                                {
                                    AUTO_ID = item.AUTO_ID,
                                    NO =item.NO,
                                    ID_CARD = item.ID_CARD,
                                    ID_CARD_PHOTO = item.ID_CARD_PHOTO,
                                    TYPE = item.TYPE,
                                    FIRST_NAME = item.FIRST_NAME,
                                    LAST_NAME = item.LAST_NAME,
                                    CAR_MODEL_ID = item.CAR_MODEL_ID,
                                    LICENSE_PLATE = item.LICENSE_PLATE,
                                    LICENSE_PLATE_PROVINCE_ID = item.LICENSE_PLATE_PROVINCE_ID,
                                    REASON_ID = item.REASON_ID,
                                    CONTACT_EMPLOYEE_ID = item.CONTACT_EMPLOYEE_ID,
                                    CONTACT_PHOTO = item.CONTACT_PHOTO,
                                    STATUS = item.STATUS,
                                    CREATED_BY = item.CREATED_BY,
                                    CREATED_DATE = item.CREATED_DATE,
                                    UPDATED_BY = item.UPDATED_BY,
                                    UPDATED_DATE = item.UPDATED_DATE,
                                   
                                    CONTACT_NAME = item.MAS_EMPLOYEE.FIRST_NAME + " " +item.MAS_EMPLOYEE.LAST_NAME,
                                    CAR_TYPE_NAME = item.MAS_CAR_MODEL.NAME,
                                    FULL_NAME = item.FIRST_NAME + " " + item.LAST_NAME,
                                    DEPT_NAME = item.MAS_EMPLOYEE.MAS_DEPARTMENT.NAME,
                                    TIME_IN  = item.CREATED_DATE,
                                    TOPIC  = item.MAS_REASON.REASON

                                }).ToList();


                    foreach (var item in listData)
                    {
                        if (item.TYPE == "In")
                        {
                            item.TYPE = "เข้า";
                        }
                        else if (item.TYPE == "Out")
                        {
                            item.TYPE = "ออก";
                        }
                        else if (item.TYPE == "Regulary")
                        {
                            item.TYPE = "มาประจำ";
                        }

                    }

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
                    var visitorObj = obj.TRN_VISITOR;
                    var updateData = ctx.TRN_VISITOR.Where(o => o.AUTO_ID == obj.TRN_VISITOR.AUTO_ID).FirstOrDefault();
                    if (updateData != null)
                    {


                        updateData.ID_CARD = visitorObj.ID_CARD;                   
                        updateData.FIRST_NAME = visitorObj.FIRST_NAME;
                        updateData.LAST_NAME = visitorObj.LAST_NAME;
                        updateData.CAR_MODEL_ID = visitorObj.CAR_MODEL_ID;
                        updateData.LICENSE_PLATE = visitorObj.LICENSE_PLATE;
                        updateData.LICENSE_PLATE_PROVINCE_ID = visitorObj.LICENSE_PLATE_PROVINCE_ID;
                        updateData.REASON_ID = visitorObj.REASON_ID;
                        updateData.CONTACT_EMPLOYEE_ID = visitorObj.CONTACT_EMPLOYEE_ID;                   
                        updateData.UPDATED_DATE = DateTime.Now;
                        updateData.UPDATED_BY = visitorObj.UPDATED_BY;
                        if(obj.TRN_VISITOR.CONTACT_PHOTO != null)
                        {
                            updateData.CONTACT_PHOTO = visitorObj.CONTACT_PHOTO;
                        }
                        
                        ctx.SaveChanges();
                        result.Status = true;
                        result.Message = "บันทึกข้อมูลเรียบร้อย";
                    }
                    else
                    {
                        result.Status = false;
                        result.Message = "แก้ไขไม่สำเร็จ";
                    }
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
                    if(filter.DATE_TO != null&& filter.DATE_TO != DateTime.MinValue)
                    {
                        var endDate = filter.DATE_TO.AddDays(1);
                        query = query.Where(x => x.CREATED_DATE >= filter.DATE_TO && x.CREATED_DATE <= endDate);
                        
                    }

                    query.OrderByDescending(o => o.UPDATED_DATE);
                    return query;
                }
                else
                {
                    query.OrderByDescending(o => o.UPDATED_DATE);
                    return query;
                }

            }
            catch
            {
                throw;
            }
        }

        public ContainerVisitor GetVisitorForOutByNo(string no)
        {
            var result = new ContainerVisitor();
            try
            {
                using (var ctx = new BIG_VMSEntities())
                {

                    var reTrnVisitor = ctx.TRN_VISITOR
                                          .Include("MAS_PROVINCE")
                                          .Where(o => o.NO == no && (o.TYPE == "In" || o.TYPE == "Regulary") && o.STATUS == 1)
                                          .OrderByDescending(x => x.NO).FirstOrDefault();

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

        public ContainerVisitor GetVisitorByAutoID(int auto_id)
        {
            var result = new ContainerVisitor();
            try
            {

                using (var ctx = new BIG_VMSEntities())
                {
                    var reTrnVisitor = ctx.TRN_VISITOR
                                          .Include("MAS_EMPLOYEE")
                                          .Include("MAS_REASON")
                                          .Include("MAS_PROVINCE")
                                          .Include("MAS_CAR_MODEL")
                                          .Where(x => x.AUTO_ID == auto_id).FirstOrDefault();
                    if (reTrnVisitor != null)
                    {
                        //var x = string.Join(",",reTrnVisitor.ID_CARD_PHOTO);
                        result.TRN_VISITOR = reTrnVisitor;
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

        public ContainerVisitor GetVisitorByAutoIDForReport(int auto_id)
        {
            var result = new ContainerVisitor();

            List<CustomVisitor> listData = new List<CustomVisitor>();
            CultureInfo _cultureTHInfo = new CultureInfo("th-TH");
            try
            {
                using (var ctx = new BIG_VMSEntities())
                {
                    var reTrnVisitor = ctx.TRN_VISITOR
                                          .Include("MAS_EMPLOYEE")
                                          .Include("MAS_REASON")
                                          .Include("MAS_PROVINCE")
                                          .Include("MAS_CAR_MODEL")
                                          .Where(x => x.AUTO_ID == auto_id).ToList();

                    var reParameter = ctx.SYS_CONFIGURATION.Where(x => x.MODULE == "SLIP" && x.NAME == "COMPANY_NAME").FirstOrDefault();
                    string company = "";
                    if (reParameter!= null)
                    {
                        company = reParameter.VALUE;
                    }
                    else
                    {
                        company = "BIG Visitor Management";
                    }
                    if (reTrnVisitor.Count > 0)
                    {


                        listData = (from item in reTrnVisitor
                                    select new CustomVisitor
                                    {
                                        AUTO_ID = item.AUTO_ID,
                                        NO = item.NO,
                                        ID_CARD = item.ID_CARD,
                                        NAME = item.FIRST_NAME + " " + item.LAST_NAME,
                                        CAR_TYPE_NAME = item.MAS_CAR_MODEL.MAS_CAR_BRAND.MAS_CAR_TYPE != null ? item.MAS_CAR_MODEL.MAS_CAR_BRAND.MAS_CAR_TYPE.NAME : "",
                                        LICENSE_PLATE = item.LICENSE_PLATE,
                                        PROVINCE = item.MAS_PROVINCE != null ? item.MAS_PROVINCE.NAME : "",
                                        TOPIC = item.MAS_REASON != null ? item.MAS_REASON.REASON : "",
                                        CONTACT_NAME = item.MAS_EMPLOYEE != null ? item.MAS_EMPLOYEE.FIRST_NAME + " " + item.MAS_EMPLOYEE.LAST_NAME : "",
                                        TIME_IN = item.CREATED_DATE.Value != null ? Convert.ToDateTime(item.CREATED_DATE.Value, _cultureTHInfo) : item.CREATED_DATE,
                                        TYPE = item.TYPE == "In" ? "เข้า" : (item.TYPE == "Out" ? "ออก" : (item.TYPE == "Regulary" ? "มาประจำ" : "ไม่ระบุ")),
                                        DEPT_NAME = item.MAS_EMPLOYEE.MAS_DEPARTMENT != null ? item.MAS_EMPLOYEE.MAS_DEPARTMENT.NAME : "ไม่ระบุ",
                                        ID_CARD_PHOTO = item.ID_CARD_PHOTO,
                                        CONTACT_PHOTO = item.CONTACT_PHOTO,
                                        COMPANY_NAME = company

                                    }).ToList();
                    }

                    result.ResultObj = listData;
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.ExceptionMessage = ex.Message;
            }
            return result;
        }

        public List<ReportParameter> GetReportParameter()
        {
            List<ReportParameter> listData = new List<ReportParameter>();
            try
            {
                using (var ctx = new BIG_VMSEntities())
                {
                    var reParameter = ctx.SYS_CONFIGURATION.Where(x => x.MODULE == "SLIP").ToList();
                    if (reParameter.Count > 0)
                    {
                        listData = (from item in reParameter
                                    select new ReportParameter
                                    {
                                        MODULE = item.MODULE,
                                        NAME = item.NAME,
                                        VALUE = item.VALUE,
                                        DESCRIPTION = item.DESCRIPTION
                                    }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }

        public ContainerVisitor UpdateVisitorOut(ContainerVisitor obj)
        {
            var result = new ContainerVisitor();
            try
            {
                using (var ctx = new BIG_VMSEntities())
                {

                    var reTrnVisitor = ctx.TRN_VISITOR.Where(o => o.NO == obj.TRN_VISITOR.NO).FirstOrDefault();



                    if (reTrnVisitor != null)
                    {

                        reTrnVisitor.STATUS = 2;
                        ctx.SaveChanges();
                        result.Status = true;
                    }
                    else
                    {
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

        public ContainerVisitor GetRegularyVisitor()
        {
            var result = new ContainerVisitor();
            try
            {
                using (var ctx = new BIG_VMSEntities())
                {
                    var listVisitorGroup = new List<VisitorGroupModel>();

                    var group = ctx.TRN_VISITOR.Where(x => (x.TYPE == "In" || x.TYPE == "Regulary") && x.ID_CARD_PHOTO != null).GroupBy(o => o.ID_CARD)
                                               .Select(o => o.FirstOrDefault()).ToList();

                    var allIdCard = group.Select(o => o.ID_CARD).ToList();

                    foreach (var id in allIdCard)
                    {
                        VisitorGroupModel visitor = new VisitorGroupModel();
                        visitor.Key = id;
                        visitor.Count = ctx.TRN_VISITOR.Where(x => (x.TYPE == "In" || x.TYPE == "Regulary") && x.ID_CARD_PHOTO != null).Count();
                        listVisitorGroup.Add(visitor);
                    }

                    listVisitorGroup = listVisitorGroup.OrderByDescending(o => o.Count).Take(10).ToList();
                    var listTopIdCard = listVisitorGroup.Select(x => x.Key).ToList();

                    var listData = ctx.TRN_VISITOR.Where(x => listTopIdCard.Contains(x.ID_CARD) && ((x.TYPE == "In" || x.TYPE == "Regulary") && x.ID_CARD_PHOTO != null)).GroupBy(o => o.ID_CARD).Select(o => o.FirstOrDefault()).ToList();

                    result.ResultObj = listData;
                    result.Status = true;
                    result.Message = "Retrive Data Successful";
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.ExceptionMessage = ex.Message;
            }
            return result;
        }

        public ContainerVisitor GetVisitorForReport(ContainerVisitor obj)
        {
            var result = new ContainerVisitor();
            var filter = obj.Filter;
            DateTime startDate = filter.DATE_FROM.Date;
            DateTime endDate = filter.DATE_TO.AddDays(1).Date;
            List<CustomVisitor> listData = new List<CustomVisitor>();
            CultureInfo _cultureTHInfo = new CultureInfo("th-TH");
            try
            {


                using (var ctx = new BIG_VMSEntities())
                {
                    var reTrnVisitor = ctx.TRN_VISITOR
                                          .Include("MAS_EMPLOYEE")
                                          .Include("MAS_REASON")
                                          .Include("MAS_PROVINCE")
                                          .Include("MAS_CAR_MODEL")
                                          .Where(x => x.CREATED_DATE >= startDate && x.CREATED_DATE <= endDate).ToList();


                    if (reTrnVisitor.Count > 0)
                    {


                        listData = (from item in reTrnVisitor
                                    select new CustomVisitor
                                    {
                                        AUTO_ID = item.AUTO_ID,
                                        NO = item.NO,
                                        ID_CARD = item.ID_CARD,
                                        NAME = item.FIRST_NAME + " " + item.LAST_NAME,
                                        CAR_TYPE_NAME = item.MAS_CAR_MODEL.MAS_CAR_BRAND.MAS_CAR_TYPE != null ? item.MAS_CAR_MODEL.MAS_CAR_BRAND.MAS_CAR_TYPE.NAME : "",
                                        LICENSE_PLATE = item.LICENSE_PLATE,
                                        PROVINCE = item.MAS_PROVINCE != null ? item.MAS_PROVINCE.NAME : "",
                                        CONTACT_NAME = item.MAS_EMPLOYEE != null ? item.MAS_EMPLOYEE.FIRST_NAME + " " + item.MAS_EMPLOYEE.LAST_NAME : "",
                                        TIME_IN = item.CREATED_DATE.Value != null ? Convert.ToDateTime(item.CREATED_DATE.Value, _cultureTHInfo) : item.CREATED_DATE,
                                        TYPE = item.TYPE == "In" ? "เข้า" : (item.TYPE == "Out" ? "ออก" : (item.TYPE == "Regulary" ? "มาประจำ" : "ไม่ระบุ")),
                                        DEPT_NAME = item.MAS_EMPLOYEE.MAS_DEPARTMENT != null ? item.MAS_EMPLOYEE.MAS_DEPARTMENT.NAME : "ไม่ระบุ",
                                        ID_CARD_PHOTO = item.ID_CARD_PHOTO,
                                        CONTACT_PHOTO = item.CONTACT_PHOTO,
                                        CREATED_BY = item.CREATED_BY,
                                        CREATED_DATE = item .CREATED_DATE,
                                        UPDATED_BY = item.UPDATED_BY,
                                        UPDATED_DATE = item.UPDATED_DATE

                                        

                                    }).ToList();


                    }

                    result.ResultObj = listData;
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
