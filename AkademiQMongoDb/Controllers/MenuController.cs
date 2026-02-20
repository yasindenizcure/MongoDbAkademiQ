using AkademiQMongoDb.Services.AboutServices;
using AkademiQMongoDb.Services.MenuServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task<IActionResult> Index()
        {
            var menu = await _menuService.GetAllAsync();
            return View(menu);
        }
    }
}
