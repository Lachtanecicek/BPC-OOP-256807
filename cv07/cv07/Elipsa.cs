using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv07
{
    class Elipsa : Objekt2D
    {
        public double A { get; }
        public double B { get; }
        public Elipsa(double a, double b) => (A, B) = (a, b);
        public override double Plocha() => Math.PI * A * B;
        public override string ToString() => $"Elipsa: a = {A}, b = {B}, plocha = {Plocha():F2}";
    }
}
