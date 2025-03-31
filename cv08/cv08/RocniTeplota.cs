using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv08
{
    class RocniTeplota
    {
        public int Rok { get; set; }
        public List<double> MesicniTeploty { get; set; }

        public RocniTeplota(int rok, List<double> mesicniTeploty)
        {
            Rok = rok;
            MesicniTeploty = mesicniTeploty;
        }

        public double MaxTeplota => MesicniTeploty.Max();
        public double MinTeplota => MesicniTeploty.Min();
        public double PrumRocniTeplota => MesicniTeploty.Average();
    }
}
