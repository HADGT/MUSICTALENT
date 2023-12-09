namespace MUSICTALENT
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHOADON")]
    public partial class CTHOADON
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string SOHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string MANC { get; set; }

        [StringLength(5)]
        public string MADVT { get; set; }

        public int? SOLUONG { get; set; }

        [Column(TypeName = "money")]
        public decimal? THANHTIEN { get; set; }

        public virtual DONVITINH DONVITINH { get; set; }

        public virtual NHACCU NHACCU { get; set; }

        public virtual HOADON HOADON { get; set; }
    }
}
