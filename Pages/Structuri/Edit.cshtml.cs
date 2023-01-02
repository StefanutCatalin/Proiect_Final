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
    public class EditModel : PageModel
    {
        private readonly Proiect_Final.Data.Proiect_FinalContext _context;

        public EditModel(Proiect_Final.Data.Proiect_FinalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Structura Structura { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Structura == null)
            {
                return NotFound();
            }

            var structura =  await _context.Structura.FirstOrDefaultAsync(m => m.ID == id);
            if (structura == null)
            {
                return NotFound();
            }
            Structura = structura;
           ViewData["AngajatID"] = new SelectList(_context.Angajat, "ID", "ID");
           ViewData["RezervareID"] = new SelectList(_context.Rezervare, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Structura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StructuraExists(Structura.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StructuraExists(int id)
        {
          return _context.Structura.Any(e => e.ID == id);
        }
    }
}
