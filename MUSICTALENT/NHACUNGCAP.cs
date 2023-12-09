namespace MUSICTALENT
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHACUNGCAP")]
    public partial class NHACUNGCAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHACUNGCAP()
        {
            CTPHIEUNHAP = new HashSet<CTPHIEUNHAP>();
        }

        [Key]
        [StringLength(5)]
        public string MANCC { get; set; }

        [StringLength(40)]
        public string TENNCC { get; set; }

        [StringLength(50)]
        public string DCHI { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        [Column(TypeName = "ntext")]
        public string GHICHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUNHAP> CTPHIEUNHAP { get; set; }
    }
}
