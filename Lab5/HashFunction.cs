using System;
using System.Text;

namespace Lab5
{
    internal static class HashFunction
    {
        public static int Hash(string value)
        {
            int p_pow = 1;
            const int p = 31;

            long h = 0L;

            foreach (var s in value)
            {
                h += (s - 'a' + 1) * p_pow;
                p_pow *= p;
            }

            return (int) Math.Abs(h % CountElements);
        }

        public static int CountElements { get; set; }
    }
}
