using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace MUSICTALENT.Models
{
    public class CTDONDAT
    {
        public DONDAT DD { get; set; }
        public NHACCU NC { get; set; }
        public DONVITINH DVT { get; set; }
        public int SOLUONG;

        public CTDONDAT(string SODD, string MANC, string MADVT, int SOLUONG)
        {
            this.DD.SODD = SODD;
            this.NC.MANC = MANC;
            this.DVT.MADVT = MADVT;
            this.SOLUONG = SOLUONG;
        }

    }
}
