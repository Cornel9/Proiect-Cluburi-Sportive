using System.Security.Policy;

namespace Proiect_Cluburi_Sportive.Models
{
    public class CompetitieIndexData
    {
        public IEnumerable<Competitie> Competitii { get; set; }
        public IEnumerable<Club> Club { get; set; }
    }
}
