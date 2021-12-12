using Microsoft.EntityFrameworkCore;
using ProducttAPI.Data;
using ProducttAPI.Interfaces;
using ProducttAPI.Models;

namespace ProducttAPI.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ShopContext _context;
        public CategoryRepository(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<bool> AddNewCategory(Category category)
        {
            await _context.Categories.AddAsync(category);   
            int rows = await _context.SaveChangesAsync();

            return (rows > 0);
        }

        public async Task<bool> DeleteCategoryById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
           _context.Categories.Remove(category);

            int rows = await _context.SaveChangesAsync();
 
            return (rows > 0);
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            var categoryFromDB = await _context.Categories.FindAsync(category.Id);
            if(categoryFromDB != null)
            {
                categoryFromDB.Name = category.Name;
                categoryFromDB.Products = category.Products;
                
            }
            int rows = await _context.SaveChangesAsync();

            return (rows > 0);

        }
    }
}
