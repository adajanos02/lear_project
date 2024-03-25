using lear_project.Data;
using lear_project.Models;

namespace lear_project.Logic
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly FoodDbContext _context;
        public CategoryLogic(FoodDbContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            var old = _context.CategoryList.FirstOrDefault(t => t.Id == category.Id);
            if (old == null)
            {
                _context.CategoryList.Add(category);
                _context.SaveChanges();
            }
        }

        public void DeleteCategory(string catId)
        {
            var item = _context.CategoryList.FirstOrDefault(t => t.Id == catId);
            if (item == null)
            {
                _context.CategoryList.Remove(item);
                _context.SaveChanges();
            }
        }

        public List<Category> GetCategories()
        {
            return _context.CategoryList.ToList();
        }

        public void UpdateCategory(string catId)
        {
            throw new NotImplementedException();
        }
    }
}
