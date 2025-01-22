using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Cluburi_Sportive.Data;
using Proiect_Cluburi_Sportive.Models;

namespace Cluburi_Sportive.Models
{
    public class SectiiClubPageModel : PageModel
    {
        public List<AssignedSectieData> AssignedSectieDataList;
        public void PopulateAssignedSectieData(Proiect_Cluburi_SportiveContext context,
        Club club)
        {
            var allSectii = context.Sectie;
            var SectiiClub = new HashSet<int>(
            club.SectiiClub.Select(c => c.SectieID)); //
            AssignedSectieDataList = new List<AssignedSectieData>();
            foreach (var cat in allSectii)
            {
                AssignedSectieDataList.Add(new AssignedSectieData
                {
                    SectieID = cat.ID,
                    Nume = cat.NumeSectie,
                    Assigned = SectiiClub.Contains(cat.ID)
                });
            }
        }
        public void UpdateSectiiClub(Proiect_Cluburi_SportiveContext context,
        string[] selectedSectii, Club clubToUpdate)
        {
            if (selectedSectii == null)
            {
                clubToUpdate.SectiiClub = new List<SectieClub>();
                return;
            }
            var selectedSectiiHS = new HashSet<string>(selectedSectii);
            var SectiiClub = new HashSet<int>
            (clubToUpdate.SectiiClub.Select(c => c.Sectie.ID));
            foreach (var cat in context.Sectie)
            {
                if (selectedSectiiHS.Contains(cat.ID.ToString()))
                {
                    if (!SectiiClub.Contains(cat.ID))
                    {
                        clubToUpdate.SectiiClub.Add(
                        new SectieClub
                        {
                            ClubID = clubToUpdate.ID,
                            SectieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (SectiiClub.Contains(cat.ID))
                    {
                        SectieClub courseToRemove
                        = clubToUpdate
                        .SectiiClub
                        .SingleOrDefault(i => i.SectieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}