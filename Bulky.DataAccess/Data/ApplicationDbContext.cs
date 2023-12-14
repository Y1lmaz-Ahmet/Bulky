using Bulky;
using Bulky.Models;
using BulkyBook.Models;
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
        public DbSet<Category> Categories { get; set; } // makes a DataTable with the name Categories
        public DbSet< Product> Products { get; set; } // makes a DataTable with the name Products
        #endregion Creating Tables

        // Create 3 objects after table is made. Seeding the table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
            new Product 
            { 
                Id = 1,
                Title = "Book 1",
                Description = "Description 1",
                ISBN = "ISBN1",
                Author = "Author 1",
                ListPrice = 19.99,
                Price = "14.99",
                Price50 = 12.99,
                Price100 = 10.99
            },
            new Product { 
                Id = 2,
                Title = "Book 2",
                Description = "Description 2",
                ISBN = "ISBN2",
                Author = "Author 2",
                ListPrice = 24.99,
                Price = "19.99",
                Price50 = 17.99,
                Price100 = 15.99
            },
            new Product { Id = 3,
                Title = "Book 3",
                Description = "Description 3",
                ISBN = "ISBN3",
                Author = "Author 3",
                ListPrice = 29.99,
                Price = "24.99",
                Price50 = 22.99,
                Price100 = 20.99
            },
            new Product { Id = 4,
                Title = "Book 4",
                Description = "Description 4",
                ISBN = "ISBN4",
                Author = "Author 4",
                ListPrice = 34.99,
                Price = "29.99",
                Price50 = 27.99,
                Price100 = 25.99
            },
            new Product { Id = 5,
                Title = "Book 5",
                Description = "Description 5",
                ISBN = "ISBN5",
                Author = "Author 5",
                ListPrice = 39.99,
                Price = "34.99",
                Price50 = 32.99,
                Price100 = 30.99 
            }
        );
        }
    }
}
