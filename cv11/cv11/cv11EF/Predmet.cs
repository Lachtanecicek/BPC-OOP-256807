using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv11.cv11EF
{
    public class Predmet
    {
        public int PredmetId { get; set; }
        public string Nazev { get; set; } = string.Empty;

        public ICollection<Student> Studenti { get; set; } = new List<Student>();
        public ICollection<Hodnoceni> Hodnoceni { get; set; } = new List<Hodnoceni>();
    }
}
