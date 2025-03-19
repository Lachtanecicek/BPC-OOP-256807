using System;
using cv06;

class Program
{
    static void Main()
    {
        GrObjekt[] objekty = new GrObjekt[]
        {
            new Kruh(5),
            new Obdelnik(4, 6),
            new Trojuhelnik(3, 5),
            new Elipsa(6, 4),
            new Kvadr(3, 4, 5),
            new Koule(7),
            new Valec(3, 7),
            new Jehlan(4, 6)
        };

        double celkovaPlocha = 0, celkovyPovrch = 0, celkovyObjem = 0;

        foreach (var obj in objekty)
        {
            obj.Kresli();

            if (obj is Objekt2D obj2D)
                celkovaPlocha += obj2D.SpoctiPlochu();
            if (obj is Objekt3D obj3D)
            {
                celkovyPovrch += obj3D.SpoctiPovrch();
                celkovyObjem += obj3D.SpoctiObjem();
            }
        }

        Console.WriteLine($"\nCelková plocha: {celkovaPlocha}");
        Console.WriteLine($"Celkový povrch: {celkovyPovrch}");
        Console.WriteLine($"Celkový objem: {celkovyObjem}");
    }
}
