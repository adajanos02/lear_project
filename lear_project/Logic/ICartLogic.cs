using lear_project.Models;

namespace lear_project.Logic
{
    public interface ICartLogic
    {
        void AddToCart(Food fooditem);
        void RemoveFromCart(Food fooditem);
        IEnumerable<Food> GetCartItems();
        //void ClearCart();
    }
}
