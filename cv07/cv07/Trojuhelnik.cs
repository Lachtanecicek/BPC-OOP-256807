using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv07
{
    class Trojuhelnik : Objekt2D
    {
        public double Zakladna { get; }
        public double Vyska { get; }
        public Trojuhelnik(double zakladna, double vyska) => (Zakladna, Vyska) = (zakladna, vyska);
        public override double Plocha() => (Zakladna * Vyska) / 2;
        public override string ToString() => $"Trojuhelnik: zakladna = {Zakladna}, vyska = {Vyska}, plocha = {Plocha():F2}";
    }
}
