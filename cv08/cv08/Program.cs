using System;
using cv08;

class Program
{
    static void Main()
    {
        double kalibracnikonstanta = -0.1;

        ArchivTeplot archiv = new ArchivTeplot();
        archiv.Load("teploty.txt");

        Console.WriteLine("Všechny teploty:");
        archiv.TiskTeplot();

        Console.WriteLine("\nPrůměrné roční teploty:");
        archiv.TiskPrumernychRocnichTeplot();

        Console.WriteLine();
        archiv.TiskPrumernychMesicnichTeplot(3);

        archiv.Kalibrace(kalibracnikonstanta);
        archiv.Save("teploty_kalibrovane.txt");
        Console.WriteLine($"\n\nKalibrované teploty o {kalibracnikonstanta}°:");
        archiv.TiskTeplot();
    }
}