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
    public class CarModelServices : IService<ContainerCarModel>
    {
        public ContainerCarModel Create(ContainerCarModel obj)
        {
            var result = new ContainerCarModel();
            using (var ctx = new BIG_VMSEntities())
            {

                try
                {
                    ctx.MAS_CAR_MODEL.Add(obj.MAS_CAR_MODEL);
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

        public ContainerCarModel Delete(ContainerCarModel obj)
        {
            throw new NotImplementedException();
        }

        public ContainerCarModel GetItem(ContainerCarModel obj)
        {
            throw new NotImplementedException();
        }

        public ContainerCarModel Retrieve(ContainerCarModel obj)
        {
            throw new NotImplementedException();
        }

        public ContainerCarModel Update(ContainerCarModel obj)
        {
            throw new NotImplementedException();
        }

        public ContainerCarBrand GetAutoIDFromCarModel(string model)
        {
            ContainerCarBrand result = new ContainerCarBrand();
            try
            {
                using (BIG_VMSEntities ctx = new BIG_VMSEntities())
                {
                    var data = ctx.MAS_CAR_MODEL.Where(o=>o.NAME == model).FirstOrDefault();
                    result.ResultObj = data.AUTO_ID;
                    result.Status = true ;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
