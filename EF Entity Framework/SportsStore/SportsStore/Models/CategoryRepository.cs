using SportsStore.Models.Pages;
using SportsStore.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
        PagedList<CategoryViewModel> GetCategoriesViewModels(QueryOptions options);
        PagedList<Category> GetCategories(QueryOptions options);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }

    public class CategoryRepository : ICategoryRepository
    {
        private DataContext context;

        public CategoryRepository(DataContext ctx) => context = ctx;

        public IEnumerable<Category> Categories => context.Categories;

        public PagedList<CategoryViewModel> GetCategoriesViewModels(QueryOptions options)
        {
            var query = from p in context.Products
                        join c in context.Categories on p.CategoryId equals c.Id
                        group p by new { c, c.Id } into g
                        select new CategoryViewModel
                        {
                            Category = g.Key.c,
                            ProductCount = g.Count()
                        };

            return new PagedList<CategoryViewModel>(query, options);
        }

        public PagedList<Category> GetCategories(QueryOptions options)
        {
            return new PagedList<Category>(context.Categories, options);
        }

        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            context.Categories.Update(category);
            context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }
    }
}
