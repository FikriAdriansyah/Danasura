﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Danasura_Project.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class danasuraEntities : DbContext
    {
        public danasuraEntities()
            : base("name=danasuraEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<dtNISNKJP> dtNISNKJPs { get; set; }
        public virtual DbSet<msBank> msBanks { get; set; }
        public virtual DbSet<msBarang> msBarangs { get; set; }
        public virtual DbSet<msDonatur> msDonaturs { get; set; }
        public virtual DbSet<msKategoriBarang> msKategoriBarangs { get; set; }
        public virtual DbSet<msProvider> msProviders { get; set; }
        public virtual DbSet<msSekolah> msSekolahs { get; set; }
        public virtual DbSet<msSiswa> msSiswas { get; set; }
        public virtual DbSet<msStaff> msStaffs { get; set; }
        public virtual DbSet<trDonasiBarang> trDonasiBarangs { get; set; }
        public virtual DbSet<trDonasiUang> trDonasiUangs { get; set; }
        public virtual DbSet<trPencairanKuota> trPencairanKuotas { get; set; }
        public virtual DbSet<trPengajuanSeragam> trPengajuanSeragams { get; set; }
        public virtual DbSet<trPengajuanSPP> trPengajuanSPPs { get; set; }
        public virtual DbSet<trPermintaanBarang> trPermintaanBarangs { get; set; }
    }
}
