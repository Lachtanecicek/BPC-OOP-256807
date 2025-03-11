using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05
{
    public class Nakladni : Auto
    {
        public double MaxNaklad { get; }
        public double PrepravovanyNaklad { get; private set; }

        public Nakladni(double velikostNadrze, TypPaliva palivo, double maxNaklad)
            : base(velikostNadrze, palivo)
        {
            MaxNaklad = maxNaklad;
            PrepravovanyNaklad = 0;
        }

        public void NastavPrepravovanyNaklad(double naklad)
        {
            if (naklad > MaxNaklad)
                throw new ArgumentOutOfRangeException("Překročen maximální náklad!");

            PrepravovanyNaklad = naklad;
        }

        public override string ToString()
        {
            return base.ToString() + $", Náklad: {PrepravovanyNaklad}/{MaxNaklad} kg";
        }
    }
}
