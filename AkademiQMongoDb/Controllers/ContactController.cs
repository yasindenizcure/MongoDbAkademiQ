using AkademiQMongoDb.Services.ContactServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public async Task<IActionResult> Index()
        {
            var contacts = await _contactService.GetAllAsync();
            return View(contacts);
        }
    }
}

