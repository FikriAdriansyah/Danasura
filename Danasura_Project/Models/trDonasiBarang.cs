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
    
    public partial class trDonasiBarang
    {
        public int id_trans { get; set; }
        public System.DateTime tgl_trans { get; set; }
        public string nama_barang { get; set; }
        public int id_donatur { get; set; }
        public int id_kategori { get; set; }
        public int kondisi { get; set; }
        public string keterangan { get; set; }
        public int status { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
        public string foto_barang { get; set; }
        public Nullable<int> kuantitas { get; set; }
    
        public virtual msDonatur msDonatur { get; set; }
        public virtual msKategoriBarang msKategoriBarang { get; set; }
    }
}
