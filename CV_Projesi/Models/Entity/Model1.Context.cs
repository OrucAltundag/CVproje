﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CV_Proje.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbCVEntities : DbContext
    {
        public dbCVEntities()
            : base("name=dbCVEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_ADMIN> TBL_ADMIN { get; set; }
        public virtual DbSet<TBL_DENEYIMLERIM> TBL_DENEYIMLERIM { get; set; }
        public virtual DbSet<TBL_EGITIMLERIM> TBL_EGITIMLERIM { get; set; }
        public virtual DbSet<TBL_HAKKINDA> TBL_HAKKINDA { get; set; }
        public virtual DbSet<TBL_HOBILERIM> TBL_HOBILERIM { get; set; }
        public virtual DbSet<TBL_ILETISIM> TBL_ILETISIM { get; set; }
        public virtual DbSet<TBL_SERTIFIKALARIM> TBL_SERTIFIKALARIM { get; set; }
        public virtual DbSet<TBL_YETENEKLER> TBL_YETENEKLER { get; set; }
        public virtual DbSet<TBL_SOSYALMEDYA> TBL_SOSYALMEDYA { get; set; }
    }
}
