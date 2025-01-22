using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Motorcycle.Pages.MainPages
{
    public class CategoryMotorcycliesModel : PageModel
    {
        private MotoContext _motoContext;
        public List<Moto> CategoriesMoto { get; set; }
        public CategoryMotorcycliesModel(MotoContext motocoatext)
        {
            _motoContext = motocoatext;
        }

        public void OnGet(int id)
        {
            CategoriesMoto= _motoContext.Motorcycles.Include(c=>c.Category).ToList().
                Where(x=>x.CategoryId==id).ToList();
        }
    }
}
