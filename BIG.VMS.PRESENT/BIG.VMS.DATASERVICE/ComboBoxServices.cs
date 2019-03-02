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
                    var list = ctx.MAS_CAR_TYPE.ToList();
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

                    var list = ctx.MAS_CAR_BRAND.Where(o => o.TYPE_ID == carTypeID).ToList();
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
                    var list = ctx.MAS_CAR_MODEL.Where(o => o.BRAND_ID == carBrandID).ToList();
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
                    var list = ctx.MAS_CAR_MODEL.ToList();
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

        public List<ComboBoxItem> GetComboDepartment()
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {

                    var list = ctx.MAS_DEPARTMENT.ToList();
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
        public List<ComboBoxItem> GetComboProvince()
        {
            List<ComboBoxItem> listData = new List<ComboBoxItem>();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {
                    var list = ctx.MAS_PROVINCE.ToList();
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
    }
}
