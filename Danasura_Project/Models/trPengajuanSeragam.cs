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
    
    public partial class trPengajuanSeragam
    {
        public int id_trans { get; set; }
        public System.DateTime tgl_trans { get; set; }
        public int id_siswa { get; set; }
        public Nullable<int> id_staff { get; set; }
        public int ukuran { get; set; }
        public string keterangan { get; set; }
        public decimal total_biaya { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    
        public virtual msSiswa msSiswa { get; set; }
        public virtual msStaff msStaff { get; set; }
    }
}
