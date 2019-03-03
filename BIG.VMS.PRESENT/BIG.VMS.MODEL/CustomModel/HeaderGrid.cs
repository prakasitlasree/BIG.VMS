using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIG.VMS.MODEL.CustomModel
{
    public class HeaderGrid
    {
        public string HEADER_TEXT { get; set; }

        public string FIELD { get; set; }

        public bool VISIBLE { get; set; }

        public align ALIGN { get; set; }

        public autoSize AUTO_SIZE { get; set; }
    }

    public enum align
    {
        Left,
        Right,
        Center
    }
    public enum autoSize
    {
        Fill,
        CellContent
    }
}
