using System;
using cv11;
using cv11.cv11EF;
using Microsoft.EntityFrameworkCore;

NaplnDatabazi();
VypisPredmetySPoctemStudentu();
VypisPrumerneZnamky();

var studenti = StudentiPredmetu(1);
Console.WriteLine("\nStudenti v předmětu (ID 1):");
foreach (var s in studenti)
    Console.WriteLine($"- {s.Jmeno}");

var predmety = PredmetyStudenta(1);
Console.WriteLine("\nPředměty studenta (ID 1):");
foreach (var p in predmety)
    Console.WriteLine($"- {p.Nazev}");



void NaplnDatabazi()
{
    using var context = new Cv11Context();
    context.Database.EnsureCreated();


    foreach (var student in context.Studenti.Include(s => s.Predmety))
    {
        student.Predmety.Clear();
    }
    context.Hodnoceni.RemoveRange(context.Hodnoceni);
    context.SaveChanges();


    if (!context.Studenti.Any())
    {
        context.Studenti.AddRange(
            new Student { Jmeno = "Karel Houžvička" },
            new Student { Jmeno = "Anna Poledňáková" },
            new Student { Jmeno = "Petr Seitl" },
            new Student { Jmeno = "Harold Konvalinka" },
            new Student { Jmeno = "Sylva Masaříková" },
            new Student { Jmeno = "Bedřich Kulíšek" },
            new Student { Jmeno = "Štěpán Hudeček" },
            new Student { Jmeno = "Karolína Světlá" }
        );
    }

    
    if (!context.Predmety.Any())
    {
        context.Predmety.AddRange(
            new Predmet { Nazev = "Matematika" },
            new Predmet { Nazev = "Programování" },
            new Predmet { Nazev = "Fyzika" }
        );
    }

    context.SaveChanges();


    var allPredmety = context.Predmety.ToList();
    var rnd = new Random();

    foreach (var student in context.Studenti.Include(s => s.Predmety))
    {
        var count = rnd.Next(1, 4);
        var nahodnePredmety = allPredmety.OrderBy(p => rnd.Next()).Take(count).ToList();

        foreach (var predmet in nahodnePredmety)
        {
            if (!student.Predmety.Contains(predmet))
            {
                student.Predmety.Add(predmet);
            }
        }
    }

    context.SaveChanges();

    
    if (!context.Hodnoceni.Any())
    {
        int id = 1;
        foreach (var student in context.Studenti.Include(s => s.Predmety))
        {
            foreach (var predmet in student.Predmety)
            {
                context.Hodnoceni.Add(new Hodnoceni
                {
                    StudentId = student.StudentId,
                    PredmetId = predmet.PredmetId,
                    Znamka = rnd.Next(50, 101)
                });
            }
        }
    }

    context.SaveChanges();
}


void VypisPredmetySPoctemStudentu()
{
    using var context = new Cv11Context();

    var predmety = context.Predmety
        .Include(p => p.Studenti)
        .Select(p => new
        {
            p.Nazev,
            PocetStudentu = p.Studenti.Count
        })
        .OrderByDescending(p => p.PocetStudentu)
        .ToList();

    Console.WriteLine("\nPředměty a počet studentů:");
    foreach (var p in predmety)
    {
        Console.WriteLine($"{p.Nazev}: {p.PocetStudentu} studentů");
    }
}


IEnumerable<Student> StudentiPredmetu(int predmetId)
{
    using var context = new Cv11Context();
    return context.Predmety
        .Where(p => p.PredmetId == predmetId)
        .Include(p => p.Studenti)
        .SelectMany(p => p.Studenti)
        .ToList();
}


IEnumerable<Predmet> PredmetyStudenta(int studentId)
{
    using var context = new Cv11Context();
    return context.Studenti
        .Where(s => s.StudentId == studentId)
        .Include(s => s.Predmety)
        .SelectMany(s => s.Predmety)
        .ToList();
}


void VypisPrumerneZnamky()
{
    using var context = new Cv11Context();

    var prumery = context.Predmety
        .Select(p => new
        {
            p.Nazev,
            PrumernaZnamka = p.Hodnoceni.Any() ? p.Hodnoceni.Average(h => h.Znamka) : 0
        })
        .ToList();

    Console.WriteLine("\nPrůměrné známky podle předmětu:");
    foreach (var p in prumery)
    {
        Console.WriteLine($"{p.Nazev}: {p.PrumernaZnamka:F2}");
    }
}