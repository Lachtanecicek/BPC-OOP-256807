using cv05;
using System;

class Program
{
    static void Main()
    {
        try
        {
            //Osobni auto
            Osobni osobniAuto = new(50, Auto.TypPaliva.Benzin, 5);
            osobniAuto.NastavPrepravovaneOsoby(4);
            osobniAuto.Natankuj(Auto.TypPaliva.Benzin, 30);
            
            //Nakladni auto
            Nakladni nakladniAuto = new(100, Auto.TypPaliva.Nafta, 2000);
            nakladniAuto.NastavPrepravovanyNaklad(500);
            nakladniAuto.Natankuj(Auto.TypPaliva.Nafta, 80);

            //Autoradio
            var predvolby = new (int, double)[] { (1, 101.1), (2, 95.5), (3, 88.3), (4, 99.5), (5, 102.3), (6, 85.8) };
            foreach (var (cislo, kmitocet) in predvolby)
            {
                osobniAuto.Radio.NastavPredvolbu(cislo, kmitocet);
                nakladniAuto.Radio.NastavPredvolbu(cislo, kmitocet);
            }
            osobniAuto.Radio.PreladNaPredvolbu(4);
            nakladniAuto.Radio.PreladNaPredvolbu(2);

            osobniAuto.Radio.ZapniRadio(false);
            nakladniAuto.Radio.ZapniRadio(true);

            //Vypsani do konzole
            Console.WriteLine("Osobni auto:");
            Console.WriteLine(osobniAuto);
            Console.WriteLine(osobniAuto.Radio);

            Console.WriteLine("\nNakladni auto:");
            Console.WriteLine(nakladniAuto);
            Console.WriteLine(nakladniAuto.Radio);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Chyba: {e.Message}");
        }
    }
}
