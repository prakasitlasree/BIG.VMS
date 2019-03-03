using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIG.VMS.MODEL.CustomModel
{
    public class Pagination
    {
        public Pagination()
        {
            PAGE = 1;
            PAGE_SIZE = 100;
            TOTAL_PAGE = 1;
        }

        public int PAGE { get; set; }
        public int PAGE_SIZE { get; set; }
        public int TOTAL_PAGE { get; set; }
    }



}
