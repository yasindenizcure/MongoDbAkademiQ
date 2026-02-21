using MailKit.Net.Smtp;
using MimeKit;

namespace AkademiQMongoDb.Services.EmailServices
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string toEmail, string subject, string htmlMessage)
        {
            var emailToSend = new MimeMessage();

            emailToSend.From.Add(new MailboxAddress("Foodu Restaurant", "yasindenizcure@gmail.com"));

            emailToSend.To.Add(MailboxAddress.Parse(toEmail));

            emailToSend.Subject = subject;

            var builder = new BodyBuilder { HtmlBody = htmlMessage };

            emailToSend.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            try 
            {
                await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync("yasindenizcure@gmail.com", "fwykvswpobozdoga");
                await smtp.SendAsync(emailToSend);
            }
            finally
            {
                await smtp.DisconnectAsync(true);
            }
        }
    }
}
