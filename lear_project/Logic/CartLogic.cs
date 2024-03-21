using lear_project.Data;
using lear_project.Models;

namespace lear_project.Logic
{
    public class CartLogic : ICartLogic
    {
        private readonly FoodDbContext _context;

        public CartLogic(FoodDbContext context)
        {
            _context = context;
        }

        public void AddToCart(Food foodItem)
        {
            _context.CartList.Add(foodItem);
        }

        public void RemoveFromCart(Food foodItem)
        {
            _context.CartList.Remove(foodItem);
        }

        //public void ClearCart()
        //{
        //    _context.CartList.
        //}

        public IEnumerable<Food> GetCartItems()
        {
            return _context.CartList.ToList();
        }

       
    }
}
