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
    using System.Collections.Generic;
    
    public partial class tbl_Satislar
    {
        public int id { get; set; }
        public Nullable<int> urun { get; set; }
        public Nullable<int> personel { get; set; }
        public Nullable<int> musteri { get; set; }
        public Nullable<decimal> fiyat { get; set; }
        public Nullable<System.DateTime> tarih { get; set; }
    
        public virtual tbl_Musteriler tbl_Musteriler { get; set; }
        public virtual tbl_Personeller tbl_Personeller { get; set; }
        public virtual tbl_Urunler tbl_Urunler { get; set; }
    }
}
