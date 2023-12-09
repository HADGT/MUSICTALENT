using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace MUSICTALENT.Models
{
    public class HOADON
    {
        public string SOHD { get; set; }
        public KHACHHANG KH { get; set; }
        public NHANVIEN NV {  get; set; }
        public TTDON TT {  get; set; }
        public DateTime NGLAP { get; set; }
        public float TRIGIA { get; set; }

        public HOADON(string sOHD, string MAKH, string MANV, string MATT, DateTime nGLAP, float tRIGIA)
        {
            SOHD = sOHD;
            KH.MAKH = MAKH;
            NV.MANV = MANV;
            TT.MATT = MATT;
            NGLAP = nGLAP;
            TRIGIA = tRIGIA;
        }
    }
}
