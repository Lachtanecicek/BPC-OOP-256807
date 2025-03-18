using System;
using cv06;

class Program
{
    static void Main()
    {
        Console.WriteLine("1 - Kruh");
        Console.WriteLine("2 - Obdélník");
        Console.WriteLine("3 - Trojuhelnik");
        Console.WriteLine("4 - Elipsa");
        Console.WriteLine("5 - Kvádr");
        Console.WriteLine("6 - Koule");
        Console.WriteLine("7 - Válec");
        Console.WriteLine("8 - Jehlan\n");
        Console.Write("Vyberte objekt: ");
        double objektVolba = double.Parse(Console.ReadLine());
        
        GrObjekt objekt = null;

        double vysledek1 = 0;
        double vysledek2 = 0;
        
        switch (objektVolba)
        {
            case 1:
                Console.Write("\nZadejte poloměr: ");

                Kruh kruh = new Kruh(double.Parse(Console.ReadLine()));

                vysledek1 += kruh.SpoctiPlochu();
                objekt = kruh;

                Console.WriteLine();
                objekt.Kresli();
                Console.WriteLine($"Plocha: {vysledek1} \n");

                break;
            case 2:
                Console.Write("\nZadejte délku strany a: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Zadejte délku strany b: ");
                double b = double.Parse(Console.ReadLine());
                
                Obdelnik obdelnik = new Obdelnik(a, b);

                vysledek1 += obdelnik.SpoctiPlochu();
                objekt = obdelnik;

                Console.WriteLine();
                objekt.Kresli();
                Console.WriteLine($"Plocha: {vysledek1}\n");

                break;
            case 3:
                Console.Write("\nZadejte délku strany a: ");
                a = double.Parse(Console.ReadLine());
                Console.Write("Zadejte výšku v: ");
                double v = double.Parse(Console.ReadLine());

                Trojuhelnik trojuhelnik = new Trojuhelnik(a, v);

                vysledek1 += trojuhelnik.SpoctiPlochu();
                objekt = trojuhelnik;

                Console.WriteLine();
                objekt.Kresli();
                Console.WriteLine($"Plocha: {vysledek1}\n");

                break;
            case 4:
                Console.Write("\nZadejte délku hlavní poloosy a: ");
                a = double.Parse(Console.ReadLine());
                Console.Write("Zadejte délku vedlejší poloosy b: ");
                b = double.Parse(Console.ReadLine());

                Elipsa elipsa = new Elipsa(a, b);

                vysledek1 += elipsa.SpoctiPlochu();
                objekt = elipsa;

                Console.WriteLine();
                objekt.Kresli();
                Console.WriteLine($"Plocha: {vysledek1}\n");

                break;
            case 5:
                Console.Write("\nZadejte délku strany a: ");
                a = double.Parse(Console.ReadLine());
                Console.Write("Zadejte délku strany b: ");
                b = double.Parse(Console.ReadLine());
                Console.Write("Zadejte délku strany c: ");
                double c = double.Parse(Console.ReadLine());

                Kvadr kvadr = new Kvadr(a, b, c);

                vysledek1 += kvadr.SpoctiPovrch();
                vysledek2 += kvadr.SpoctiObjem();
                objekt = kvadr;

                Console.WriteLine();
                objekt.Kresli();
                Console.WriteLine($"Povrch: {vysledek1}");
                Console.WriteLine($"Objem: {vysledek2}\n");

                break;
            case 6:
                Console.Write("\nZadejte poloměr: ");
                Koule koule = new Koule(double.Parse(Console.ReadLine()));

                vysledek1 += koule.SpoctiPovrch();
                vysledek2 += koule.SpoctiObjem();
                objekt = koule;

                Console.WriteLine();
                objekt.Kresli();
                Console.WriteLine($"Povrch: {vysledek1}");
                Console.WriteLine($"Objem: {vysledek2}\n");

                break;
            case 7:
                Console.Write("\nZadejte poloměr: ");
                double r = double.Parse(Console.ReadLine());
                Console.Write("Zadejte výšku: ");
                v = double.Parse(Console.ReadLine());

                Valec valec = new Valec(r, v);

                vysledek1 += valec.SpoctiPovrch();
                vysledek2 += valec.SpoctiObjem();
                objekt = valec;

                Console.WriteLine();
                objekt.Kresli();
                Console.WriteLine($"Povrch: {vysledek1}");
                Console.WriteLine($"Objem: {vysledek2}\n");

                break;
            case 8:
                Console.Write("\nZadejte délku strany a: ");
                a = double.Parse(Console.ReadLine());
                Console.Write("Zadejte výšku: ");
                v = double.Parse(Console.ReadLine());

                Jehlan jehlan = new Jehlan(a, v);

                vysledek1 += jehlan.SpoctiPovrch();
                vysledek2 += jehlan.SpoctiObjem();
                objekt = jehlan;

                Console.WriteLine();
                objekt.Kresli();
                Console.WriteLine($"Povrch: {vysledek1}");
                Console.WriteLine($"Objem: {vysledek2}\n");

                break;
            default:
                Console.WriteLine("\nNeplatná volba.");
                return;
        }
    }
}