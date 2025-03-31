using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv08
{
    class ArchivTeplot
    {
        private SortedDictionary<int, RocniTeplota> _archiv = new();

        public void Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Soubor {filePath} nebyl nalezen.");
                return;
            }

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(':');
                int rok = int.Parse(parts[0].Trim());
                var teploty = parts[1].Split(';').Select(t => double.Parse(t.Trim())).ToList();
                _archiv[rok] = new RocniTeplota(rok, teploty);
            }
        }

        public void Save(string filePath)
        {
            using StreamWriter writer = new(filePath);
            foreach (var entry in _archiv)
            {
                writer.WriteLine($"{entry.Key}: {string.Join("; ", entry.Value.MesicniTeploty.Select(t => t.ToString("F1")))}");
            }
        }

        public void Kalibrace(double konstanta)
        {
            foreach (var entry in _archiv.Values)
            {
                for (int i = 0; i < entry.MesicniTeploty.Count; i++)
                {
                    entry.MesicniTeploty[i] = Math.Round(entry.MesicniTeploty[i] + konstanta, 1);
                }
            }
        }

        public RocniTeplota? Vyhledej(int rok) => _archiv.ContainsKey(rok) ? _archiv[rok] : null;

        public void TiskTeplot()
        {
            foreach (var entry in _archiv)
            {
                Console.WriteLine($"{entry.Key}: {string.Join("; ", entry.Value.MesicniTeploty)}");
            }
        }

        public void TiskPrumernychRocnichTeplot()
        {
            foreach (var entry in _archiv)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value.PrumRocniTeplota:F2}");
            }
        }

        public void TiskPrumernychMesicnichTeplot(int mesic)
        {
            Console.WriteLine($"Teploty pro měsíc {mesic} v jednotlivých letech:");
            foreach (var entry in _archiv)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value.MesicniTeploty[mesic - 1]:F2}");
            }
        }
    }

}
