using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace cv04
{
    class StringStatistics
    {
        private string text;
        private string[] words;

        public StringStatistics(string text)
        {
            this.text = text;
            this.words = ExtractWords(text);
        }

        private string[] ExtractWords(string text)
        {
            return Regex.Split(text, "[^\\w]+", RegexOptions.IgnoreCase)
                        .Where(w => !string.IsNullOrEmpty(w))
                        .ToArray();
        }

        public int WordCount() => words.Length;

        public int LineCount() => text.Split('\n').Length;

        public int SentenceCount()
        {
            return Regex.Matches(text, "[.!?](?=\\s+[A-Z]|$)").Count;
        }

        public string[] LongestWords()
        {
            int maxLength = words.Max(w => w.Length);
            return words.Where(w => w.Length == maxLength).Distinct().ToArray();
        }

        public string[] ShortestWords()
        {
            int minLength = words.Min(w => w.Length);
            return words.Where(w => w.Length == minLength).Distinct().ToArray();
        }

        public string MostFrequentWord()
        {
            return words.GroupBy(w => w)
                        .OrderByDescending(g => g.Count())
                        .Select(g => g.Key)
                        .FirstOrDefault() ?? "Žádné slovo";
        }

        public string[] SortedWords() => words.Distinct().OrderBy(w => w).ToArray();
    }

}
