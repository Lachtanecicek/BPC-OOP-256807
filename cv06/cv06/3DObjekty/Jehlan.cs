using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv06
{
    class Jehlan : Objekt3D
    {
        private double a, v;
        public Jehlan(double a, double v) { this.a = a; this.v = v; }
        public override double SpoctiPovrch() => a * a + 2 * a * Math.Sqrt((a / 2) * (a / 2) + v * v);
        public override double SpoctiObjem() => (a * a * v) / 3;
        public override void Kresli() => Console.WriteLine($"Jehlan (a = {a}, v = {v})");
    }
}
