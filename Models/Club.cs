using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Proiect_Cluburi_Sportive.Models
{
    public class Club
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Numele clubului este obligatoriu!")]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Nume club")]
        public string Nume { get; set; }
        public string Manager { get; set; }
        [Required(ErrorMessage = "Numele managerului este obligatoriu!")]
       
        [Column(TypeName = "int")]
        public int Valoare { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data înființării")]
        public DateTime DataInfiintarii { get; set; }    
        public int? PartenerID { get; set; }
        public Partener? Partener { get; set; }
        public int? CompetitieID { get; set; }
        public Competitie? Competitie { get; set; }
        [Display(Name = "Secții club")]
        public ICollection<SectieClub>? SectiiClub { get; set; }
    }
}
