using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Final.Data;
using Proiect_Final.Models;

namespace Proiect_Final.Pages.Rezervari
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
            ViewData["ChelnerID"] = new SelectList(_context.Set<Chelner>(), "ID",
"NumeChelner");
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID",
"NumeIntreg");

            return Page();
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rezervare.Add(Rezervare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
