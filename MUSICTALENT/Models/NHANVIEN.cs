using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace MUSICTALENT.Models
{
    public class NHANVIEN
    {
        public string MANV {  get; set;}
        public string HOTEN { get; set;}
        public string DCHI { get; set;}
        public string SDT { get; set;}
        public DateTime NGSINH { get; set;}
        public DateTime NGVL {  get; set;}
        public int NGNGHIPHEP {  get; set;}
        public int NGNGHIKHONGPHEP {  get; set;}
        public CHUCVU CV {  get; set;}
        public NHANVIEN(string MANV, string HOTEN, string DCHI, string SDT, DateTime NGSINH, DateTime NGVL, string MACV, int NGNGHIPHEP, int NGNGHIKHONGPHEP) 
        {
            this.MANV = MANV;
            this.HOTEN = HOTEN;
            this.DCHI = DCHI;
            this.SDT = SDT;
            this.NGSINH = NGSINH;
            this.NGVL = NGVL;
            this.CV.MACV = MACV;
            this.NGNGHIPHEP = NGNGHIPHEP;
            this.NGNGHIKHONGPHEP = NGNGHIKHONGPHEP;
        }
    }
}
