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
        //public DbSet<Rating> Ratings { get; set; }
        public DbSet<MovieCharacter> MovieCharacters { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DisneyDbContext).Assembly);

            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { 
                    mg.MovieId, 
                    mg.GenreId 
                });

            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.MovieId);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(g => g.MovieGenres)
                .HasForeignKey(mg => mg.GenreId);


            modelBuilder.Entity<MovieCharacter>()
                .HasKey(mc => new {
                    mc.MovieId,
                    mc.CharacterId
                });

            modelBuilder.Entity<MovieCharacter>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCharacters)
                .HasForeignKey(mc => mc.MovieId);

            modelBuilder.Entity<MovieCharacter>()
                .HasOne(mc => mc.Character)
                .WithMany(c => c.MovieCharacters)
                .HasForeignKey(mc => mc.CharacterId);


        }
        

        
    }
}
