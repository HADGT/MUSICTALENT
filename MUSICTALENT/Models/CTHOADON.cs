using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace MUSICTALENT.Models
{
    internal class CTHOADON
    {
        public HOADON HD { get; set; }
        public KHACHHANG KH {  get; set; }
        public TTDON TT {  get; set; }
        public DateTime NGLAP;
        public CTHOADON(string SOHD, string MAKH, string MATT, DateTime nGLAP)
        {
            HD.SOHD = SOHD;
            KH.MAKH = MAKH;
            TT.MATT = MATT;
            NGLAP = nGLAP;
        }
    }
}
