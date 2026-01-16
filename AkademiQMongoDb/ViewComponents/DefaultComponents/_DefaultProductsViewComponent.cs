using AkademiQMongoDb.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultProductsViewComponent: ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        //Invoke methodu eğer asenkron olursa InvokeAsync olmalı!

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }
    }
}
