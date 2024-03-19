using lear_project.Models;
using Microsoft.EntityFrameworkCore;

namespace lear_project.Data
{
    public class FoodDbContext : DbContext
    {
        public DbSet<Food> FoodList { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("C:\\Users\\Adamecz\\source\\repos\\lear_project\\lear_project");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().HasData(new Food[]
            {
                new Food ("Pizza", "Delicious pizza with various toppings", new Category(1,"Foetel")),
                new Food ("Burger", "Juicy burger with cheese and bacon", new Category(1,"Foetel"))

            }

            );
        }
    }
}
