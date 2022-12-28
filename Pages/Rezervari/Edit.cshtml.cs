using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Final.Data;
using Proiect_Final.Models;

namespace Proiect_Final.Pages.Rezervari
{
    public class EditModel : CategoriiMancarePageModel
    {
        private readonly Proiect_Final.Data.Proiect_FinalContext _context;

        public EditModel(Proiect_Final.Data.Proiect_FinalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rezervare == null)
            {
                return NotFound();
            }
            Rezervare = await _context.Rezervare
            .Include(b => b.Chelner)
            .Include(b => b.CategoriiMancare).ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);


            var rezervare = await _context.Rezervare.FirstOrDefaultAsync(m => m.ID == id);
            if (rezervare == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Rezervare);
            Rezervare = rezervare;
            ViewData["ChelnerID"] = new SelectList(_context.Set<Chelner>(), "ID",
"NumeChelner");
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID",
"NumeIntreg");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var rezervareToUpdate = await _context.Rezervare
            .Include(i => i.Chelner)
            .Include(i => i.CategoriiMancare)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (rezervareToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Rezervare>(
            rezervareToUpdate,
            "Rezervare",
            i => i.NumeRestaurant, i => i.ClientID,
            i => i.NumarPersoane, i => i.DataRezervare, i => i.ChelnerID))
            {
                UpdateMancareCategorii(_context, selectedCategories, rezervareToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateMancareCategorii(_context, selectedCategories, rezervareToUpdate);
            PopulateAssignedCategoryData(_context, rezervareToUpdate);
            return Page();
        }
    }

}
    

