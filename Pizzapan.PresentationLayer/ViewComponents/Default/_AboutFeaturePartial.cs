using Microsoft.AspNetCore.Mvc;

namespace Pizzapan.PrensentationLayer.ViewComponents.Default
{
    public class _AboutFeaturePartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
