using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TallerClase.Models;

namespace Tallerxd.Data
{
    public class TallerxdContext : DbContext
    {
        public TallerxdContext (DbContextOptions<TallerxdContext> options)
            : base(options)
        {
        }

        public DbSet<TallerClase.Models.Equipoes> Equipo { get; set; } = default!;
        public DbSet<TallerClase.Models.Estadios> Estadio { get; set; } = default!;
        public DbSet<TallerClase.Models.Futbolistas> Futbolista { get; set; } = default!;
    }
}
