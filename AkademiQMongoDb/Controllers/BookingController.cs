using AkademiQMongoDb.DTOs.BookingDtos;
using AkademiQMongoDb.Services.BookingServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            await _bookingService.CreateAsync(createBookingDto);
            return RedirectToAction("Index", "Default");
        }
    }
}
