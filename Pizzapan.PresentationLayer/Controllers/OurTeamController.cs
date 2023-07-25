using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Pizzapan.BusinessLayer.Abstarct;
using Pizzapan.BusinessLayer.ValidationRules.OurTeamValidator;
using Pizzapan.EntityLayer.Concrete;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class OurTeamController : Controller
    {
        private readonly IOurTeamService _ourTeamService;

        public OurTeamController(IOurTeamService ourTeamService)
        {
            _ourTeamService = ourTeamService;
        }

        public IActionResult Index()
        {
            var values = _ourTeamService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddOurTeam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOurTeam(OurTeam ourTeam)
        {
            CreateOurTeamValidator createOurTeamValidator = new CreateOurTeamValidator();
            ValidationResult result = createOurTeamValidator.Validate(ourTeam);
            if (result.IsValid)//Doğrulamaları geçiyorsa
            {
                _ourTeamService.TInsert(ourTeam);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

        }

        [HttpGet]
        public IActionResult UpdateOurTeam(int id)
        {
            var values = _ourTeamService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateOurTeam(OurTeam ourTeam)
        {
            _ourTeamService.TUpdate(ourTeam);
            return RedirectToAction("Index");
        }
    }
}