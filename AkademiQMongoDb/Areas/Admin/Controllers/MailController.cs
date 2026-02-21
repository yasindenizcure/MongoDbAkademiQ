using AkademiQMongoDb.Services.EmailServices;
using AkademiQMongoDb.Services.SubscriberServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MailController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly ISubscriberService _subscriberService;

        public MailController(ISubscriberService subscriberService, IEmailService emailService)
        {
            _subscriberService = subscriberService;
            _emailService = emailService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendDiscountEmail() 
        {
            var subscribers = await _subscriberService.GetAllAsync();
            string subject = "%20 indirim kazandınız!!";
            string htmlMessage = @"
                <div style='text-align:center; padding:30px; font-family:Arial, sans-serif; background-color:#f9f9f9;'>
                    <h2 style='color:#e7272d;'>Tebrikler! Özel %20 İndirim Kodunuz Geldi! 🥳</h2>
                    <p style='font-size:16px; color:#555;'>Değerli lezzet tutkunu, bültenimize abone olduğunuz için teşekkür ederiz.</p>
                    <p style='font-size:16px; color:#555;'>Bir sonraki siparişinizde veya rezervasyonunuzda aşağıdaki kodu kullanarak anında <strong>%20 indirim</strong> kazanabilirsiniz:</p>
                    <div style='background-color:#fff; border:2px dashed #e7272d; padding:15px; display:inline-block; margin:20px 0; font-size:24px; font-weight:bold; letter-spacing:3px; color:#333;'>
                        FOODU20
                    </div>
                    <p style='font-size:14px; color:#888;'>Sizi tekrar restoranımızda görmek için sabırsızlanıyoruz!</p>
                </div>";
            foreach (var person in subscribers) 
            {
                await _emailService.SendEmailAsync(person.Email,subject,htmlMessage);
            }
            TempData["MailSuccess"] = "Harika! İndirim mailleri tüm abonelere başarıyla fırlatıldı.";
            return RedirectToAction("Index");
        }
    }
}
