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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Final.Data.Proiect_FinalContext _context;

        public DetailsModel(Proiect_Final.Data.Proiect_FinalContext context)
        {
            _context = context;
        }

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
    }
}
