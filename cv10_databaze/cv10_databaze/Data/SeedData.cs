using cv10_databaze.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace cv10_databaze.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new VyukaContext(
                serviceProvider.GetRequiredService<DbContextOptions<VyukaContext>>());

            if (context.Studenti.Any()) return;

            var s1 = new Student { ID_Studenta = 1, Jmeno = "Jan", Prijmeni = "Rybička", Datum_Narozeni = new DateTime(2000, 5, 15) };
            var s2 = new Student { ID_Studenta = 2, Jmeno = "Petra", Prijmeni = "Psíková", Datum_Narozeni = new DateTime(1999, 11, 23) };
            var s3 = new Student { ID_Studenta = 3, Jmeno = "Lukáš", Prijmeni = "Zajíc", Datum_Narozeni = new DateTime(2001, 1, 30) };
            var s4 = new Student { ID_Studenta = 4, Jmeno = "Eva", Prijmeni = "Jeřábová", Datum_Narozeni = new DateTime(2002, 8, 9) };
            var s5 = new Student { ID_Studenta = 5, Jmeno = "Tomáš", Prijmeni = "Kanec", Datum_Narozeni = new DateTime(2000, 10, 12) };
            var s6 = new Student { ID_Studenta = 6, Jmeno = "Anna", Prijmeni = "Vrabcová", Datum_Narozeni = new DateTime(1998, 3, 8) };
            var s7 = new Student { ID_Studenta = 7, Jmeno = "Marek", Prijmeni = "Kolibřík", Datum_Narozeni = new DateTime(2001, 7, 25) };
            var s8 = new Student { ID_Studenta = 8, Jmeno = "Zuzana", Prijmeni = "Medvědová", Datum_Narozeni = new DateTime(1999, 12, 15) };
            var s9 = new Student { ID_Studenta = 9, Jmeno = "Filip", Prijmeni = "Hroch", Datum_Narozeni = new DateTime(2000, 6, 2) };
            var s10 = new Student { ID_Studenta = 10, Jmeno = "Eliška", Prijmeni = "Myslivečková", Datum_Narozeni = new DateTime(2002, 4, 20) };
            var s11 = new Student { ID_Studenta = 11, Jmeno = "Jakub", Prijmeni = "Holub", Datum_Narozeni = new DateTime(2001, 9, 14) };
            
            var p1 = new Predmet { Zkratka = "MAT", Nazev = "Matematika" };
            var p2 = new Predmet { Zkratka = "FYZ", Nazev = "Fyzika" };
            var p3 = new Predmet { Zkratka = "STE", Nazev = "Studiová technika" };
            var p4 = new Predmet { Zkratka = "ANA", Nazev = "Analogová technika" };
            var p5 = new Predmet { Zkratka = "OOP", Nazev = "Objektově orientované programování" };

            context.Studenti.AddRange(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11);
            context.Predmety.AddRange(p1, p2, p3, p4, p5);

            context.Zapsani.AddRange(
                new Zapsani { ID_Studenta = 1, Zkratka_Predmetu = "MAT" },
                new Zapsani { ID_Studenta = 1, Zkratka_Predmetu = "STE" },
                new Zapsani { ID_Studenta = 2, Zkratka_Predmetu = "FYZ" },
                new Zapsani { ID_Studenta = 3, Zkratka_Predmetu = "STE" },
                new Zapsani { ID_Studenta = 4, Zkratka_Predmetu = "MAT" },
                new Zapsani { ID_Studenta = 4, Zkratka_Predmetu = "STE" },
                new Zapsani { ID_Studenta = 5, Zkratka_Predmetu = "ANA" },
                new Zapsani { ID_Studenta = 6, Zkratka_Predmetu = "ANA" },
                new Zapsani { ID_Studenta = 6, Zkratka_Predmetu = "MAT" },
                new Zapsani { ID_Studenta = 6, Zkratka_Predmetu = "OOP" },
                new Zapsani { ID_Studenta = 7, Zkratka_Predmetu = "OOP" },
                new Zapsani { ID_Studenta = 8, Zkratka_Predmetu = "STE" },
                new Zapsani { ID_Studenta = 8, Zkratka_Predmetu = "MAT" },
                new Zapsani { ID_Studenta = 9, Zkratka_Predmetu = "FYZ" },
                new Zapsani { ID_Studenta = 10, Zkratka_Predmetu = "MAT" },
                new Zapsani { ID_Studenta = 10, Zkratka_Predmetu = "ANA" },
                new Zapsani { ID_Studenta = 10, Zkratka_Predmetu = "OOP" },
                new Zapsani { ID_Studenta = 11, Zkratka_Predmetu = "OOP" },
                new Zapsani { ID_Studenta = 11, Zkratka_Predmetu = "MAT" }
            );

            context.Hodnoceni.AddRange(
                new Hodnoceni { ID_Studenta = 1, Zkratka_Predmetu = "MAT", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 1, Zkratka_Predmetu = "STE", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 2, Zkratka_Predmetu = "FYZ", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 3, Zkratka_Predmetu = "STE", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 4, Zkratka_Predmetu = "MAT", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 4, Zkratka_Predmetu = "STE", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 5, Zkratka_Predmetu = "ANA", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 6, Zkratka_Predmetu = "ANA", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 6, Zkratka_Predmetu = "MAT", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 6, Zkratka_Predmetu = "OOP", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 7, Zkratka_Predmetu = "OOP", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 8, Zkratka_Predmetu = "STE", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 8, Zkratka_Predmetu = "MAT", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 9, Zkratka_Predmetu = "FYZ", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 10, Zkratka_Predmetu = "MAT", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 10, Zkratka_Predmetu = "ANA", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 10, Zkratka_Predmetu = "OOP", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 11, Zkratka_Predmetu = "OOP", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) },
                new Hodnoceni { ID_Studenta = 11, Zkratka_Predmetu = "MAT", Datum_Hodnoceni = DateTime.Today, Znamka = new Random().Next(50, 100) }
            );

            context.SaveChanges();
        }
    }
}
