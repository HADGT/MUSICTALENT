using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace MUSICTALENT.Models
{
    public class CTPHIEUNHAP
    {
        public PHIEUNHAP PN {  get; set; }
        public NHACCU NC {  get; set; }
        public NHACUNGCAP NCC {  get; set; }
        public int SOLUONG {  get; set; }
        public float THANHTIEN {  get; set; }
        public CTPHIEUNHAP(string MANHAP, string MANC, string MANCC, int SOLUONG, float THANHTIEN)
        {
            this.PN.MANHAP = MANHAP;
            this.NC.MANC = MANC;
            this.NCC.MANCC = MANCC;
            this.SOLUONG = SOLUONG;
            this.THANHTIEN = THANHTIEN;
        }
    }
}
