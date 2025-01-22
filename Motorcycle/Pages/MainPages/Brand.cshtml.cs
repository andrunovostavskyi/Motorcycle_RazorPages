using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Motorcycle.Pages.MainPages
{
    public class BrendModel : PageModel
    {
        private readonly MotoContext _context;
        public List<Brend> Brends=new List<Brend>();
        public BrendModel(MotoContext context)
        {
            _context = context;    
        }
        public void OnGet()
        {
            Brends=_context.Brends.ToList();
        }

    }
}
