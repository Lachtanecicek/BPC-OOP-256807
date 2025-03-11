using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05
{
    public class Autoradio
    {
        private Dictionary<int, double> predvolby = new();
        public double NaladenyKmitocet { get; private set; }
        public bool RadioZapnuto { get; private set; }

        public void NastavPredvolbu(int cislo, double kmitocet)
        {
            predvolby[cislo] = kmitocet;
        }

        public void PreladNaPredvolbu(int cislo)
        {
            if (predvolby.TryGetValue(cislo, out double kmitocet))
                NaladenyKmitocet = kmitocet;
            else
                throw new KeyNotFoundException("Neexistující předvolba!");
        }

        public void ZapniRadio(bool zapnuto)
        {
            if(zapnuto == true)
            {
                RadioZapnuto = true;
            }
        }

        public override string ToString()
        {
            return $"Radio {(RadioZapnuto ? "zapnuto" : "vypnuto")}, frekvence: {NaladenyKmitocet} MHz";
        }
    }
}
