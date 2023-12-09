namespace MUSICTALENT
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONDAT")]
    public partial class DONDAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONDAT()
        {
            CTDONDAT = new HashSet<CTDONDAT>();
        }

        [Key]
        [StringLength(5)]
        public string SODD { get; set; }

        [StringLength(5)]
        public string MAKH { get; set; }

        [StringLength(5)]
        public string MATT { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGLAP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONDAT> CTDONDAT { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual TTDON TTDON { get; set; }
    }
}
