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
    
    public partial class msDonatur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public msDonatur()
        {
            this.trDonasiBarangs = new HashSet<trDonasiBarang>();
            this.trDonasiUangs = new HashSet<trDonasiUang>();
        }
    
        public int id_donatur { get; set; }
        public string nama { get; set; }
        public string no_ktp { get; set; }
        public string tempat_lahir { get; set; }
        public System.DateTime tanggal_lahir { get; set; }
        public int jenis_kelamin { get; set; }
        public string alamat { get; set; }
        public int agama { get; set; }
        public string pekerjaan { get; set; }
        public int kewarganegaraan { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trDonasiBarang> trDonasiBarangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trDonasiUang> trDonasiUangs { get; set; }
    }
}
