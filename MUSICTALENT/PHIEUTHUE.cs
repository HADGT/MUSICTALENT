namespace MUSICTALENT
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUTHUE")]
    public partial class PHIEUTHUE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUTHUE()
        {
            CTPHIEUTHUE = new HashSet<CTPHIEUTHUE>();
        }

        [Key]
        [StringLength(5)]
        public string MATHUE { get; set; }

        [StringLength(5)]
        public string MAKH { get; set; }

        [StringLength(5)]
        public string MATT { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGLAP { get; set; }

        public TimeSpan? GIOMUON { get; set; }

        public TimeSpan? GIOTRA { get; set; }

        [Column(TypeName = "money")]
        public decimal? THANHTIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUTHUE> CTPHIEUTHUE { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual TTDON TTDON { get; set; }
    }
}
