using System.ComponentModel.DataAnnotations;

namespace Proiect_Cluburi_Sportive.Models
{
    public class Sectie
    {
        public int ID { get; set; }
        [Display(Name = "Nume secție")]
        public string NumeSectie { get; set; }        
        public ICollection<SectieClub>? SectiiClub { get; set; }
    }
}
