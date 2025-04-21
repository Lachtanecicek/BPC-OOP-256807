using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv11.cv11EF
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Jmeno { get; set; } = string.Empty;

        public ICollection<Predmet> Predmety { get; set; } = new List<Predmet>();
        public ICollection<Hodnoceni> Hodnoceni { get; set; } = new List<Hodnoceni>();
    }
}
