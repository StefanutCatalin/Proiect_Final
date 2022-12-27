﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Final.Models;

namespace Proiect_Final.Data
{
    public class Proiect_FinalContext : DbContext
    {
        public Proiect_FinalContext (DbContextOptions<Proiect_FinalContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Final.Models.Rezervare> Rezervare { get; set; } = default!;
    }
}