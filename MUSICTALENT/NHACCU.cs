namespace MUSICTALENT
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHACCU")]
    public partial class NHACCU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHACCU()
        {
            CTDONDAT = new HashSet<CTDONDAT>();
            CTHOADON = new HashSet<CTHOADON>();
            CTPHIEUNHAP = new HashSet<CTPHIEUNHAP>();
            CTPHIEUTHUE = new HashSet<CTPHIEUTHUE>();
        }

        [Key]
        [StringLength(5)]
        public string MANC { get; set; }

        [StringLength(40)]
        public string TENNC { get; set; }

        public int? SOLUONG { get; set; }

        [StringLength(5)]
        public string MADVT { get; set; }

        [Column(TypeName = "ntext")]
        public string GHICHU { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONDAT> CTDONDAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHOADON> CTHOADON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUNHAP> CTPHIEUNHAP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUTHUE> CTPHIEUTHUE { get; set; }

        public virtual DONVITINH DONVITINH { get; set; }
    }
}
