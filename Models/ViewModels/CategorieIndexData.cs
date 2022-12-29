namespace Proiect_Final.Models.ViewModels
{
    public class CategorieIndexData
    {
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieMancare> CategoriiMancare { get; set; }
        public IEnumerable<Rezervare> Rezervari { get; set; }
    }
}
