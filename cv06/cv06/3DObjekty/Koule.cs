using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv06
{
    class Koule : Objekt3D
    {
        private double r;
        public Koule(double r) { this.r = r; }
        public override double SpoctiPovrch() => 4 * Math.PI * r * r;
        public override double SpoctiObjem() => 4.0 / 3.0 * Math.PI * Math.Pow(r, 3);
        public override void Kresli() => Console.WriteLine($"Koule (r = {r})");
    }

}
