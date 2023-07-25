using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pizzapan.DataAccessLayer.Concrete;
using Pizzapan.EntityLayer.Concrete;
using Pizzapan.PresentationLayer.Models;
using System.Threading.Tasks;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class ConfirmController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ConfirmController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(AppUser appUser)
        {

            ViewBag.username = TempData["UserName"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ConfirmViewModel confirmViewModel)
        {
            var user = await _userManager.FindByNameAsync(confirmViewModel.UserName);
            if (user.ConfirmCode.ToString() == confirmViewModel.ConfirmCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}