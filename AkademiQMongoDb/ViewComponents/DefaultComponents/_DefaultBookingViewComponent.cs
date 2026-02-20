using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultBookingViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
