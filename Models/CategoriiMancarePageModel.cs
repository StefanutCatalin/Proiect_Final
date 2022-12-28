using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Final.Data;
namespace Proiect_Final.Models
{
    public class CategoriiMancarePageModel : PageModel
    {
        public List<DateAlocateCategorii> ListaDateAlocateCategorii;
        public void PopulateAssignedCategoryData(Proiect_FinalContext context,
        Rezervare rezervare)
        {
            var allCategories = context.Categorie;
            var MancareCategorii = new HashSet<int>(
            rezervare.CategoriiMancare.Select(c => c.CategorieID)); //
            ListaDateAlocateCategorii = new List<DateAlocateCategorii>();
            foreach (var cat in allCategories)
            {
                ListaDateAlocateCategorii.Add(new DateAlocateCategorii
                {
                    CategoryID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Alocat = MancareCategorii.Contains(cat.ID)
                });
            }
        }
        public void UpdateMancareCategorii(Proiect_FinalContext context,
        string[] selectedCategories, Rezervare rezervareToUpdate)
        {
            if (selectedCategories == null)
            {
                rezervareToUpdate.CategoriiMancare = new List<CategorieMancare>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var rezervareCategorii = new HashSet<int>
            (rezervareToUpdate.CategoriiMancare.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!rezervareCategorii.Contains(cat.ID))
                    {
                        rezervareToUpdate.CategoriiMancare.Add(
                        new CategorieMancare
                        {
                            RezervareID = rezervareToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (rezervareCategorii.Contains(cat.ID))
                    {
                        CategorieMancare courseToRemove
                        = rezervareToUpdate
                        .CategoriiMancare
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }


    }
}
