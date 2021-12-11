using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProducttAPI.Data;
using ProducttAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProducttAPI.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ShopContext _context;

        public CategoryController(ShopContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Add Category", new { id = category.Id }, category);
        }
    }
}

