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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class msProvider
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public msProvider()
        {
            this.trPencairanKuotas = new HashSet<trPencairanKuota>();
        }
    
        public int id_provider { get; set; }


        [DisplayName("Nama Provider")]
        //[Required(ErrorMessage = "Nama Provider harus diisi.")]
        //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Hanya menerima inputan huruf")]
        public string nama_provider { get; set; }


        [DisplayName("Jenis Jenjang")]
        public string jenis_provider { get; set; }


        [DisplayName("Harga Kuota")]
        //[Required(ErrorMessage = "Harga Kuota harus diisi.")]
        public decimal harga { get; set; }


        [DisplayName("Deskripsi")]
        [DataType(DataType.MultilineText)]
        //[Required(ErrorMessage = "Deskripsi harus diisi.")]
        public string deskripsi { get; set; }

        public Nullable<int> status { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trPencairanKuota> trPencairanKuotas { get; set; }
    }
}
