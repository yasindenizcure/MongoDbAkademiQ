using AkademiQMongoDb.DTOs.CategoryDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Services.CategoryServices;
using AkademiQMongoDb.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace AkademiQMongoDb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }
        public IActionResult CreateCategory() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto) 
        {
            await _categoryService.CreateAsync(categoryDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id) 
        {
            var categories = await _categoryService.GetByIdAsync(id);
            return View(categories);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto) 
        {
            await _categoryService.UpdateAsync(categoryDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteCategory(string id) 
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
