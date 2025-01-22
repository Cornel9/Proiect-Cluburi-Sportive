using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Cluburi_Sportive.Data;
using Proiect_Cluburi_Sportive.Models;
using Proiect_Cluburi_Sportive.Models.ViewModels;


namespace Proiect_Cluburi_Sportive.Pages.Sectii
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext _context;

        public IndexModel(Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext context)
        {
            _context = context;
        }

        public IList<Sectie> Sectie { get; set; } = default!;
        public SectieIndexData SectieData { get; set; }
        public int SectieID { get; set; }
        public int ClubID { get; set; }

        public async Task OnGetAsync(int? id, int? ClubID)
        {
            SectieData = new SectieIndexData();
            SectieData.Sectii = await _context.Sectie
                .Include(i => i.SectiiClub)
                .ThenInclude(i => i.Club)
                .OrderBy(i => i.NumeSectie)
                .ToListAsync();
            if (id != null)
            {
                SectieID = id.Value;
                Sectie Sectie = SectieData.Sectii
                    .Where(i => i.ID == id.Value).Single();
                SectieData.SectiiClub = Sectie.SectiiClub;
            }
        }
    }
}
