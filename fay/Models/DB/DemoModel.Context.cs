﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fay.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DemoEntities : DbContext
    {
        public DemoEntities()
            : base("name=DemoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<laporan> laporans { get; set; }
        public virtual DbSet<LOOKUPRole> LOOKUPRoles { get; set; }
        public virtual DbSet<outbond> outbonds { get; set; }
        public virtual DbSet<pelanggan> pelanggans { get; set; }
        public virtual DbSet<SYSUser> SYSUsers { get; set; }
        public virtual DbSet<SYSUserProfile> SYSUserProfiles { get; set; }
        public virtual DbSet<SYSUserRole> SYSUserRoles { get; set; }
    }
}