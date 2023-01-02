using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Proiect_Final.Models
{
    public class Structura
    {
        public int ID { get; set; }
        public int? AngajatID { get; set; }
        public Angajat? Angajat { get; set; }
        public int? RezervareID { get; set; }
        public Rezervare? Rezervare { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataRezervare { get; set; }
        public string Masa { get; set; }
    }
}
