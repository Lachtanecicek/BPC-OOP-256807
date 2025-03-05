using System;
using cv04;

class Program
{
    static void Main()
    {
        string testovaciText = "Toto je retezec predstavovany nekolika radky,\n"
            + "ktere jsou od sebe oddeleny znakem LF (Line Feed).\n"
            + "Je tu i nejaky ten vykricnik! Pro ucely testovani i otaznik?\n"
            + "Toto je jen zkratka zkr. ale ne konec vety. A toto je\n"
            + "posledni veta!";

        StringStatistics stats = new StringStatistics(testovaciText);

        Console.WriteLine(testovaciText);
        Console.WriteLine();
        Console.WriteLine($"Pocet slov: {stats.WordCount()}");
        Console.WriteLine($"Pocet radku: {stats.LineCount()}");
        Console.WriteLine($"Pocet vet: {stats.SentenceCount()}");
        Console.WriteLine($"Nejdelsi slova: {string.Join(", ", stats.LongestWords())}");
        Console.WriteLine($"Nejkratsi slova: {string.Join(", ", stats.ShortestWords())}");
        Console.WriteLine($"Nejčetnější slovo: {stats.MostFrequentWord()}");
        Console.WriteLine($"Setridena slova: {string.Join(", ", stats.SortedWords())}");
    }
}