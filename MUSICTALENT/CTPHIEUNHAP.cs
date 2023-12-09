namespace MUSICTALENT
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPHIEUNHAP")]
    public partial class CTPHIEUNHAP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string MANHAP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string MANC { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string MANCC { get; set; }

        public int? SOLUONG { get; set; }

        [Column(TypeName = "money")]
        public decimal? THANHTIEN { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        public virtual PHIEUNHAP PHIEUNHAP { get; set; }

        public virtual NHACCU NHACCU { get; set; }
    }
}
