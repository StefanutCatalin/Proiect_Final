using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Final.Data;
using Proiect_Final.Models;
using Proiect_Final.Models.ViewModels;

namespace Proiect_Final.Pages.Chelneri
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Final.Data.Proiect_FinalContext _context;

        public IndexModel(Proiect_Final.Data.Proiect_FinalContext context)
        {
            _context = context;
        }

        public IList<Chelner> Chelner { get; set; } = default!;

        public ChelnerIndexData ChelnerData { get; set; }
        public int ChelnerID { get; set; }
        public int RezervareID { get; set; }
        public async Task OnGetAsync(int? id, int? rezervareID)
        {
            ChelnerData = new ChelnerIndexData();
            ChelnerData.Chelneri = await _context.Chelner
            .Include(i => i.Rezervari)
            .ThenInclude(c => c.Client)
            .OrderBy(i => i.NumeChelner)
            .ToListAsync();
            if (id != null)
            {
                ChelnerID = id.Value;
                Chelner chelner = ChelnerData.Chelneri
                .Where(i => i.ID == id.Value).Single();
                ChelnerData.Rezervari = chelner.Rezervari;
            }

        }
    }
}
