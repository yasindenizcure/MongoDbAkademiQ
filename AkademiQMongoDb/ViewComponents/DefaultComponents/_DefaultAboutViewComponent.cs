using AkademiQMongoDb.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultAboutViewComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _DefaultAboutViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var aboutList = await _aboutService.GetAllAsync();
            return View(aboutList);
        }
    }
}
