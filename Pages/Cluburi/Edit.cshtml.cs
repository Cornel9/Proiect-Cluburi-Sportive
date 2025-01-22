using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Cluburi_Sportive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Cluburi_Sportive.Data;
using Proiect_Cluburi_Sportive.Models;

namespace Proiect_Cluburi_Sportive.Pages.Cluburi
{
    public class EditModel : SectiiClubPageModel
    {
        private readonly Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext _context;

        public EditModel(Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Club Club { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Club.FirstOrDefaultAsync(m => m.ID == id);
            Club = await _context.Club
            .Include(b => b.Partener)
            .Include(b => b.Competitie)
            .Include(b => b.SectiiClub).ThenInclude(b => b.Sectie)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
            if (club == null)
            {
                return NotFound();
            }
            PopulateAssignedSectieData(_context, Club);
            Club = club;
            ViewData["PartenerID"] = new SelectList(_context.Set<Partener>(), "ID",
"NumePartener");
            ViewData["CompetitieID"] = new SelectList(_context.Set<Competitie>(), "ID",
"NumeCompetitie");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedSectii)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            var clubToUpdate = await _context.Club
            .Include(i => i.Partener)
            .Include(i => i.Competitie)
            .Include(i => i.SectiiClub)
            .ThenInclude(i => i.Sectie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (clubToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Club>(
            clubToUpdate,
            "Club",
            i=>i.Nume, i=>i.Manager, i => i.Valoare, i => i.DataInfiintarii, i => i.PartenerID, i => i.CompetitieID))
            {
                UpdateSectiiClub(_context, selectedSectii, clubToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateSectiiClub(_context, selectedSectii, clubToUpdate);
            PopulateAssignedSectieData(_context, clubToUpdate);
            return Page();
        }
    }
}
