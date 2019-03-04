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
    public class CarBrandServices : IService<ContainerCarBrand>
    {
        public ContainerCarBrand Create(ContainerCarBrand obj)
        {
            var result = new ContainerCarBrand();
            using (var ctx = new BIG_VMSEntities())
            {

                try
                {
                    ctx.MAS_CAR_BRAND.Add(obj.MAS_CAR_BRAND);
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

        public ContainerCarBrand Delete(ContainerCarBrand obj)
        {
            throw new NotImplementedException();
        }

        public ContainerCarBrand GetItem(ContainerCarBrand obj)
        {
            throw new NotImplementedException();
        }

        public ContainerCarBrand Retrieve(ContainerCarBrand obj)
        {
            throw new NotImplementedException();
        }

        public ContainerCarBrand Update(ContainerCarBrand obj)
        {
            throw new NotImplementedException();
        }
    }
}
