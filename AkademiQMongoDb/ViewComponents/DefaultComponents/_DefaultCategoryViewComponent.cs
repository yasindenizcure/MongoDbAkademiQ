using AkademiQMongoDb.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultCategoryViewComponent: ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _DefaultCategoryViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }
    }
}
