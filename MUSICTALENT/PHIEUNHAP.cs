namespace MUSICTALENT
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUNHAP")]
    public partial class PHIEUNHAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUNHAP()
        {
            CTPHIEUNHAP = new HashSet<CTPHIEUNHAP>();
        }

        [Key]
        [StringLength(5)]
        public string MANHAP { get; set; }

        [StringLength(5)]
        public string MANV { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGLAP { get; set; }

        [StringLength(5)]
        public string MATT { get; set; }

        [Column(TypeName = "money")]
        public decimal? DONGIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUNHAP> CTPHIEUNHAP { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual TTDON TTDON { get; set; }
    }
}
