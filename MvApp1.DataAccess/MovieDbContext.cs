using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using MvApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MovieApplication.Entities;
using System.Reflection.Emit;

namespace MvApp1.DataAccess
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext() {}
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
            Database.Migrate();
          
        }

        public DbSet<User> Users { get; set; }
        public DbSet<WatchedMovie> WatchedMovies { get; set; }
        public DbSet<MovieCreateDTO> movieCreateDTOs { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.EnableSensitiveDataLogging(true);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Movie>().HasMany(x => x.Categories).WithMany(x => x.Movies).
                UsingEntity("MOVIECATEGORY",
                l => l.HasOne(typeof(Category)).WithMany().HasForeignKey("CategoryId").HasPrincipalKey(nameof(Category.Id)),
                        r => r.HasOne(typeof(Movie)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(Movie.Id)),
                      // r => r.HasOne(typeof(MovieCreateDTO)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieCreateDTO.Id)),
            j => j.HasKey("MovieId", "CategoryId"));


            base.OnModelCreating(modelBuilder);
        }



             

    }




     


    
}