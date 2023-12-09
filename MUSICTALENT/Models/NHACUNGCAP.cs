using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace MUSICTALENT.Models
{
    public class NHACUNGCAP
    {
        public string MANCC {  get; set; }
        public string TENNCC { get; set; }
        public string DCHI {  get; set; }
        public string SDT {  get; set; }
        public string GHICHU {  get; set; }
        public NHACUNGCAP(string MANCC, string TENNCC, string DCHI, string SDT, string GHICHU)
        {
            this.MANCC = MANCC;
            this.TENNCC = TENNCC;
            this.DCHI = DCHI;
            this.SDT = SDT;
            this.GHICHU = GHICHU;
        }
    }
}
