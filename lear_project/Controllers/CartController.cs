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
        public IActionResult AddToCart(string foodId, int quantity)
        {
            var foodItem = _foodLogic.ReadFromId(foodId);

            // Darabszám ellenőrzése
            if (quantity < 1)
            {
                return BadRequest("Invalid quantity.");
            }

            // Kosárba helyezés
            for (int i = 0; i < quantity; i++)
            {
                _cartLogic.AddToCart(foodItem);
            }
            return View("CartList", _cartLogic.GetCartItems().ToList());
        }
        //public IActionResult DeleteCartItem(string id) 
        //{

        //}

        public IActionResult CartList()
        {
            
            return View(_cartLogic.GetCartItems());
        }
    }
}
