using Microsoft.AspNetCore.Mvc;
using Pizzapan.BusinessLayer.Abstarct;
using Pizzapan.BussinesLayer.Absrtact;

namespace Pizzapan.PrensentationLayer.Controllers
{
    public class AboutController : Controller
    {
        private readonly IOurTeamService _ourTeamService;

        public AboutController(IOurTeamService ourTeamService)
        {
            _ourTeamService = ourTeamService;
        }

        public IActionResult Index()
        {
            var values = _ourTeamService.TGetList();
            return View(values);
        }
    }
}
