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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Final.Data.Proiect_FinalContext _context;

        public IndexModel(Proiect_Final.Data.Proiect_FinalContext context)
        {
            _context = context;
        }

        public IList<Structura> Structura { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Structura != null)
            {
                Structura = await _context.Structura
                .Include(s => s.Angajat)

                .Include(s => s.Rezervare)
                .ThenInclude(b => b.Client)
                .ToListAsync();
            }
        }
    }
}
