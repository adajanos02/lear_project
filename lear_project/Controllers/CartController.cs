using lear_project.Data;
using lear_project.Logic;
using lear_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace lear_project.Controllers
{
    public class CartController : Controller
    {
        private readonly IFoodLogic _foodLogic;
        private readonly FoodDbContext foodDbContext;
        private readonly ICartLogic _cartLogic;
        public CartController(IFoodLogic foodLogic, ICartLogic cartLogic, FoodDbContext foodDbContext)
        {
            _foodLogic = foodLogic;
            _cartLogic = cartLogic;
            this.foodDbContext = foodDbContext;
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
        public IActionResult Delete(string id)
        {
            var todelete = _cartLogic.GetCartItems().Where(t => t.Id == id);
            for (int i = 0; i < todelete.Count(); i++)
            {
                _cartLogic.RemoveFromCart(_cartLogic.GetCartItems().FirstOrDefault(t => t.Id == id));
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

        [HttpPost]
        public IActionResult PlaceOrder(string name, string address)
        {
            // Model érvényességének ellenőrzése
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address))
            {
                return BadRequest("Név és lakcím megadása kötelező!");
            }
            // Order objektum létrehozása és hozzáadása az adatbázishoz
            var order = new Order
                {
                    Name = name,
                    Address = address,
                   // Foods = CartLogic._CartList


                    // Kosár tartalmának beállítása (amit a Cart-ból fogsz kapni)
                    // Ezt a megfelelő adatbázisból kell lekérni, ahonnan a kosár tartalma származik
                    // Pl. order.FoodItems = _cartService.GetItems();
                };

                // Az Order objektum mentése
                foodDbContext.OrderList.Add(order);
                foodDbContext.SaveChanges();

                // Sikeres válasz küldése
                return RedirectToAction("OrderPlaced");
            
            
        }
        public IActionResult OrderPlaced()
        {
            return View(_cartLogic.GetCartItems());
        }
    }
}
