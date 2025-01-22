using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Motorcycle.Pages.MainPages
{
    public class BrandMotorcyclesModel : PageModel
    {
        private readonly MotoContext _context;
        public List<Moto> MotorcyclesBrand=new List<Moto>();
        public BrandMotorcyclesModel(MotoContext context)
        {
            _context = context;    
        }
        public void OnGet(int id)
        {
            MotorcyclesBrand=_context.Motorcycles.
                Where(x => x.BrendId == id).ToList();
        }
    }
}
