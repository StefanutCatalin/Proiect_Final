﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Final.Data.Proiect_FinalContext _context;

        public IndexModel(Proiect_Final.Data.Proiect_FinalContext context)
        {
            _context = context;
        }
        

        public IList<Rezervare> Rezervare { get;set; }
        public MancareData MancareD { get; set; }
        public int RezervareID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            MancareD = new MancareData();

            MancareD.Rezervari = await _context.Rezervare
                .Include(b => b.Chelner)
                .Include(b => b.Client)
                .Include(b => b.CategoriiMancare)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.NumeRestaurant)
            .ToListAsync();
            if (id != null)
            {
                RezervareID =id.Value;
                Rezervare rezervare = MancareD.Rezervari
                .Where(i => i.ID == id.Value).Single();
                MancareD.Categorii = rezervare.CategoriiMancare.Select(s => s.Categorie);
            }
        }


    }
}
