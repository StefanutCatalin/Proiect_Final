using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Final.Models
{
    public class Rezervare
    {
        public int ID { get; set; }
        [Display(Name = "Numele restaurantului")]
        public string NumeRestaurant { get; set; }
        [Display(Name = "Numarul de persoane")]
        public int NumarPersoane { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataRezervare { get; set; }
        public int? ChelnerID { get; set; }
        public Chelner? Chelner { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public ICollection<CategorieMancare>? CategoriiMancare { get; set; }

    }
}
