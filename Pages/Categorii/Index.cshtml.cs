using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Final.Data;
using Proiect_Final.Models;
using Proiect_Final.Models.ViewModels;

namespace Proiect_Final.Pages.Categorii
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Final.Data.Proiect_FinalContext _context;

        public IndexModel(Proiect_Final.Data.Proiect_FinalContext context)
        {
            _context = context;
        }

        public IList<Categorie> Categorie { get;set; } = default!;

        public CategorieIndexData CategorieData { get; set; }
        public int CategorieID { get; set; }
        public int RezervareID { get; set; }
        public async Task OnGetAsync(int? id, int? RezervareID)
        {
            CategorieData = new CategorieIndexData();
            CategorieData.Categorii = await _context.Categorie
            .Include(i => i.CategoriiMancare)
            .ThenInclude(i => i.Rezervare)
            .ThenInclude(i => i.Client)
            .OrderBy(i => i.NumeCategorie)
            .ToListAsync();
            if (id != null)
            {
                CategorieID = id.Value;
                Categorie categorie = CategorieData.Categorii.Where(i => i.ID == id.Value).Single();
                CategorieData.CategoriiMancare = categorie.CategoriiMancare;
            }



        }
    }
}
