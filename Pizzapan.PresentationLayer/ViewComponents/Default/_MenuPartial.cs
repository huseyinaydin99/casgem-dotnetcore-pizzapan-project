using Microsoft.AspNetCore.Mvc;
using Pizzapan.BusinessLayer.Abstarct;

namespace Pizzapan.PresentationLayer.ViewComponents.Default
{
    public class _MenuPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public _MenuPartial(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            //var values = _productService.TGetProductsWithCategory();
            var values = _categoryService.TGetCategoriesWithProduct();
            return View(values);
        }
    }
}