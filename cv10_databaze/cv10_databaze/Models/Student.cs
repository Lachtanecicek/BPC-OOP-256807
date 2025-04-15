using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cv10_databaze.Models
{
    public class Student
    {
        [Key]
        public int ID_Studenta { get; set; }

        [Required]
        public string Jmeno { get; set; }

        [Required]
        public string Prijmeni { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Datum_Narozeni { get; set; }

        public ICollection<Zapsani> Zapsani { get; set; }
        public ICollection<Hodnoceni> Hodnoceni { get; set; }
    }
}
