using AkademiQMongoDb.DTOs.AboutDtos;
using AkademiQMongoDb.DTOs.ChefDtos;
using AkademiQMongoDb.Services.AboutServices;
using AkademiQMongoDb.Services.ChefServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ChefController : Controller
    {
        private readonly IChefService _chefService;

        public ChefController(IChefService chefService)
        {
            _chefService = chefService;
        }

        public async Task<IActionResult> Index()
        {
            var chefList = await _chefService.GetAllAsync();
            return View(chefList);
        }
        [HttpGet]
        public async Task<IActionResult> CreateChef()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateChef(CreateChefDto chefDto)
        {
            if (!ModelState.IsValid)
            {
                return View(chefDto);
            }
            await _chefService.CreateAsync(chefDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateChef(string id)
        {
            var chefList = await _chefService.GetByIdAsync(id);
            return View(chefList);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateChef(UpdateChefDto chefDto)
        {
            if (!ModelState.IsValid)
            {
                return View(chefDto);
            }
            await _chefService.UpdateAsync(chefDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteChef(string id)
        {
            await _chefService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
