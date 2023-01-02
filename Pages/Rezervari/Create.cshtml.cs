using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Final.Data;
using Proiect_Final.Models;

namespace Proiect_Final.Pages.Rezervari
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : CategoriiMancarePageModel
    {
        private readonly Proiect_Final.Data.Proiect_FinalContext _context;

        public CreateModel(Proiect_Final.Data.Proiect_FinalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ChelnerID"] = new SelectList(_context.Set<Chelner>(), "ID",
"NumeChelner");
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID",
"NumeIntreg");
            var rezervare = new Rezervare();
            rezervare.CategoriiMancare = new List<CategorieMancare>();
            PopulateAssignedCategoryData(_context, rezervare);

            return Page();
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newRezervare = new Rezervare();
            if (selectedCategories != null)
            {
                newRezervare.CategoriiMancare = new List<CategorieMancare>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategorieMancare
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newRezervare.CategoriiMancare.Add(catToAdd);
                }
            }
            Rezervare.CategoriiMancare = newRezervare.CategoriiMancare;
            _context.Rezervare.Add(Rezervare);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedCategoryData(_context, newRezervare);
            return Page();
        }
    }
}

