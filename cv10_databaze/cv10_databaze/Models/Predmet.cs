using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cv10_databaze.Models
{
    public class Predmet
    {
        [Key]
        [MaxLength(10)]
        public string Zkratka { get; set; }

        [Required]
        public string Nazev { get; set; }

        public ICollection<Zapsani> Zapsani { get; set; }
        public ICollection<Hodnoceni> Hodnoceni { get; set; }
    }
}
