using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace MUSICTALENT.Models
{
    public class CTPHIEUTHUE
    {
        public PHIEUTHUE PT {  get; set; }
        public NHACCU NC {  get; set; }
        public int SOLUONG {  get; set; }
        public string GHICHU {  get; set; }
        public CTPHIEUTHUE (string MAPT, string MANC, int SOLUONG, string GHICHU)
        {
            this.PT.MATHUE = MAPT;
            this.NC.MANC = MANC;
            this.SOLUONG = SOLUONG;
            this.GHICHU = GHICHU;
        }
    }
}
