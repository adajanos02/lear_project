using lear_project.Data;
using lear_project.Models;

namespace lear_project.Logic
{
    public class CartLogic : ICartLogic
    {
        
        public static List<Food> _CartList = new List<Food>();

       

        public void AddToCart(Food foodItem)
        {
            _CartList.Add(foodItem);
        }

        public void RemoveFromCart(Food foodItem)
        {
            _CartList.Remove(foodItem);
        }

        //public void ClearCart()
        //{
        //    _context.CartList.
        //}

        public IEnumerable<Food> GetCartItems()
        {
            return _CartList.ToList();
        }

       
    }
}
