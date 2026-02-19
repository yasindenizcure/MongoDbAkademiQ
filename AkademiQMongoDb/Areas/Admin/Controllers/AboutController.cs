using AkademiQMongoDb.DTOs.AboutDtos;
using AkademiQMongoDb.DTOs.CategoryDtos;
using AkademiQMongoDb.DTOs.ProductDtos;
using AkademiQMongoDb.Services.AboutServices;
using AkademiQMongoDb.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            var abouts = await _aboutService.GetAllAsync();
            return View(abouts);
        }
        [HttpGet]
        public async Task<IActionResult> CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto aboutDto)
        {
            if (!ModelState.IsValid)
            {
                return View(aboutDto);
            }
            await _aboutService.CreateAsync(aboutDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            var abouts = await _aboutService.GetByIdAsync(id);
            return View(abouts);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto aboutDto)
        {
            if (!ModelState.IsValid)
            {
                return View(aboutDto);
            }
            await _aboutService.UpdateAsync(aboutDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
