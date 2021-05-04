using System;
using System.Collections.Generic;
using System.Linq;
using StackOverflow.DomainModels;
using StackOverflow.Repositories.Interfaces;

namespace StackOverflow.Repositories
{
    public class CategoriesRepository:ICategoriesRepository
    {
        private readonly StackOverflowDbContext db;

        public CategoriesRepository()
        {
            db = new StackOverflowDbContext();
        }
        public void InsertCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            Category updateCategory = db.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (updateCategory!=null)
            {
                updateCategory.CategoryName = category.CategoryName;
                db.SaveChanges();
            }
        }

        public void DeleteCategory(int categoryId)
        {
            Category deleteCategory = db.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (deleteCategory != null)
            {
                db.Categories.Remove(deleteCategory);
                db.SaveChanges();
            }

        }

        public List<Category> GetCategories()
        {
            List<Category> categories = db.Categories.ToList();
            return categories;
        }

        public List<Category> GetCategoryByCategoryId(int categoryId)
        {
            List<Category> getCategory = db.Categories.Where(c => c.CategoryId == categoryId).ToList();
            return getCategory;
        }
    }
}
