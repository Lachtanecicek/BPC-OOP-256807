using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cv10_databaze.Models
{
    public class Zapsani
    {
        public int ID_Studenta { get; set; }
        public Student Student { get; set; }

        public string Zkratka_Predmetu { get; set; }
        public Predmet Predmet { get; set; }
    }
}
