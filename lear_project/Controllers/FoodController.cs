using lear_project.Logic;
using lear_project.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> AddFood(Food food)
        {
            _foodLogic.AddFood(food);
            return RedirectToAction(nameof(FoodList));
        }

        public IActionResult DeleteFood(string id)
        {
            _foodLogic.DeleteFood(id);
            return RedirectToAction(nameof(FoodList));
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
    }
    
}