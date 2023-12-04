using Bulky;
using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky_MVC.DataAcess.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region Default Code to Configure DbContext Class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        #endregion Default Code to Configure DbContect Class

        #region Creating Tables
        public DbSet<Category> Categories { get; set; }
        #endregion Creating Tables

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }
    }
}
