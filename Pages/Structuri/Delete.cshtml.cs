using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Final.Data;
using Proiect_Final.Models;

namespace Proiect_Final.Pages.Structuri
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Final.Data.Proiect_FinalContext _context;

        public DeleteModel(Proiect_Final.Data.Proiect_FinalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Structura Structura { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Structura == null)
            {
                return NotFound();
            }

            var structura = await _context.Structura.FirstOrDefaultAsync(m => m.ID == id);

            if (structura == null)
            {
                return NotFound();
            }
            else 
            {
                Structura = structura;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Structura == null)
            {
                return NotFound();
            }
            var structura = await _context.Structura.FindAsync(id);

            if (structura != null)
            {
                Structura = structura;
                _context.Structura.Remove(Structura);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
