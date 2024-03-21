using lear_project.Models;
using Microsoft.EntityFrameworkCore;

namespace lear_project.Data
{
    public class FoodDbContext : DbContext
    {
        public DbSet<Food> FoodList { get; set; }
        public DbSet<Category> CategoryList { get; set; }
        public DbSet<Food> CartList { get; set; }
        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
        {
            
        }


       

       
    }
}
