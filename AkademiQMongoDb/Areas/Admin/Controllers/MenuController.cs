using AkademiQMongoDb.DTOs.MenuDtos;
using AkademiQMongoDb.Services.MenuServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task<IActionResult> Index()
        {
            var menus = await _menuService.GetAllAsync();
            return View(menus);
        }
        [HttpGet]
        public async Task<IActionResult> CreateMenu()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuDto menuDto)
        {
            if (!ModelState.IsValid)
            {
                return View(menuDto);
            }
            await _menuService.CreateAsync(menuDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateMenu(string id)
        {
            var Menus = await _menuService.GetByIdAsync(id);
            return View(Menus);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMenu(UpdateMenuDto menuDto)
        {
            if (!ModelState.IsValid)
            {
                return View(menuDto);
            }
            await _menuService.UpdateAsync(menuDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteMenu(string id)
        {
            await _menuService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
