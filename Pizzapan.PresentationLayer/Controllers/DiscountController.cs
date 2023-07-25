using Microsoft.AspNetCore.Mvc;
using Pizzapan.BusinessLayer.Abstarct;
using Pizzapan.EntityLayer.Concrete;
using System;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public IActionResult CreateCode()
        {
            string[] symbols = { "A", "B", "C", "D", "E", "F", "J", "K" };
            int s1, s2, s3, s4;
            Random random = new Random();
            s1= random.Next(0,symbols.Length);
            s2= random.Next(0,symbols.Length);
            s3= random.Next(0,symbols.Length);
            s4= random.Next(0,symbols.Length);
            int c5 = random.Next(10, 100);
            ViewBag.v = symbols[s1] + symbols[s2] + symbols[s3] + symbols[s4] + c5;
            return View();
        }

        [HttpPost]
        public IActionResult CreateCode(Discount discount)
        {
            discount.CreatedDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            discount.EndingDate = Convert.ToDateTime(DateTime.Now.AddDays(3));
        
            _discountService.TInsert(discount);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index() 
        {
            var values=_discountService.TGetList();
            return View(values);
        }      
    }
}