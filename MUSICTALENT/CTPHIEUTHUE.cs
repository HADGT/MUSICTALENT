namespace MUSICTALENT
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPHIEUTHUE")]
    public partial class CTPHIEUTHUE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string MATHUE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string MANC { get; set; }

        public int? SOLUONG { get; set; }

        [Column(TypeName = "ntext")]
        public string GHICHU { get; set; }

        public virtual PHIEUTHUE PHIEUTHUE { get; set; }

        public virtual NHACCU NHACCU { get; set; }
    }
}
