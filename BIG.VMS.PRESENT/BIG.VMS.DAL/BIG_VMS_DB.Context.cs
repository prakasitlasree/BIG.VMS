﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BIG.VMS.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using BIG.VMS.MODEL.EntityModel;
    
    public partial class BIG_VMSEntities : DbContext
    {
        public BIG_VMSEntities()
            : base("name=BIG_VMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<MAS_CAR_BRAND> MAS_CAR_BRAND { get; set; }
        public DbSet<MAS_CAR_MODEL> MAS_CAR_MODEL { get; set; }
        public DbSet<MAS_CAR_TYPE> MAS_CAR_TYPE { get; set; }
        public DbSet<MAS_DEPARTMENT> MAS_DEPARTMENT { get; set; }
        public DbSet<MAS_EMPLOYEE> MAS_EMPLOYEE { get; set; }
        public DbSet<MAS_PROVINCE> MAS_PROVINCE { get; set; }
        public DbSet<MAS_REASON> MAS_REASON { get; set; }
        public DbSet<MEMBER_LOGON> MEMBER_LOGON { get; set; }
        public DbSet<SYS_CONFIGURATION> SYS_CONFIGURATION { get; set; }
        public DbSet<TRN_APPOINTMENT> TRN_APPOINTMENT { get; set; }
        public DbSet<TRN_BLACKLIST> TRN_BLACKLIST { get; set; }
        public DbSet<TRN_ATTACHEDMENT> TRN_ATTACHEDMENT { get; set; }
        public DbSet<TRN_VISITOR> TRN_VISITOR { get; set; }
    }
}
