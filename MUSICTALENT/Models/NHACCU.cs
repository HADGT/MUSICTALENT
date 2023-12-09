using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace MUSICTALENT.Models
{
    public class NHACCU
    {
        public string MANC {  get; set; }
        public string TENNC { get; set; }
        public int SOLUONG {  get; set; }
        public DONVITINH DVT {  get; set; }
        public string GHICHU {  get; set; }
        public float GIA { get; set; }
        public NHACCU(string MANC, string TENNC, int SOLUONG, string DVT, string GHICHU, float GIA)
        {
            this.MANC = MANC;
            this.TENNC = TENNC;
            this.SOLUONG = SOLUONG;
            this.DVT.MADVT = DVT;
            this.GHICHU = GHICHU;
            this.GIA = GIA;
        }
    }
}
