using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Cluburi_Sportive.Data;
using Proiect_Cluburi_Sportive.Models;

namespace Proiect_Cluburi_Sportive.Pages.Competitii
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext _context;

        public DetailsModel(Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext context)
        {
            _context = context;
        }

        public Competitie Competitie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competitie = await _context.Competitie.FirstOrDefaultAsync(m => m.ID == id);
            if (competitie == null)
            {
                return NotFound();
            }
            else
            {
                Competitie = competitie;
            }
            return Page();
        }
    }
}
