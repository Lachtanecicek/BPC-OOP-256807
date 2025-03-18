using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv06
{
    class Kruh : Objekt2D
    {
        private double r;
        public Kruh(double r) { this.r = r; }
        public override double SpoctiPlochu() => Math.PI * r * r;
        public override void Kresli() => Console.WriteLine($"Kruh (r = {r})");
    }
}
