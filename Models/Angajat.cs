using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Final.Models
{
    public class Angajat
    {
        public int ID { get; set; }
        public string? Prenume { get; set; }
        public string? Nume { get; set; }
        public string? Restaurant { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        [Display(Name = "Nume Complet")]
        public string? NumeIntreg
        {
            get
            {
                return Prenume + " " + Nume;
            }
        }
        public ICollection<Structura>? structuri { get; set; }
    }
}
