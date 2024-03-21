using lear_project.Models;
using System.Diagnostics;

namespace lear_project.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<FoodDbContext>();

                context.Database.EnsureCreated();

                if (!context.FoodList.Any())
                {
                    context.FoodList.AddRange(new List<Food>()
                    {
                        new Food()
                        {
                            Name = "Hamburger",
                            Description = "Juicy burger with cheese and bacon",
                            ContentType = "Valami",
                            CategoryId = "Foetel"
                        },

                        new Food()
                        {
                            Name = "Pizza",
                            Description = "Delicious pizza with various toppings",
                            ContentType = "valami",
                            CategoryId = "Desszert"
                        },

                    });
                    context.SaveChanges();
                }

                if (!context.CategoryList.Any())
                {
                    context.CategoryList.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Name = "Foetel"
                        },

                        new Category()
                        {
                            Name = "Eloetel"
                        },

                        new Category()
                        {
                            Name = "Desszert"
                        },

                        

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
