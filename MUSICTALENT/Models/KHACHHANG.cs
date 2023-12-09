using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace MUSICTALENT.Models
{
    public class KHACHHANG
    {
        public string MAKH { get; set; }
        public string HOTEN { get; set; }
        public string DCHI { get; set; }
        public string SDT { get; set; }
        public DateTime NGSINH { get; set; }
        public DateTime NGDKY {  get; set; }
        public float DOANHSO { get; set;}
        public KHACHHANG(string MAKH, string HOTEN, string DCHI, string SDT, DateTime NGSINH, DateTime NGDKY, float DOANHSO)
        {
            this.MAKH = MAKH;
            this.HOTEN = HOTEN;
            this.DCHI = DCHI;
            this.SDT = SDT;
            this.NGSINH = NGSINH;
            this.NGDKY = NGDKY;
            this.DOANHSO = DOANHSO;
        }
    }
}
