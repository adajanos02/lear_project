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

        public FoodController(ILogger<FoodController> logger)
        {
            _logger = logger;
        }

        public IActionResult ListFoods()
        {
            var foods = _foodLogic.GetFoods();
            return View(foods);
        }

        [HttpPost]
        public async Task<IActionResult> AddFood(Food food)
        {
            _foodLogic.AddFood(food);
            return RedirectToAction(nameof(ListFoods));
        }

        public IActionResult DeleteFood(string id)
        {
            _foodLogic.DeleteFood(id);
            return RedirectToAction(nameof(ListFoods));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}