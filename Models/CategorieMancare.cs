namespace Proiect_Final.Models
{
    public class CategorieMancare
    {
        public int ID { get; set; }
        public int RezervareID { get; set; }
        public Rezervare Rezervare { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
