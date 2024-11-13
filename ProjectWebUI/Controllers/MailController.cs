using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using ProjectWebUI.VMs.MailVM;

namespace ProjectWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailVM createMailVM)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress from = new MailboxAddress("Rezervasyon Bilgilendirme", "Mail Address");
            mimeMessage.From.Add(from);
            MailboxAddress to = new MailboxAddress("User", createMailVM.ReceiverMail);
            mimeMessage.To.Add(to);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailVM.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = createMailVM.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("Mail Address", "key");

            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);


            return RedirectToAction("Index", "Category");
        }
    }
}
