using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv07
{
    static class Extremy
    {
        public static T Nejvetsi<T>(T[] pole) where T : IComparable<T>
        {
            return pole.Max();
        }

        public static T Nejmensi<T>(T[] pole) where T : IComparable<T>
        {
            return pole.Min();
        }
    }
}
