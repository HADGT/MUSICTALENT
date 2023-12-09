using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace MUSICTALENT.Models
{
    public class DONDAT
    {
        public string SODD { get; set; }
        public KHACHHANG KH { get; set; }
        public TTDON TT {  get; set; }
        public DateTime NGLAP {  get; set; }
        public DONDAT(string SODD, string KH, string TT, DateTime NGLAP)
        {
            this.SODD = SODD;
            this.KH.MAKH = KH;
            this.TT.MATT = TT;
            this.NGLAP = NGLAP;
        }
    }
}
