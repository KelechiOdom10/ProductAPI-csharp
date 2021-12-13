using ProducttAPI.Models;

namespace ProducttAPI.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<bool> AddNewCategory(Category category);
        Task<bool> UpdateCategory(Category category);
        Task<bool> DeleteCategoryById(int id);
    }
}
