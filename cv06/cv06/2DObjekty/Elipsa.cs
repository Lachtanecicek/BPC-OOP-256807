using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv06
{
    class Elipsa : Objekt2D
    {
        private double a, b;
        public Elipsa(double a, double b) { this.a = a; this.b = b; }
        public override double SpoctiPlochu() => Math.PI * a * b;
        public override void Kresli() => Console.WriteLine($"Elipsa (a = {a}, b = {b})");
    }
}
