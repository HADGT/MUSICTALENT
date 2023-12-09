using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace MUSICTALENT.Models
{
    public class PHIEUNHAP
    {
        public string MANHAP { get; set; }
        public NHANVIEN NV { get; set; }
        public DateTime NGAYLAP {  get; set; }
        public TTDON TT { get; set; }
        public float DONGIA {  get; set; }
        public PHIEUNHAP(string MANHAP, string MANV, DateTime NGAYLAP, string MATT, float DONGIA)
        {
            this.MANHAP = MANHAP;
            this.NV.MANV = MANV;
            this.NGAYLAP = NGAYLAP;
            this.TT.MATT = MATT;
            this.DONGIA = DONGIA;
        }
    }
}
