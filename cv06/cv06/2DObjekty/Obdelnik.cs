using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv06
{
    class Obdelnik : Objekt2D
    {
        private double a, b;
        public Obdelnik(double a, double b) { this.a = a; this.b = b; }
        public override double SpoctiPlochu() => a * b;
        public override void Kresli() => Console.WriteLine($"Obdelnik (a = {a}, b = {b})");
    }
}
