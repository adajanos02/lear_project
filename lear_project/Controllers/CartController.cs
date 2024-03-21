using lear_project.Logic;
using Microsoft.AspNetCore.Mvc;

namespace lear_project.Controllers
{
    public class CartController : Controller
    {
        private readonly IFoodLogic _foodLogic;
        private readonly ICartLogic _cartLogic;
        public CartController(IFoodLogic foodLogic, ICartLogic cartLogic)
        {
            _foodLogic = foodLogic;
            _cartLogic = cartLogic;
        }
        public IActionResult AddToCart(string foodId)
        {
            var foodItem = _foodLogic.ReadFromId(foodId);
            _cartLogic.AddToCart(foodItem);
            return View("CartList", _cartLogic.GetCartItems().ToList());
        }

        public IActionResult CartList()
        {
            
            return View(_cartLogic.GetCartItems());
        }
    }
}
