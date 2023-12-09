using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSICTALENT.Utils
{
    public class Utility
    {
        public static int readInt()
        {
            int value;
            while (true)
            {
                try
                {
                    value = int.Parse(Console.ReadLine());
                    return value;
                }catch (Exception)
                {
                    Console.WriteLine("Nhap lai!");
                }
            }
        }
    }
}
