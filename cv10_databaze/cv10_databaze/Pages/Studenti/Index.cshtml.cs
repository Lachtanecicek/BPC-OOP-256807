using cv10_databaze;
using cv10_databaze.Data;
using cv10_databaze.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace cv10_databaze.Pages.Studenti
{
    public class IndexModel : PageModel
    {
        private readonly VyukaContext _context;
        public IndexModel(VyukaContext context) => _context = context;

        public List<Student> Studenti { get; set; }
        public Dictionary<string, int> PrijmeniStatistika { get; set; }
        public List<MaloZapsanyPredmet> MaloZapsanych { get; set; }
        public List<HodnoceniStat> HodnoceniStatistika { get; set; }

        public async Task OnGetAsync()
        {
            Studenti = await GetStudentiAsync();
            PrijmeniStatistika = await GetPrijmeniStatistikaAsync();
            MaloZapsanych = await GetMaloZapsanychAsync();
            HodnoceniStatistika = await GetHodnoceniStatistikaAsync();
        }

        private async Task<List<Student>> GetStudentiAsync()
        {
            return await _context.Studenti
                .Include(s => s.Zapsani).ThenInclude(z => z.Predmet)
                .ToListAsync();
        }

        private async Task<Dictionary<string, int>> GetPrijmeniStatistikaAsync()
        {
            return (await _context.Studenti
                .ToListAsync())
                .GroupBy(s => s.Prijmeni)
                .OrderByDescending(g => g.Count())
                .ToDictionary(g => g.Key, g => g.Count());
        }

        private async Task<List<MaloZapsanyPredmet>> GetMaloZapsanychAsync()
        {
            return await _context.Predmety
                .Select(p => new MaloZapsanyPredmet
                {
                    Zkratka = p.Zkratka,
                    Nazev = p.Nazev,
                    PocetStudentu = p.Zapsani.Count()
                })
                .Where(p => p.PocetStudentu < 3)
                .ToListAsync();
        }

        private async Task<List<HodnoceniStat>> GetHodnoceniStatistikaAsync()
        {
            return await _context.Predmety
                .Select(p => new HodnoceniStat
                {
                    Zkratka = p.Zkratka,
                    Nazev = p.Nazev,
                    Min = p.Hodnoceni.AsEnumerable().Min(h => (int?)h.Znamka) ?? 0,
                    Max = p.Hodnoceni.AsEnumerable().Max(h => (int?)h.Znamka) ?? 0,
                    Avg = p.Hodnoceni.AsEnumerable().Average(h => (double?)h.Znamka) ?? 0,
                    Count = p.Hodnoceni.Count()
                })
                .ToListAsync();
        }

        public class MaloZapsanyPredmet
        {
            public string Zkratka { get; set; }
            public string Nazev { get; set; }
            public int PocetStudentu { get; set; }
        }

        public class HodnoceniStat
        {
            public string Zkratka { get; set; }
            public string Nazev { get; set; }
            public int Min { get; set; }
            public int Max { get; set; }
            public double Avg { get; set; }
            public int Count { get; set; }
        }
    }
}
