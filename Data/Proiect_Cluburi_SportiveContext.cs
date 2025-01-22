using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Cluburi_Sportive.Models;

namespace Proiect_Cluburi_Sportive.Data
{
    public class Proiect_Cluburi_SportiveContext : DbContext
    {
        public Proiect_Cluburi_SportiveContext (DbContextOptions<Proiect_Cluburi_SportiveContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Cluburi_Sportive.Models.Club> Club { get; set; } = default!;
        public DbSet<Proiect_Cluburi_Sportive.Models.Partener> Partener { get; set; } = default!;
        public DbSet<Proiect_Cluburi_Sportive.Models.Sectie> Sectie { get; set; } = default!;
        public DbSet<Proiect_Cluburi_Sportive.Models.Competitie> Competitie { get; set; } = default!;
    }
}
