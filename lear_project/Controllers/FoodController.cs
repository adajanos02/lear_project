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
        public IActionResult AddToCart(string foodId)
        {
            // Itt lehet az adott ételhez tartozó adatokat lekérdezni és hozzáadni a kosárhoz
            var foodItem = _foodLogic.ReadFromId(foodId);

            // Például hozzáadás a kosárhoz
            _cartLogic.AddToCart(foodItem);

            // Visszatérés a FoodList nézetre vagy más megfelelő helyre
            return RedirectToAction("Index", "FoodList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    //public class FoodController : Controller
    //{

    //    private readonly IFoodLogic _foodLogic;
    //    private readonly ILogger<FoodController> _logger;

    //    public FoodController(IFoodLogic foodLogic, ILogger<FoodController> logger)
    //    {
    //        _foodLogic = foodLogic;
    //        _logger = logger;
    //    }

    //    public IActionResult ListFoods()
    //    {
    //        var foods = _foodLogic.GetFoods();
    //        return View(foods);
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> AddFood(Food food, IFormFile picturedata)
    //    {
    //        using(var stream = picturedata.OpenReadStream())
    //        {
    //            byte[] buffer = new byte[picturedata.Length];
    //            stream.Read(buffer, 0, (int)picturedata.Length);
    //            food.Data = buffer;
    //            food.ContentType = picturedata.ContentType;
    //        }



    //        _foodLogic.AddFood(food);
    //        return RedirectToAction(nameof(ListFoods));
    //    }
    //    [HttpGet]
    //    public IActionResult DeleteFood(string id)
    //    {
    //        _foodLogic.DeleteFood(id);
    //        return RedirectToAction(nameof(ListFoods));
    //    }

    //    public IActionResult GetImage(string id)
    //    {
    //        var food = _foodLogic.ReadFromId(id);
    //        if (food.ContentType.Length > 3)
    //            return new FileContentResult(food.Data, food.ContentType);
    //        else
    //            return BadRequest();
    //    }

    //    [HttpGet]
    //    public IActionResult Filter(Category category)
    //    {
    //        IEnumerable<Food> filteredFoods;
    //        filteredFoods = _foodLogic.GetFoods().Where(t => t.CategoryId == category.Id);

    //        return View("Index",filteredFoods);
    //    }

    //    public IActionResult Privacy()
    //    {
    //        return View();
    //    }

    //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //    public IActionResult Error()
    //    {
    //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //    }
    //}
}