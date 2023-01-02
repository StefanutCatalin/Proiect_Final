using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Final.Data;
using Proiect_Final.Models;

namespace Proiect_Final.Pages.Structuri
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Final.Data.Proiect_FinalContext _context;

        public CreateModel(Proiect_Final.Data.Proiect_FinalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var rezervareList = _context.Rezervare
            .Include(b => b.Client)
            .Select(x => new
                        {
                            x.ID,
                            RezervareNumeIntreg = x.DataRezervare + " - " + x.Client.Prenume + " " +
                    x.Client.Nume
                         });

            ViewData["RezervareID"] = new SelectList(rezervareList, "ID", "RezervareNumeIntreg");
        ViewData["AngajatID"] = new SelectList(_context.Angajat, "ID", "NumeIntreg");
            return Page();
        }

        [BindProperty]
        public Structura Structura { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Structura.Add(Structura);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
