using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Final.Data;
using Proiect_Final.Models;

namespace Proiect_Final.Pages.Chelneri
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Final.Data.Proiect_FinalContext _context;

        public DeleteModel(Proiect_Final.Data.Proiect_FinalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Chelner Chelner { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Chelner == null)
            {
                return NotFound();
            }

            var chelner = await _context.Chelner.FirstOrDefaultAsync(m => m.ID == id);

            if (chelner == null)
            {
                return NotFound();
            }
            else 
            {
                Chelner = chelner;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Chelner == null)
            {
                return NotFound();
            }
            var chelner = await _context.Chelner.FindAsync(id);

            if (chelner != null)
            {
                Chelner = chelner;
                _context.Chelner.Remove(Chelner);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
