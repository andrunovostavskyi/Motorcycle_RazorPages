using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Motorcycle.Pages.MainPages.Cat
{
    public class CategoryModel : PageModel
    {
        private readonly MotoContext _motoContext;
        public List<Category> Categories { get; set; }
        public CategoryModel(MotoContext motoContext)
        {
                _motoContext = motoContext;
        }
        public void OnGet()
        {
            Categories = _motoContext.Categories.ToList();
        }
    }
}
