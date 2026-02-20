using AkademiQMongoDb.Services.CategoryServices;
using AkademiQMongoDb.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultMenuViewComponent: ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultMenuViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }
    }
}
