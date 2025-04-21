using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv11.cv11EF
{
    public class Hodnoceni
    {
        public int HodnoceniId { get; set; }
        public int StudentId { get; set; }
        public int PredmetId { get; set; }
        public double Znamka { get; set; }

        public Student Student { get; set; } = null!;
        public Predmet Predmet { get; set; } = null!;
    }
}
