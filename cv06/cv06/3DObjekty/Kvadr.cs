using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv06
{
    class Kvadr : Objekt3D
    {
        private double a, b, c;
        public Kvadr(double a, double b, double c) { this.a = a; this.b = b; this.c = c; }
        public override double SpoctiPovrch() => 2 * (a * b + b * c + a * c);
        public override double SpoctiObjem() => a * b * c;
        public override void Kresli() => Console.WriteLine($"Kvadr (a = {a}, b = {b}, c = {c})");
    }
}
