using Bulky.Models;
using Bulky.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) { }
         
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1 , Name = "Scifi" , DisplayOrder = 1},
                new Category { Id = 2, Name = "Action", DisplayOrder = 2 }
                );
        }
    }
}
