using AkademiQMongoDb.DTOs.TestimonialDtos;
using AkademiQMongoDb.Services.TestimonialServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> Index()
        {
            var testimonials = await _testimonialService.GetAllAsync();
            return View(testimonials);
        }
        [HttpGet]
        public async Task<IActionResult> CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto testimonialDto)
        {
            if (!ModelState.IsValid)
            {
                return View(testimonialDto);
            }
            await _testimonialService.CreateAsync(testimonialDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(string id)
        {
            var testimonial = await _testimonialService.GetByIdAsync(id);
            return View(testimonial);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto testimonialDto)
        {
            if (!ModelState.IsValid)
            {
                return View(testimonialDto);
            }
            await _testimonialService.UpdateAsync(testimonialDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _testimonialService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
