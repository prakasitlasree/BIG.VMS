//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BIG.VMS.MODEL.EntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class TRN_VISITOR
    {
        public int AUTO_ID { get; set; }
        public string NO { get; set; }
        public string ID_CARD { get; set; }
        public byte[] ID_CARD_PHOTO { get; set; }
        public string TYPE { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public Nullable<int> CAR_MODEL_ID { get; set; }
        public string LICENSE_PLATE { get; set; }
        public Nullable<int> LICENSE_PLATE_PROVINCE_ID { get; set; }
        public Nullable<int> REASON_ID { get; set; }
        public Nullable<int> CONTACT_EMPLOYEE_ID { get; set; }
        public byte[] CONTACT_PHOTO { get; set; }
        public Nullable<int> STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
    
        public virtual MAS_CAR_MODEL MAS_CAR_MODEL { get; set; }
        public virtual MAS_EMPLOYEE MAS_EMPLOYEE { get; set; }
        public virtual MAS_PROVINCE MAS_PROVINCE { get; set; }
        public virtual MAS_REASON MAS_REASON { get; set; }
    }
}
