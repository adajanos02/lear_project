﻿using lear_project.Data;
using lear_project.Models;

namespace lear_project.Logic
{
    public class FoodLogic : IFoodLogic
    {
        private readonly FoodDbContext _context;

        public FoodLogic(FoodDbContext context)
        {
            _context = context;
        }

        public void AddFood(Food food)
        {
            var old = _context.FoodList.FirstOrDefault(t => t.Id == food.Id);
            if (old == null)
            {
                _context.FoodList.Add(food);
                _context.SaveChanges();
            }
        }

        public void DeleteFood(string foodId)
        {
            var item = _context.FoodList.FirstOrDefault(t => t.Id == foodId);
            if (item != null)
            {
                _context.FoodList.Remove(item);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Food> GetFoods()
        {
            return _context.FoodList.ToList();
        }
        public IEnumerable<Food> Read()
        {
            return _context.FoodList;
        }

        public Food? Read(string name)
        {
            return _context.FoodList.FirstOrDefault(t => t.Name == name);
        }

        public Food? ReadFromId(string id)
        {
            return _context.FoodList.FirstOrDefault(t => t.Id == id);
        }

        public void UpdateFood(string foodId, string newName, string newDescription, string newCategoryId)
        {
            _context.FoodList.FirstOrDefault(t => t.Id == foodId).Name = newName;
            _context.FoodList.FirstOrDefault(t => t.Id == foodId).Description = newDescription;
            _context.FoodList.FirstOrDefault(t => t.Id == foodId).CategoryId = newCategoryId;
            _context.SaveChanges();
        }
    }
}
