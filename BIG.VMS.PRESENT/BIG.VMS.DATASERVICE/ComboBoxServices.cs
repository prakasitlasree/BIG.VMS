using BIG.VMS.DAL;
using BIG.VMS.MODEL.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIG.VMS.DATASERVICE
{
    public class ComboBoxServices
    {
        public List<ComboBoxItem> GetComboCarType()
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {
                    var list = ctx.MAS_CAR_TYPE.OrderBy(o => o.SHOW_SEQ).ToList();
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = item.NAME;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }

        public List<ComboBoxItem> GetComboCarType(string filter)
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {
                    var list = ctx.MAS_CAR_TYPE.Where(o => o.NAME.Contains(filter)).OrderBy(o => o.SHOW_SEQ).ToList();
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = item.NAME;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }

        public List<ComboBoxItem> GetComboCarBrandByTypeID(int carTypeID)
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {

                    var list = ctx.MAS_CAR_BRAND.Where(o => o.TYPE_ID == carTypeID).OrderBy(o => o.SHOW_SEQ).ToList();
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = item.NAME;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }

        public List<ComboBoxItem> GetComboCarBrandByTypeID(int carTypeID, string filter)
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {

                    var list = ctx.MAS_CAR_BRAND.Where(o => o.TYPE_ID == carTypeID && o.NAME.Contains(filter)).OrderBy(o => o.SHOW_SEQ).ToList();
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = item.NAME;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }

        public List<ComboBoxItem> GetComboCarModelByBrandID(int carBrandID)
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {
                    var list = ctx.MAS_CAR_MODEL.Where(o => o.BRAND_ID == carBrandID).OrderBy(o => o.SHOW_SEQ).ToList();
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = item.NAME;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }

        public List<ComboBoxItem> GetComboCarModelByBrandID(int carBrandID, string filter)
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {
                    var list = ctx.MAS_CAR_MODEL.Where(o => o.BRAND_ID == carBrandID && o.NAME.Contains(filter)).OrderBy(o => o.SHOW_SEQ).ToList();
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = item.NAME;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }

        public List<ComboBoxItem> GetComboCarModel()
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {
                    var list = ctx.MAS_CAR_MODEL.OrderBy(o => o.SHOW_SEQ).ToList();
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = item.MAS_CAR_BRAND.MAS_CAR_TYPE.NAME + "/" + item.MAS_CAR_BRAND.NAME + "/" + item.NAME + "/สี" + item.COLOR;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }

        public List<ComboBoxItem> GetComboEmployee()
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {
                    var list = ctx.MAS_EMPLOYEE.ToList();
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = "คุณ" + item.FIRST_NAME + " " + item.LAST_NAME;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }

        public List<ComboBoxItem> GetComboEmployeeByDepartmentID(int deptID)
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {
                    var list = ctx.MAS_EMPLOYEE.Where(o => o.DEPARTMENT_ID == deptID).ToList();
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = "คุณ" + item.FIRST_NAME + " " + item.LAST_NAME;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }

        public List<ComboBoxItem> GetComboReasonByDepartmentID(int deptID)
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {
                    var list = ctx.MAS_REASON.Where(o => o.DEPT_ID == deptID).ToList();
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = item.REASON;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }

        public List<ComboBoxItem> GetComboDepartment()
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {

                    var list = ctx.MAS_DEPARTMENT;
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = item.NAME;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData.OrderByDescending(x => x.Value).ToList();
        }

        public List<ComboBoxItem> GetComboDepartment(string filter)
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {

                    var list = ctx.MAS_DEPARTMENT.Where(o => o.NAME.Contains(filter));
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = item.NAME;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData.OrderByDescending(x => x.Value).ToList();
        }

        public List<ComboBoxItem> GetComboEmployeeByDepartmentID(int deptID, string filter)
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {
                    var list = ctx.MAS_EMPLOYEE.Where(o => o.DEPARTMENT_ID == deptID && (o.FIRST_NAME.Contains(filter) || o.LAST_NAME.Contains(filter))).ToList();
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = item.FIRST_NAME + " " + item.LAST_NAME;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }

        public List<ComboBoxItem> GetComboProvince()
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {
                    var list = ctx.MAS_PROVINCE.OrderBy(o => o.NAME).ToList();
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = item.NAME;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }

        public List<ComboBoxItem> GetComboProvincePriority()
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {
                    var list = ctx.MAS_PROVINCE.OrderByDescending(o => o.PRIORITY ).ThenBy(o=>o.NAME).Take(10).ToList();
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = item.NAME;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }

        public List<ComboBoxItem> GetComboReason()
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {
                    var list = ctx.MAS_REASON.OrderBy(o => o.REASON).ToList();
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = item.REASON;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }

        public List<ComboBoxItem> GetComboReason(string filter)
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {
                    var list = ctx.MAS_REASON.Where(o => o.REASON.Contains(filter)).OrderBy(o => o.REASON).ToList();
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = item.REASON;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }


        public List<ComboBoxItem> GetComboProvince(string filter)
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {
                    var list = ctx.MAS_PROVINCE.Where(o => o.NAME.Contains(filter)).OrderBy(o => o.NAME).ToList();
                    foreach (var item in list)
                    {
                        ComboBoxItem data = new ComboBoxItem();
                        data.Text = item.NAME;
                        data.Value = item.AUTO_ID;
                        listData.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }

        public List<ComboBoxItem> GetComboVisitorType()
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                ComboBoxItem data = new ComboBoxItem();
                data.Text = "เข้า";
                data.Value = 1;
                listData.Add(data);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listData;
        }
    }
}
