using AkademiQMongoDb.Services.BookingServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _bookingService.GetAllAsync();
            return View(values);
        }
        [Route("/Admin/Booking/DeleteBooking/{id}")]
        public async Task<IActionResult> DeleteBooking(string id)
        {
            await _bookingService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [Route("/Admin/Booking/Approve/{id}")]
        public async Task<IActionResult> Approve(string id)
        {
            await _bookingService.ApproveBookingAsync(id);
            return RedirectToAction("Index");
        }
    }
}
