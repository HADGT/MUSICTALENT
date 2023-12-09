namespace MUSICTALENT
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            DONDAT = new HashSet<DONDAT>();
            HOADON = new HashSet<HOADON>();
            PHIEUTHUE = new HashSet<PHIEUTHUE>();
        }

        [Key]
        [StringLength(5)]
        public string MAKH { get; set; }

        [StringLength(40)]
        public string HOTEN { get; set; }

        [StringLength(50)]
        public string DCHI { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGSINH { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGDKY { get; set; }

        [Column(TypeName = "money")]
        public decimal? DOANHSO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONDAT> DONDAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTHUE> PHIEUTHUE { get; set; }
    }
}
