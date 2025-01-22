using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Cluburi_Sportive.Data;
using Proiect_Cluburi_Sportive.Models;

namespace Proiect_Cluburi_Sportive.Pages.Parteneri
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext _context;

        public DeleteModel(Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Partener Partener { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partener = await _context.Partener.FirstOrDefaultAsync(m => m.ID == id);

            if (partener == null)
            {
                return NotFound();
            }
            else
            {
                Partener = partener;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partener = await _context.Partener.FindAsync(id);
            if (partener != null)
            {
                Partener = partener;
                _context.Partener.Remove(Partener);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
