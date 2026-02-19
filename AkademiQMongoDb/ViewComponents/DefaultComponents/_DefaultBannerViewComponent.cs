using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultBannerViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
