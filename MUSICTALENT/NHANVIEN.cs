namespace MUSICTALENT
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            DANGNHAP = new HashSet<DANGNHAP>();
            HOADON = new HashSet<HOADON>();
            PHIEUNHAP = new HashSet<PHIEUNHAP>();
        }

        [Key]
        [StringLength(5)]
        public string MANV { get; set; }

        [StringLength(40)]
        public string HOTEN { get; set; }

        [StringLength(50)]
        public string DCHI { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGSINH { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGVL { get; set; }

        [StringLength(30)]
        public string CHUCVU { get; set; }

        public int? NGNGHIPHEP { get; set; }

        public int? NGNGHIKHONGPHEP { get; set; }

        [Column(TypeName = "money")]
        public decimal? LUONG { get; set; }

        [Column(TypeName = "money")]
        public decimal? THUONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANGNHAP> DANGNHAP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAP> PHIEUNHAP { get; set; }
    }
}
