using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05
{
    public abstract class Auto
    {
        public enum TypPaliva { Benzin, Nafta }

        public double VelikostNadrze { get; }
        public double StavNadrze { get; private set; }
        public TypPaliva Palivo { get; }
        public Autoradio Radio { get; }

        protected Auto(double velikostNadrze, TypPaliva palivo)
        {
            VelikostNadrze = velikostNadrze;
            Palivo = palivo;
            StavNadrze = 0;
            Radio = new Autoradio();
        }

        public void Natankuj(TypPaliva typPaliva, double mnozstvi)
        {
            if (typPaliva != Palivo)
                throw new ArgumentException("Chybné palivo!");
            if (StavNadrze + mnozstvi > VelikostNadrze)
                throw new InvalidOperationException("Nádrž přeteče!");

            StavNadrze += mnozstvi;
        }

        public override string ToString()
        {
            return $"Stav nádrže: {StavNadrze}/{VelikostNadrze} l, Palivo: {Palivo}";
        }
    }
}
