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
    
    public partial class MAS_EMPLOYEE
    {
        public MAS_EMPLOYEE()
        {
            this.TRN_VISITOR = new HashSet<TRN_VISITOR>();
        }
    
        public int AUTO_ID { get; set; }
        public Nullable<int> DEPARTMENT_ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
    
        public virtual MAS_DEPARTMENT MAS_DEPARTMENT { get; set; }
        public virtual TRN_APPOINTMENT TRN_APPOINTMENT { get; set; }
        public virtual ICollection<TRN_VISITOR> TRN_VISITOR { get; set; }
    }
}
