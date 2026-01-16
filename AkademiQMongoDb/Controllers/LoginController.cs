using AkademiQMongoDb.DTOs.AdminDtos;
using AkademiQMongoDb.Services.AdminServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    public class LoginController(IAdminService _adminService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginAdminDto loginAdminDto) 
        {
            var result = await _adminService.LoginAdminAsync(loginAdminDto);
            if(result is false) 
            {
                ModelState.AddModelError("", "Kullanıcı adı veya Şifre hatalı.");
                return View(loginAdminDto);
            }
            return RedirectToAction("Index", "Product", new {area = "Admin"});
        }
    }
}
