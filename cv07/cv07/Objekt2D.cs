using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv07
{
    abstract class Objekt2D : I2D, IComparable<Objekt2D>
    {
        public abstract double Plocha();
        public int CompareTo(Objekt2D? other)
        {
            if (other == null) return 1;
            return Plocha().CompareTo(other.Plocha());
        }
    }
}
