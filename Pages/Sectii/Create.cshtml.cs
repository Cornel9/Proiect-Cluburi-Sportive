using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Cluburi_Sportive.Data;
using Proiect_Cluburi_Sportive.Models;

namespace Proiect_Cluburi_Sportive.Pages.Sectii
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext _context;

        public CreateModel(Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Sectie Sectie { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sectie.Add(Sectie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
