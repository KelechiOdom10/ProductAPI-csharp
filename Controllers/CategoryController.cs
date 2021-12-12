using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProducttAPI.Interfaces;
using ProducttAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProducttAPI.Controllers
{
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var categories = await _categoryRepository.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if(category == null) return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] Category category)
        {
            bool result = await _categoryRepository.AddNewCategory(category);
            if(!result) return BadRequest();

            return CreatedAtAction(nameof(GetCategories), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> UpdateCategory(int id, [FromBody] Category category)
        {
            if(id != category.Id) return BadRequest();

            var categoryFromDb = await _categoryRepository.GetCategoryById(id);
            if (categoryFromDb == null) return NotFound();

            bool result = await _categoryRepository.UpdateCategory(category);
            if (!result) return BadRequest();

            return Ok(category);
        }
    }
}

