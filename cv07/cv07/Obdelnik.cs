using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv07
{
    class Obdelnik : Objekt2D
    {
        public double Sirka { get; }
        public double Vyska { get; }
        public Obdelnik(double sirka, double vyska) => (Sirka, Vyska) = (sirka, vyska);
        public override double Plocha() => Sirka * Vyska;
        public override string ToString() => $"Obdelnik: {Sirka}x{Vyska}, plocha = {Plocha():F2}";
    }
}
