using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace Motorcycle.Pages.MainPages
{
    [Authorize(Roles = "Admin")]
    public class RESTBrendModel : PageModel
	{
        private readonly MotoContext _context;
		public RESTBrendModel(MotoContext context)
		{
			_context = context;
		}
		public List<Brend> Brends { get; set; } = new List<Brend>();



		public void OnGet()
		{
            if (User.IsInRole("Admin"))
            {
                Brends = _context.Brends.Include(b => b.Motorcyclies).ToList();
            }
		}

		public IActionResult OnPostAdd()
		{
			Brend newBrend = new Brend
			{
				Name = Request.Form["name"]!,
				History = Request.Form["history"],
				Image = Request.Form["image"]
			};

			string motorcycleIdsInput = Request.Form["motorcyclies"]!;
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
				newBrend.Motorcyclies = _context.Motorcycles
					.Where(m => validMotorcycleIds.Contains(m.Id))
					.ToList();
			}
			else
			{
				newBrend.Motorcyclies = new List<Moto>();
			}

			_context.Brends.Add(newBrend);

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


		public IActionResult OnPostUpdate(int id)
		{
			Brend brendToUpdate = _context.Brends.Find(id)!;
			if (brendToUpdate == null)
			{
				return RedirectToPage("/Error");
			}
			if (!StringValues.IsNullOrEmpty(Request.Form["history"]))
			{
				brendToUpdate.Name = Request.Form["name"]!;
			}
			if (!StringValues.IsNullOrEmpty(Request.Form["history"]))
			{
				brendToUpdate.History = Request.Form["history"];
			}
			if (!StringValues.IsNullOrEmpty(Request.Form["motorcyclies"]))
			{
				string motorcyclesInput = Request.Form["motorcyclies"]!;
				string[] motorcyclesId = motorcyclesInput.Split(',');
				brendToUpdate.Motorcyclies = _context.Motorcycles
					.Where(m => motorcyclesId.Contains(m.Id.ToString())).ToList();
			}
			if (!StringValues.IsNullOrEmpty(Request.Form["image"]))
			{
				brendToUpdate.Image = Request.Form["image"];
			}
			_context.SaveChanges();
			return RedirectToPage();
		}

		public IActionResult OnPostDelete(int id)
		{
			Brend brendToRemove = _context.Brends.Find(id)!;
			if (brendToRemove == null)
			{
				return RedirectToPage("/Error");
			}
			else
			{
				_context.Brends.Remove(brendToRemove);
				_context.SaveChanges();
				return RedirectToPage();
			}
		}

	}
}
