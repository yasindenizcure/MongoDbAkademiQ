using AkademiQMongoDb.Services.AboutServices;
using AkademiQMongoDb.Services.ChefServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultChefViewComponent: ViewComponent
    {
        private readonly IChefService _chefService;

        public _DefaultChefViewComponent(IChefService chefService)
        {
            _chefService = chefService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var chefList = await _chefService.GetAllAsync();
            return View(chefList);
        }
    }
}
