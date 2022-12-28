namespace Proiect_Final.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string NumeCategorie { get; set; }
        public ICollection<CategorieMancare>? CategoriiMancare { get; set; }
    }
}
