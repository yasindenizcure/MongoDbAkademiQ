using AkademiQMongoDb.DTOs.SubscriberDtos;
using AkademiQMongoDb.Services.SubscriberServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    [AllowAnonymous]
    public class SubscriberController : Controller
    {
        private readonly ISubscriberService _subscriberService;

        public SubscriberController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateSubscriber(CreateSubscriberDto createSubscriberDto)
        {
            await _subscriberService.CreateAsync(createSubscriberDto);
            return RedirectToAction("Index", "Default");
        }
    }
}
