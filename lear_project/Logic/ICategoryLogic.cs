using lear_project.Models;

namespace lear_project.Logic
{
    public interface ICategoryLogic
    {

        List<Category> GetCategories();
        void AddCategory(Category category);
        void DeleteCategory(string catId);
        void UpdateCategory(string catId);
       
    }
}
