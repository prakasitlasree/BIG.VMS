using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIG.VMS.MODEL
{
    public interface IService
    {
        List<dynamic> GetList();
        void GetItem();

        void GetListInclude();

        void AddList();

        void AddItem();

        void UpdateItem();

        void UpdateList();

        void DeleteList();

        void DeleteItem();

    }
}
