using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Final.Models
{
    public class Angajat
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage ="Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau AnaMaria")]
        [StringLength(30, MinimumLength = 3)]
        public string? Prenume { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage ="Numele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau AnaMaria")]
        [StringLength(30, MinimumLength = 3)]
        public string? Nume { get; set; }
        [StringLength(70)]

        public string? Restaurant { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau'0722.123.123' sau '0722 123 123'")]
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
