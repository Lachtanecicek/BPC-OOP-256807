using System;
using cv07;

class Program
{
    static void Main()
    {
        int[] cisla = { 1, 3, 5, 7, 9 };
        string[] slova = { "jablko", "hruška", "banán", "rododendron" };
        Console.WriteLine($"Nejvetsi číslo: {Extremy.Nejvetsi(cisla)}");
        Console.WriteLine($"Nejvetsi číslo: {Extremy.Nejmensi(cisla)}");
        Console.WriteLine($"Nejmensi slovo: {Extremy.Nejvetsi(slova)}");
        Console.WriteLine($"Nejmensi slovo: {Extremy.Nejmensi(slova)}\n");

        Objekt2D[] objekty = {
            new Kruh(5),
            new Obdelnik(4, 6),
            new Elipsa(3, 5),
            new Trojuhelnik(4, 8),
            new Ctverec(4)
        };

        Console.WriteLine($"Nejvetsi objekt: {Extremy.Nejvetsi(objekty)}");
        Console.WriteLine($"Nejmensi objekt: {Extremy.Nejmensi(objekty)}\n");

        var filtr = cisla.Where(x => x >= 4 && x <= 8);
        Console.WriteLine("Filtr 4-8: " + string.Join(", ", filtr));
    }
}