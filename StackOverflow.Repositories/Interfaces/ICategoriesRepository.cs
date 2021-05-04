using System.Collections.Generic;
using StackOverflow.DomainModels;

namespace StackOverflow.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryId);
        List<Category> GetCategories();
        List<Category> GetCategoryByCategoryId(int categoryId);
    }
}