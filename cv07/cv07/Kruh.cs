using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv07
{
    class Kruh : Objekt2D
    {
        public double Polomer { get; }
        public Kruh(double polomer) => Polomer = polomer;
        public override double Plocha() => Math.PI * Polomer * Polomer;
        public override string ToString() => $"Kruh: r = {Polomer}, plocha = {Plocha():F2}";
    }
}
