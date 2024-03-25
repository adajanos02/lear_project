using lear_project.Logic;
using lear_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;

namespace lear_project.Controllers
{

    public class FoodController : Controller
    {
        private readonly ILogger<FoodController> _logger;
        private readonly IFoodLogic _foodLogic;
        private readonly ICartLogic _cartLogic;

        public FoodController(ILogger<FoodController> logger, IFoodLogic foodLogic, ICartLogic cartLogic)
        {
            _logger = logger;
            _foodLogic = foodLogic;
            _cartLogic = cartLogic;
        }

        public IActionResult FoodList()
        {
            return View(_foodLogic.GetFoods());
        }

        public IActionResult FoodEditor()
        {
            return View(_foodLogic.GetFoods());
        }

        public IActionResult AddFood()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFood(Food food, IFormFile picturedata)
        {
            using (var stream = picturedata.OpenReadStream())
            {
                byte[] buffer = new byte[picturedata.Length];
                stream.Read(buffer, 0, (int)picturedata.Length);
                //db módszer
                food.Data = buffer;
                food.ContentType = picturedata.ContentType;
            }

            _foodLogic.AddFood(food);
            return RedirectToAction(nameof(FoodList));
        }

        public IActionResult DeleteFood(string id)
        {
            _foodLogic.DeleteFood(id);
            return RedirectToAction(nameof(FoodEditor));
        }

        public async Task<IActionResult> UpdateFood(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = _foodLogic.ReadFromId(id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFood(string oldFoodId, string newName, string newDescription, string newCategoryId)
        {
            _foodLogic.UpdateFood(oldFoodId, newName, newDescription, newCategoryId);
            return RedirectToAction(nameof(FoodEditor));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SelectedCategory(string selectedCategory)
        {
            var foodItems = _foodLogic.GetFoods().Where(f => f.CategoryId == selectedCategory).ToList();
            return View("FoodList", foodItems);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetImage(string id)
        {
            var food = _foodLogic.ReadFromId(id);
            if (food.ContentType.Length > 3)
            {
                return new FileContentResult(food.Data, food.ContentType);
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string password)
        {
            if (password == "jelszo")
            {
                return RedirectToAction(nameof(FoodEditor));
            }
            else
                return View();
        }
    }
    
}