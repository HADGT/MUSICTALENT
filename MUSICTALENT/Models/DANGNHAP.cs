using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace MUSICTALENT.Models
{
    public class DANGNHAP
    {
        public NHANVIEN NV {  get; set; }
        public string ACCOUNT { get; set; }
        public string PASSWORK { get; set; }
        public string QUYENTRUYCAP { get; set; }

        public DANGNHAP(string MANV, string ACCOUNT, string PASSWORK, string QUYENTRUYCAP)
        {
            this.NV.MANV = MANV;
            this.ACCOUNT = ACCOUNT;
            this.PASSWORK = PASSWORK;
            this.QUYENTRUYCAP = QUYENTRUYCAP;
        }
    }
}
