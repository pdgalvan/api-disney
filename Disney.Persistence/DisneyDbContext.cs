using Disney.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disney.Persistence
{
    public class DisneyDbContext : DbContext
    {
        public DisneyDbContext( DbContextOptions<DisneyDbContext> options)
            :base(options)
        {

        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DisneyDbContext).Assembly);
        }
        

        
    }
}
