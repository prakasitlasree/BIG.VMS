using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIG.VMS.MODEL
{
    public interface ICard<T>
    {
        T Read(T obj);
        T Write(T obj);
    }
}
