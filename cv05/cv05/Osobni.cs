using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05
{
    public class Osobni : Auto
    {
        public int MaxOsob { get; }
        public int PrepravovaneOsoby { get; private set; }

        public Osobni(double velikostNadrze, TypPaliva palivo, int maxOsob)
            : base(velikostNadrze, palivo)
        {
            MaxOsob = maxOsob;
            PrepravovaneOsoby = 0;
        }

        public void NastavPrepravovaneOsoby(int pocet)
        {
            if (pocet > MaxOsob)
                throw new ArgumentOutOfRangeException("Překročen maximální počet osob!");

            PrepravovaneOsoby = pocet;
        }

        public override string ToString()
        {
            return base.ToString() + $", Osoby: {PrepravovaneOsoby}/{MaxOsob}";
        }
    }
}
