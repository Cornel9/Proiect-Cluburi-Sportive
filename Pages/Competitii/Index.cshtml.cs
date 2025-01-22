using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Cluburi_Sportive.Data;
using Proiect_Cluburi_Sportive.Models;

namespace Proiect_Cluburi_Sportive.Pages.Competitii
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext _context;

        public IndexModel(Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext context)
        {
            _context = context;
        }

        public IList<Competitie> Competitie { get;set; } = default!;
        public CompetitieIndexData CompetitieData { get; set; }
        public int CompetitieID { get; set; }
        public int ClubID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CompetitieData = new CompetitieIndexData();
            CompetitieData.Competitii = await _context.Competitie
            .Include(i => i.Cluburi)
            .OrderBy(i => i.NumeCompetitie)
            .ToListAsync();
            if (id != null)
            {
                CompetitieID = id.Value;
                Competitie competitie = CompetitieData.Competitii
                .Where(i => i.ID == id.Value).Single();
                CompetitieData.Club = competitie.Cluburi;
            }
        }      
    }
}
