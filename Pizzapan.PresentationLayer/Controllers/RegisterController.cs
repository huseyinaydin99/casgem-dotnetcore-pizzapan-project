using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Pizzapan.EntityLayer.Concrete;
using Pizzapan.PresentationLayer.Models;
using System;
using System.Threading.Tasks;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            Random rnd=new Random();
            int x = rnd.Next(10000, 100000);

            AppUser appUser = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.Username,
                ConfirmCode=x
            };
            
            if (model.Password==model.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                    {
                    #region
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddress = new MailboxAddress("Admin", "ozgebektas53@gmail.com");
                    mimeMessage.From.Add(mailboxAddress);

                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.Email);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Giriş Yapabilmek için onaylama kodunuz:" + x;

                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Doğrulama Kodunuz";
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect("smtp.gmail.com", 587, false);
                    smtpClient.Authenticate("ozgebektas53@gmail.com", "jtgvvirpkrfubpcr");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);

                    #endregion
                    TempData["UserName"] = appUser.UserName;
                    return RedirectToAction("Index", "Confirm");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Şifreler eşleşmiyor");
            }
            return View();
        }
    }
}