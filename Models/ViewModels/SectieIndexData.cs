using Proiect_Cluburi_Sportive.Models;
    
    namespace Proiect_Cluburi_Sportive.Models.ViewModels
{
    public class SectieIndexData
    {
        public IEnumerable<Sectie> Sectii { get; set; }
        public IEnumerable<Club> Cluburi { get; set; }
        public IEnumerable<SectieClub> SectiiClub { get; set; }
    }
}
