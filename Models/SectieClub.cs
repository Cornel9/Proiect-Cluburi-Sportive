using System.ComponentModel.DataAnnotations;

namespace Proiect_Cluburi_Sportive.Models
{
    public class SectieClub
    {
        public int ID { get; set; }
        public int ClubID { get; set; }
        public Club Club { get; set; }
        public int SectieID { get; set; }        
        public Sectie Sectie { get; set; }
    }
}

