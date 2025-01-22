using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace Motorcycle.Pages.MainPages
{
    [Authorize(Roles ="Admin")]
    
    public class AllMotoModel : PageModel
    {
        private readonly MotoContext _context;

        public List<Moto> Motorcycles { get; set; } = new List<Moto>();
		public List<Brend> Brands { get; set; } = new List<Brend>();
        public List<Category> Categories { get; set; }=new List<Category>();

		[BindProperty]
        public Moto NewMoto { get; set; }

        public AllMotoModel(MotoContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Motorcycles = _context.Motorcycles.ToList();
            Brands=_context.Brends.ToList();   
            Categories=_context.Categories.ToList();
        }


        public IActionResult OnPostAdd()
        {
			NewMoto.BrendId = int.Parse(Request.Form["brendId"]);
            NewMoto.CategoryId = int.Parse(Request.Form["categoryId"]);
			_context.Motorcycles.Add(NewMoto);
            _context.SaveChanges();

            return RedirectToPage();
        }

        public IActionResult OnPostUpdate(int id)
        {
            Moto MotoForUpdate = _context.Motorcycles.Find(id);
            if (!StringValues.IsNullOrEmpty(Request.Form["model"]))
            {
                MotoForUpdate.Model = Request.Form["model"];
			}
			if (!StringValues.IsNullOrEmpty(Request.Form["description"]))
			{
				MotoForUpdate.Description = Request.Form["description"];
			}
			if (!StringValues.IsNullOrEmpty(Request.Form["price"]))
			{
				MotoForUpdate.Price = int.Parse(Request.Form["price"]);
			}
			if (!StringValues.IsNullOrEmpty(Request.Form["brendId"]))
			{
				MotoForUpdate.BrendId = int.Parse(Request.Form["brendId"]);
			}

			if (!StringValues.IsNullOrEmpty(Request.Form["categoryId"]))
			{
				MotoForUpdate.CategoryId = int.Parse(Request.Form["categoryId"]);
			}
			if (!StringValues.IsNullOrEmpty(Request.Form["image"]))
			{ 
				MotoForUpdate.Image = Request.Form["image"];
			}
			_context.SaveChanges();
			return RedirectToPage();
        }


        public IActionResult OnPostDelete(int id)
        {
            Moto motorcycleToDelete = _context.Motorcycles.Find(id);
            if (motorcycleToDelete != null)
            {
                _context.Motorcycles.Remove(motorcycleToDelete);

                _context.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}
