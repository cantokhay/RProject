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

            MailboxAddress from = new MailboxAddress("Rezervasyon Bilgilendirme", "multimicro14@gmail.com");
            mimeMessage.From.Add(from);
            
            MailboxAddress to = new MailboxAddress("User", createMailVM.ReceiverMail);
            mimeMessage.To.Add(to);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailVM.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = createMailVM.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("multimicro14@gmail.com", "kgxh xizn dbyp ujfs");

            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            return RedirectToAction("Index", "Category");
        }
    }
}
