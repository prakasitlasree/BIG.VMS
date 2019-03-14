using BIG.VMS.DAL;
using BIG.VMS.MODEL;
using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.MODEL.CustomModel.CustomContainer;
using BIG.VMS.MODEL.CustomModel.Filter;
using BIG.VMS.MODEL.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIG.VMS.DATASERVICE
{
    public class AppointmentServices : IService<ContainerAppointment>
    {
        public ContainerAppointment Create(ContainerAppointment obj)
        {
            var result = new ContainerAppointment();
            using (var ctx = new BIG_VMSEntities())
            {

                try
                {
                    ctx.TRN_APPOINTMENT.Add(obj.TRN_APPOINTMENT);
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

        public ContainerAppointment Delete(ContainerAppointment obj)
        {
            throw new NotImplementedException();
        }

        public ContainerAppointment GetItem(ContainerAppointment obj)
        {
            throw new NotImplementedException();
        }

        public ContainerAppointment Retrieve(ContainerAppointment obj)
        {
            var result = new ContainerAppointment();
            using (var ctx = new BIG_VMSEntities())
            {

                try
                {
                    var listData = new List<CustomAppointment>();
                    var listApointment = GetListAppointmentQuery(obj).ToList();

                    listData = (from item in listApointment
                                select new CustomAppointment
                                {
                                    AUTO_ID = item.AUTO_ID,
                                    CONTACT_DATE = item.CONTACT_DATE,
                                    CONTACT_EMPLOYEE_ID =item.CONTACT_EMPLOYEE_ID,
                                    CONTACT_EMPLOYEE_NAME = item.MAS_EMPLOYEE.FIRST_NAME + " " + item.MAS_EMPLOYEE.LAST_NAME,
                                    CREATED_BY =item.CREATED_BY,
                                    STATUS = item.STATUS,
                                    REASON_ID =item.REASON_ID,
                                    REASON_NAME = item.MAS_REASON.REASON,
                                    REQUEST_CAR_MODEL_ID = item.REQUEST_CAR_MODEL_ID,
                                    REQUEST_NAME =  item.REQUEST_FIRST_NAME + " "+item.REQUEST_LAST_NAME,
                                    REQUEST_LICENSE_PLATE = item.REQUEST_LICENSE_PLATE,
                                    REQUEST_LICENSE_PLATE_PROVINCE_ID = item.REQUEST_LICENSE_PLATE_PROVINCE_ID,
                                    REQUEST_ID_CARD = item.REQUEST_ID_CARD,
                                    UPDATED_BY = item.UPDATED_BY,
                                    REQUEST_CAR_NAME = item.MAS_CAR_MODEL.NAME,
                                    
                                }).ToList();



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

        public ContainerAppointment Update(ContainerAppointment obj)
        {
            throw new NotImplementedException();
        }

        public ContainerAppointment UpdateStatus(int autoID)
        {
            var result = new ContainerAppointment();
            using (var ctx = new BIG_VMSEntities())
            {

                try
                {
                    var data = ctx.TRN_APPOINTMENT.Where(o => o.AUTO_ID == autoID).FirstOrDefault();
                    data.STATUS = "เข้าพบแล้ว";
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

        public IQueryable<TRN_APPOINTMENT> GetListAppointmentQuery(ContainerAppointment obj)
        {

            try
            {
                var ctx = new BIG_VMSEntities();

                var filter = obj.Filter;
                IQueryable<TRN_APPOINTMENT> query = ctx.TRN_APPOINTMENT;
                if (filter != null)
                {
                    if (!string.IsNullOrEmpty(filter.ID_CARD))
                    {
                        query = query.Where(o => o.REQUEST_ID_CARD.Contains(filter.ID_CARD));
                    }
                    if (!string.IsNullOrEmpty(filter.LICENSE_PLATE))
                    {
                        query = query.Where(o => o.REQUEST_LICENSE_PLATE.Contains(filter.LICENSE_PLATE));
                    }
                    if (!string.IsNullOrEmpty(filter.FIRST_NAME))
                    {
                        query = query.Where(o => o.REQUEST_FIRST_NAME.Contains(filter.FIRST_NAME));
                    }
                    if (!string.IsNullOrEmpty(filter.LAST_NAME))
                    {
                        query = query.Where(o => o.REQUEST_LAST_NAME.Contains(filter.LAST_NAME));
                    }
                    if (filter.CONTACT_DATE != null && filter.CONTACT_DATE != DateTime.MinValue)
                    {
                        var dateFrom = filter.CONTACT_DATE.AddDays(1);
                        var dateTo = filter.CONTACT_DATE.AddDays(-1);
                        query = query.Where(o => o.CONTACT_DATE < dateFrom && o.CONTACT_DATE >= dateTo);
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
