using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace MUSICTALENT.Models
{
    public class TTDON
    {
        public string MATT { get; set; }
        public string TENTT {  get; set; }

        public TTDON(string MATT, string TENTT)
        {
            this.MATT = MATT;
            this.TENTT = TENTT;
        }
    }
}
