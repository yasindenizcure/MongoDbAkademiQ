using AkademiQMongoDb.DTOs.BookingDtos;
using AkademiQMongoDb.DTOs.ContactDtos;
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
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _contactService.CreateAsync(createContactDto);
            return RedirectToAction("Index", "Default");
        }
    }
}
