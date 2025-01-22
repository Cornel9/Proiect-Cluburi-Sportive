using System.ComponentModel.DataAnnotations;

namespace Proiect_Cluburi_Sportive.Models
{
    public class Competitie
    {
        public int ID { get; set; }
        [Display(Name = "Nume competiție")]
        public string NumeCompetitie { get; set; }
        public ICollection<Club>? Cluburi{ get; set; }
    }
}
