using Bulky_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky_MVC.Data
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
    }
}
