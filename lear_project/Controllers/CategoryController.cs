using lear_project.Logic;
using lear_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace lear_project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryLogic _categoryLogic;
        private readonly IFoodLogic _foodLogic;

        public CategoryController(ILogger<CategoryController> logger, ICategoryLogic categoryLogic, IFoodLogic foodLogic)
        {
            _logger = logger;
            _categoryLogic = categoryLogic;
            _foodLogic = foodLogic;
        }

        public IActionResult Index()
        {
            var categories = _categoryLogic.GetCategories();
            return View(categories);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            _categoryLogic.AddCategory(category);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteCategory(string id)
        {
            _categoryLogic.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
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
        public IActionResult SelectedCategory(string selectedCategory)
        {
            
            var foodItems = _foodLogic.GetFoods().Where(f => f.CategoryId == selectedCategory).ToList();
            return View("FoodList", foodItems);
        }

        public IActionResult OtherPage(int categoryId)
        {
            // Itt megjeleníthető egy másik nézet a kiválasztott kategória alapján

            return View(categoryId);
        }
    }
}
