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
    
    public partial class TRN_ATTACHEDMENT
    {
        public int AUTO_ID { get; set; }
        public Nullable<int> VISITOR_ID { get; set; }
        public byte[] ID_CARD_PHOTO { get; set; }
        public byte[] CONTACT_PHOTO { get; set; }
        public string PHOTO_URL { get; set; }
    
        public virtual TRN_VISITOR TRN_VISITOR { get; set; }
    }
}
