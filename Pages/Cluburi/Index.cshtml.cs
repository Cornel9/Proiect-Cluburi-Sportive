using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Cluburi_Sportive.Data;
using Proiect_Cluburi_Sportive.Models;

namespace Proiect_Cluburi_Sportive.Pages.Cluburi
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext _context;

        public IndexModel(Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext context)
        {
            _context = context;
        }

        public IList<Club> Club { get; set; } = default!;
        public ClubData ClubD { get; set; }
        public int ClubID { get; set; }
        public int SectieID { get; set; }
        public string NumeSort { get; set; }
        public string CompetitieSort { get; set; }
        public string ValoareSort { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? sectieID, string sortOrder, string
searchString)
        {
            ClubD = new ClubData();
            NumeSort = String.IsNullOrEmpty(sortOrder) ? "nume_desc" : "";
            CompetitieSort = sortOrder == "competitie" ? "competitie_desc" : "competitie";
            ValoareSort = sortOrder == "valoare" ? "valoare_desc" : "valoare";

            CurrentFilter = searchString;


            ClubD.Cluburi = await _context.Club
            .Include(b => b.Partener)
            .Include(b => b.Competitie)
            .Include(b => b.SectiiClub)
            .ThenInclude(b => b.Sectie)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                ClubD.Cluburi = ClubD.Cluburi.Where(s => s.Competitie.NumeCompetitie.Contains(searchString)

               || s.Competitie.NumeCompetitie.Contains(searchString)
               || s.Nume.Contains(searchString));
            }
                if (id != null)
            {
                ClubID = id.Value;
                Club club = ClubD.Cluburi
                .Where(i => i.ID == id.Value).Single();
                ClubD.Sectii = club.SectiiClub.Select(s => s.Sectie);
            }
            switch (sortOrder)
            {
                case "nume_desc":
                    ClubD.Cluburi = ClubD.Cluburi.OrderByDescending(s =>
                   s.Nume);
                    break;
                case "valoare_desc":
                    ClubD.Cluburi = ClubD.Cluburi.OrderByDescending(s =>
                   s.Valoare);
                    break;
                case "competitie_desc":
                    ClubD.Cluburi = ClubD.Cluburi.OrderByDescending(s =>
                   s.Competitie.NumeCompetitie);
                    break;
                case "competitie":
                    ClubD.Cluburi = ClubD.Cluburi.OrderBy(s =>
                   s.Competitie.NumeCompetitie);
                    break;
                default:
                    ClubD.Cluburi = ClubD.Cluburi.OrderBy(s => s.Nume);
                    break;
            }
        }
    }
}