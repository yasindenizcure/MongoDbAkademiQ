using AkademiQMongoDb.DTOs.AdminDtos;
using AkademiQMongoDb.Services.AdminServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    [AllowAnonymous]
    public class RegisterController(IAdminService _adminService) : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterAdminDto registerAdminDto) 
        {
            await _adminService.CreateAdminAsync(registerAdminDto);
            return RedirectToAction("Index", "Login");
        }
    }
}
