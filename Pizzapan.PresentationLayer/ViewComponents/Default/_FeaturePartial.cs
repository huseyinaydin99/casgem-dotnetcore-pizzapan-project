using Microsoft.AspNetCore.Mvc;

namespace Pizzapan.PresentationLayer.ViewComponents.Default
{
    public class _FeaturePartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.title1 = "Gün Gün Pizza Ye";
            ViewBag.title2 = "Beğendiğin Pizzaları Paylaş";
            return View();
        }
    }
}