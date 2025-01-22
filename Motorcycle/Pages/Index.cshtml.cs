using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Motorcycle.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MotoContext _context;
        public IndexModel(MotoContext context)
        {
            _context = context;
        }
        public List<Moto> Motorcycles = new List<Moto>();
        public void OnGet()
        {
            Motorcycles = _context.Motorcycles.ToList();
        }

    }
}