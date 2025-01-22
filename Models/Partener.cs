using System.ComponentModel.DataAnnotations;

namespace Proiect_Cluburi_Sportive.Models
{
    public class Partener
    {
        public int ID { get; set; }
        [Display(Name = "Nume partener")]
        public string NumePartener { get; set; }
        public ICollection<Club>? Club { get; set; }
    }
}
