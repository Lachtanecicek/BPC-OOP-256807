using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv06
{
    class Trojuhelnik : Objekt2D
    {
        private double a, v;
        public Trojuhelnik(double a, double v) { this.a = a; this.v = v; }
        public override double SpoctiPlochu() => (a * v) / 2;
        public override void Kresli() => Console.WriteLine($"Trojúhelník (a = {a}, v = {v})");
    }
}
