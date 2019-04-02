using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phosh
{
    public class check
    {
        public static int Addition(int firstDel, int secDel)
        {
            return firstDel + secDel;
        }

        public static bool Equality(int firstDel, int secDel)
        {
            if (firstDel > secDel)
                return true;
            else
                return false;
        }

        public static string Concatation(string width, string height)
        {
            return width + " " + height;
        }
    }
}
