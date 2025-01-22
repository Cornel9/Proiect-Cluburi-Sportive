namespace Proiect_Cluburi_Sportive.Models
{
    public class ClubData
    {
        public IEnumerable<Club> Cluburi { get; set; }
        public IEnumerable<Sectie> Sectii { get; set; }
        public IEnumerable<SectieClub> SectieClub { get; set; }
    }
}
