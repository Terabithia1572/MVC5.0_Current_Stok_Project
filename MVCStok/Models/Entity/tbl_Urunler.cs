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
    
    public partial class tbl_Urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Urunler()
        {
            this.tbl_Satislar = new HashSet<tbl_Satislar>();
        }
    
        public int id { get; set; }
        public string ad { get; set; }
        public string marka { get; set; }
        public Nullable<short> stok { get; set; }
        public Nullable<decimal> alisFiyat { get; set; }
        public Nullable<decimal> satisFiyat { get; set; }
        public Nullable<int> kategori { get; set; }
        public Nullable<bool> durum { get; set; }
    
        public virtual tbl_Kategori tbl_Kategori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Satislar> tbl_Satislar { get; set; }
    }
}
