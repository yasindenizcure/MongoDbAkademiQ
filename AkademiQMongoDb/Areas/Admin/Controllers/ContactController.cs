using AkademiQMongoDb.Services.ContactServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _contactService.GetAllAsync();
            return View(values);
        }
        [Route("/Admin/Contact/DeleteContact/{id}")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
