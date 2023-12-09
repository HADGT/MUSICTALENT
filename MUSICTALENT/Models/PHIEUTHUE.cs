using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using Org.BouncyCastle.Asn1.Cms;

namespace MUSICTALENT.Models
{
    public class PHIEUTHUE
    {
        public string MATHUE { get; set; }
        public KHACHHANG KH {  get; set; }
        public TTDON TT {  get; set; }
        public DateTime NGLAP {  get; set; }
        public Time GIOMUON {  get; set; }
        public Time GIOTRA {  get; set; }
        public float THANHTIEN {  get; set; }
        public PHIEUTHUE (string MATHUE, string MAKH, string MATTDON, DateTime NGLAP, Time GIOMUON, Time GIOTRA, float THANHTIEN)
        {
            this.MATHUE = MATHUE;
            this.KH.MAKH = MAKH;
            this.TT.MATT = MATTDON;
            this.NGLAP = NGLAP;
            this.GIOMUON = GIOMUON;
            this.GIOTRA = GIOTRA;
            this.THANHTIEN = THANHTIEN;
        }
    }
}
