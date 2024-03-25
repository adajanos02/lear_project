using lear_project.Models;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
                            ContentType = "image/jpeg",
                            CategoryId = "Eloetel",
                            Data = GetImageBytes("hamburger.jpg")
                        },

                        new Food()
                        {
                            Name = "Pizza",
                            Description = "Delicious pizza with various toppings",
                            ContentType = "image/jpeg",
                            CategoryId = "Foetel",
                            Data = GetImageBytes("pizza.jpg") 
                        },
                        new Food()
                        {
                            Name = "Somloi galuska",
                            Description = "Habos, csokis, mazsolás édesség",
                            ContentType = "image/jpeg",
                            CategoryId = "Desszert",
                            Data = GetImageBytes("somloi.jpg") 
                        }
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
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        private static byte[] GetImageBytes(string imageName)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", imageName);
            return File.ReadAllBytes(imagePath);
        }
    }
}
