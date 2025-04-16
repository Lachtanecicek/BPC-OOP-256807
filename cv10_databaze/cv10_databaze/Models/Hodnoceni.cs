using System;
using System.ComponentModel.DataAnnotations;

namespace cv10_databaze.Models
{
    public class Hodnoceni
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int ID_Studenta { get; set; }
        public Student Student { get; set; }

        [Required]
        public string Zkratka_Predmetu { get; set; }
        public Predmet Predmet { get; set; }

        [Required]
        public DateTime Datum_Hodnoceni { get; set; }

        [Required]
        public int Znamka { get; set; }
    }
}
