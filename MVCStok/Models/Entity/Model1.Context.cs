//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCStok.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbMvcStokEntities1 : DbContext
    {
        public dbMvcStokEntities1()
            : base("name=dbMvcStokEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Kategori> tbl_Kategori { get; set; }
        public virtual DbSet<tbl_Musteriler> tbl_Musteriler { get; set; }
        public virtual DbSet<tbl_Personeller> tbl_Personeller { get; set; }
        public virtual DbSet<tbl_Satislar> tbl_Satislar { get; set; }
        public virtual DbSet<tbl_Urunler> tbl_Urunler { get; set; }
        public virtual DbSet<tbl_Admin> tbl_Admin { get; set; }
    }
}
