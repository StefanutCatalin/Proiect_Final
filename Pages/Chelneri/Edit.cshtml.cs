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

namespace Proiect_Final.Pages.Chelneri
{
    public class EditModel : PageModel
    {
        private readonly Proiect_Final.Data.Proiect_FinalContext _context;

        public EditModel(Proiect_Final.Data.Proiect_FinalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Chelner Chelner { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Chelner == null)
            {
                return NotFound();
            }

            var chelner =  await _context.Chelner.FirstOrDefaultAsync(m => m.ID == id);
            if (chelner == null)
            {
                return NotFound();
            }
            Chelner = chelner;
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

            _context.Attach(Chelner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChelnerExists(Chelner.ID))
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

        private bool ChelnerExists(int id)
        {
          return _context.Chelner.Any(e => e.ID == id);
        }
    }
}
