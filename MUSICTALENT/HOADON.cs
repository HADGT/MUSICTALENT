namespace MUSICTALENT
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CTHOADON = new HashSet<CTHOADON>();
        }

        [Key]
        [StringLength(5)]
        public string SOHD { get; set; }

        [StringLength(5)]
        public string MAKH { get; set; }

        [StringLength(5)]
        public string MANV { get; set; }

        [StringLength(5)]
        public string MATT { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGLAP { get; set; }

        [Column(TypeName = "money")]
        public decimal? TRIGIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHOADON> CTHOADON { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual TTDON TTDON { get; set; }
    }
}
