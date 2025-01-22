using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace Motorcycle.Pages.MainPages
{
    public class RESTCategoryModel : PageModel
    {
        private readonly MotoContext _context;
        public RESTCategoryModel(MotoContext context)
        {
            _context = context;
        }
        public List<Category> Categories { get; set; }=new List<Category>();
        public void OnGet()
        {
			Categories = _context.Categories
				.Include(c => c.Motorcyclies).ToList();
		}

        public IActionResult OnPostAdd()
        {
			Category newCategory = new Category
			{
				Name = Request.Form["name"],
				Description = Request.Form["description"]
			};

			string motorcycleIdsInput = Request.Form["motorcyclies"];
			if (!string.IsNullOrEmpty(motorcycleIdsInput))
			{
				string[] motorcycleIds = motorcycleIdsInput.Split(',');

				// Validate and convert motorcycle IDs to integers
				List<int> validMotorcycleIds = new List<int>();
				foreach (var motorcycleId in motorcycleIds)
				{
					if (int.TryParse(motorcycleId, out int parsedId))
					{
						validMotorcycleIds.Add(parsedId);
					}
				}

				// Retrieve motorcycles from the database
				newCategory.Motorcyclies = _context.Motorcycles
					.Where(m => validMotorcycleIds.Contains(m.Id))
					.ToList();
			}
			else
			{
				newCategory.Motorcyclies = new List<Moto>();
			}

			_context.Categories.Add(newCategory);

			try
			{
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				return BadRequest("An error occurred while adding the brand.");
			}

			return RedirectToPage();
		}

        public IActionResult OnPostDelete(int id)
        {
            Category categorytoRemove = _context.Categories.Find(id);
            _context.Categories.Remove(categorytoRemove);
            _context.SaveChanges();
            return RedirectToPage();
        }

        public IActionResult OnPostUpdate(int id)
        {
            Category categoryToUpdate = _context.Categories.Find(id);
            if (!string.IsNullOrEmpty(Request.Form["name"]))
            {
                categoryToUpdate.Name = Request.Form["name"];
            }
            if (!string.IsNullOrEmpty(Request.Form["description"]))
            {
                categoryToUpdate.Description = Request.Form["description"];
            }
            if (!StringValues.IsNullOrEmpty(Request.Form["motorcyclies"]))
            {
                string motorcyclesInput = Request.Form["motorcyclies"];
                string[] motorcyclesId = motorcyclesInput.Split(',');
                categoryToUpdate.Motorcyclies = _context.Motorcycles
                    .Where(m => motorcyclesId.Contains(m.Id.ToString())).ToList();
            }
			_context.SaveChanges();
            return RedirectToPage();
        }
    }
}
