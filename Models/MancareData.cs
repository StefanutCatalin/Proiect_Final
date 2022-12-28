namespace Proiect_Final.Models
{
    public class MancareData
    {
        public IEnumerable<Rezervare> Rezervari { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieMancare> MancareCategorii { get; set; }
    }
}
