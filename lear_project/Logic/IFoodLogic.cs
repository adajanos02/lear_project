using lear_project.Data;
using lear_project.Models;

namespace lear_project.Logic
{
    public interface IFoodLogic
    {
        IEnumerable<Food> GetFoods();
        void AddFood(Food food);
        void DeleteFood(string foodId);
        void UpdateFood(string foodId, string newName, string newDescription, string newCategoryId);
        Food? ReadFromId(string id);
        Food? Read(string name);
    }
}
