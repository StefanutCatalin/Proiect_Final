namespace Proiect_Final.Models
{
    public class Chelner
    {
        public int ID { get; set; }
        public string NumeChelner { get; set; }
        public ICollection<Rezervare>? Rezervari { get; set; }
    }
}
