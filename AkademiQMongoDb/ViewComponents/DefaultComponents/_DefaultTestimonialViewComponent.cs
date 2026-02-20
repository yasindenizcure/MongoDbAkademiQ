using AkademiQMongoDb.Services.AboutServices;
using AkademiQMongoDb.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultTestimonialViewComponent: ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public _DefaultTestimonialViewComponent(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var testimonials = await _testimonialService.GetAllAsync();
            return View(testimonials);
        }
    }
}
