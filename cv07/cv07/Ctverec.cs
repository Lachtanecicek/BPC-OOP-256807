using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv07
{
    class Ctverec : Obdelnik
    {
        public Ctverec(double strana) : base(strana, strana) { }
        public override string ToString() => $"Ctverec: strana = {Sirka}, plocha = {Plocha():F2}";
    }
}
