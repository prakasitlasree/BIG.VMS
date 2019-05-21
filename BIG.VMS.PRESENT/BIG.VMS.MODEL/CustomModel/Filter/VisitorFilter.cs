﻿using System;

namespace BIG.VMS.MODEL.CustomModel
{
   public class VisitorFilter
    {
        public string TYPE { get; set; }
        public string NO { get; set; }
        public string ID_CARD { get; set; }
        public string LICENSE_PLATE { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public DateTime DATE_FROM { get; set; }
        public DateTime DATE_TO { get; set; }
    }
}
