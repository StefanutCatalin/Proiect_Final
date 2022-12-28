using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Final.Models
{
    public class Client
    {
        public int ID { get; set; }
        [Display(Name = "Prenume")]
        public string Prenume { get; set; }
        [Display(Name = "Nume")]
        public string Nume { get; set; }
        [Display(Name = "Nume Client")]
        public string NumeIntreg { get { return Prenume + " " + Nume; } }

        public ICollection<Rezervare>? Rezervari {get; set; }
    }
}
