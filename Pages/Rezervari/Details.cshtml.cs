using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Final.Data;
using Proiect_Final.Models;

namespace Proiect_Final.Pages.Rezervari
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Final.Data.Proiect_FinalContext _context;

        public DetailsModel(Proiect_Final.Data.Proiect_FinalContext context)
        {
            _context = context;
        }

      public Rezervare Rezervare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rezervare == null)
            {
                return NotFound();
            }

            var rezervare = await _context.Rezervare.FirstOrDefaultAsync(m => m.ID == id);
            if (rezervare == null)
            {
                return NotFound();
            }
            else 
            {
                Rezervare = rezervare;
            }
            return Page();
        }
    }
}
