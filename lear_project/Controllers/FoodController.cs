using lear_project.Logic;
using lear_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> AddFood(Food food)
        {
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

        // POST: Food/Edit/5
        [HttpPost]
        public async Task<IActionResult> UpdateFood(string oldFoodId, string newName, string newDescription, string newCategoryId)
        {
            
            _foodLogic.UpdateFood(oldFoodId, newName, newDescription, newCategoryId);

            return RedirectToAction(nameof(FoodEditor));
        }

       

        //public IActionResult UpdateFood(string id)
        //{

        //    return View(id);
        //}
        //[HttpPost]
        //public IActionResult UpdateFood(Food food, string id)
        //{
        //    _foodLogic.UpdateFood(id, food);
        //    return RedirectToAction(nameof(FoodEditor));
        //}

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