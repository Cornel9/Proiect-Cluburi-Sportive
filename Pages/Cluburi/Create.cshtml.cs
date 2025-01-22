using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Cluburi_Sportive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Cluburi_Sportive.Data;
using Proiect_Cluburi_Sportive.Models;

namespace Proiect_Cluburi_Sportive.Pages.Cluburi
{
        public class CreateModel : SectiiClubPageModel
        {
            private readonly Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext _context;

            public CreateModel(Proiect_Cluburi_Sportive.Data.Proiect_Cluburi_SportiveContext context)
            {
                _context = context;
            }

            public IActionResult OnGet()
            {
                ViewData["PartenerID"] = new SelectList(_context.Set<Partener>(), "ID",
    "NumePartener");
            ViewData["CompetitieID"] = new SelectList(_context.Set<Competitie>(), "ID",
    "NumeCompetitie");
            var club = new Club();
                club.SectiiClub = new List<SectieClub>();
                PopulateAssignedSectieData(_context, club);
                return Page();
            }

            [BindProperty]
            public Club Club { get; set; } = default!;

            // For more information, see https://aka.ms/RazorPagesCRUD.
            public async Task<IActionResult> OnPostAsync(string[] selectedSectii)
            {
                var newClub = new Club();
                if (selectedSectii != null)
                {
                    newClub.SectiiClub = new List<SectieClub>();
                    foreach (var cat in selectedSectii)
                    {
                        var catToAdd = new SectieClub
                        {
                            SectieID = int.Parse(cat)
                        };
                        newClub.SectiiClub.Add(catToAdd);
                    }
                }
                Club.SectiiClub = newClub.SectiiClub;
                _context.Club.Add(Club);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        }
    }
