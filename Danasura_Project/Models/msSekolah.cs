//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class msSekolah
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public msSekolah()
        {
            this.msSiswas = new HashSet<msSiswa>();
        }
    
        public int id_sekolah { get; set; }
        public string nama_sekolah { get; set; }
        public int akreditasi { get; set; }
        public string nama_cp { get; set; }
        public string no_cp { get; set; }
        public string alamat_sekolah { get; set; }
        public string provinsi { get; set; }
        public string kota { get; set; }
        public string kecamatan { get; set; }
        public Nullable<int> jml_penerimaKIP { get; set; }
        public decimal harga_spp { get; set; }
        public decimal harga_seragam { get; set; }
        public string deskripsi { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<msSiswa> msSiswas { get; set; }
    }
}
