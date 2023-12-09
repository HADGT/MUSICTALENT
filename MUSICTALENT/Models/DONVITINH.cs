using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace MUSICTALENT.Models
{
    public class DONVITINH
    {
        public string MADVT { get; set; }
        public string TENDVT { get; set; }
        public DONVITINH(string MADVT, string TENDVT)
        {
            this.MADVT = MADVT;
            this.TENDVT = TENDVT;
        }
    }
}
