using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Cluburi_Sportive.Data;
using Proiect_Cluburi_Sportive.Models;

namespace Proiect_Cluburi_Sportive.Pages.Sectii
{
    public class EditModel : PageModel
    {
        private readonly Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext _context;

        public EditModel(Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sectie Sectie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectie =  await _context.Sectie.FirstOrDefaultAsync(m => m.ID == id);
            if (sectie == null)
            {
                return NotFound();
            }
            Sectie = sectie;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sectie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectieExists(Sectie.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SectieExists(int id)
        {
            return _context.Sectie.Any(e => e.ID == id);
        }
    }
}
