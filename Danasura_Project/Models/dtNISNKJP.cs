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
    
    public partial class dtNISNKJP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dtNISNKJP()
        {
            this.msSiswas = new HashSet<msSiswa>();
        }
    
        public string nisn { get; set; }
        public string no_kip { get; set; }
        public string nama_siswa { get; set; }
        public int jenjang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<msSiswa> msSiswas { get; set; }
    }
}
