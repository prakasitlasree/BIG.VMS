using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIG.VMS.MODEL.CustomModel;

namespace BIG.VMS.MODEL
{
    public interface IService<T>
    { 
            string Create(T obj);
            T Retrieve(string key);
            void Update(T obj);
            void Delete(string key);
      

    }
}
