using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSICTALENT.Models
{
    public class CHUCVU
    {
        public string MACV {  get; set; }
        public string TENCV { get; set;}
        public int LUONGCB {  get; set;}
        public CHUCVU (string MACV, string TENCV, int LUONGCB)
        {
            this.MACV = MACV;
            this.TENCV = TENCV;
            this.LUONGCB = LUONGCB;
        }
    }
}
