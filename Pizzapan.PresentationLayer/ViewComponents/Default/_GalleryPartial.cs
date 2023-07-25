using Microsoft.AspNetCore.Mvc;
using Pizzapan.BusinessLayer.Abstarct;
using System.Linq;

namespace Pizzapan.PresentationLayer.ViewComponents.Default
{
    public class _GalleryPartial : ViewComponent
    {
        private readonly IProductImageService _productImageService;

        public _GalleryPartial(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _productImageService.TGetList();
            ViewBag.list = values.Select(x => x.ImageUrl).ToList();
            return View(values);
        }
    }
}