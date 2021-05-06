using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflow.ViewModels;

namespace StackOverflow.ServiceLayer.Interfaces
{
    public interface ICategoryService
    {
        void InsertCategory(CategoryViewModel categoryViewModel);
        void UpdateCategory(CategoryViewModel categoryViewModel);
        void DeleteCategory(int categoryId);
        List<CategoryViewModel> GetCategories();
        List<CategoryViewModel> GetCategoryByCategoryId(int categoryid);
    }
}
