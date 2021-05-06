using System.Collections.Generic;
using AutoMapper;
using StackOverflow.DomainModels;
using StackOverflow.Repositories;
using StackOverflow.Repositories.Interfaces;
using StackOverflow.ServiceLayer.Interfaces;
using StackOverflow.ViewModels;

namespace StackOverflow.ServiceLayer
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoryService()
        {
            _categoriesRepository = new CategoriesRepository();
        }
        public void InsertCategory(CategoryViewModel categoryViewModel)
        {
            var configuration = new MapperConfiguration(config =>
           {
               config.CreateMap<CategoryViewModel, Category>();
               config.IgnoreUnMapped();
           });

            IMapper mapper = configuration.CreateMapper();

            Category category = mapper.Map<CategoryViewModel, Category>(categoryViewModel);
            _categoriesRepository.InsertCategory(category);

        }

        public void UpdateCategory(CategoryViewModel categoryViewModel)
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<CategoryViewModel, Category>();
                config.IgnoreUnMapped();
            });

            IMapper mapper = configuration.CreateMapper();

            Category category = mapper.Map<CategoryViewModel, Category>(categoryViewModel);
            _categoriesRepository.UpdateCategory(category);
        }

        public void DeleteCategory(int categoryId)
        {
            _categoriesRepository.DeleteCategory(categoryId);
        }

        public List<CategoryViewModel> GetCategories()
        {
            List<Category> categories = _categoriesRepository.GetCategories();
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<Category, CategoryViewModel>();
                config.IgnoreUnMapped();
            });

            IMapper mapper = configuration.CreateMapper();

            List<CategoryViewModel> categoryViewModels = mapper.Map<List<Category>, List<CategoryViewModel>>(categories);
            return categoryViewModels;
        }

        public List<CategoryViewModel> GetCategoryByCategoryId(int categoryid)
        {
            List<Category> categories = _categoriesRepository.GetCategoryByCategoryId(categoryid);
            List<CategoryViewModel> categoryViewModel = null;
            if (categories != null)
            {
                var configuration = new MapperConfiguration(config =>
                {
                    config.CreateMap<Category, CategoryViewModel>();
                    config.IgnoreUnMapped();
                });
                IMapper mapper = configuration.CreateMapper();

                categoryViewModel = mapper.Map<List<Category>, List<CategoryViewModel>>(categories);
            }

            return categoryViewModel;
        }
    }
}
