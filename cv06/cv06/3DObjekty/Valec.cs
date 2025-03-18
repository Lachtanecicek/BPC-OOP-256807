using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv06
{
    class Valec : Objekt3D
    {
        private double r, v;
        public Valec(double r, double v) { this.r = r; this.v = v; }
        public override double SpoctiPovrch() => 2 * Math.PI * r * (r + v);
        public override double SpoctiObjem() => Math.PI * r * r * v;
        public override void Kresli() => Console.WriteLine($"Válec (r = {r}, v = {v})");
    }
}
