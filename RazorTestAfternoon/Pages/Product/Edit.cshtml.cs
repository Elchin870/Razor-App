using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTestAfternoon.Data;

namespace RazorTestAfternoon.Pages.Product
{
	public class EditModel : PageModel
	{
		private readonly ProductDbContext _context;

		public EditModel(ProductDbContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Entities.Product Product { get; set; }
		public string Info { get; set; }

		public IActionResult OnGet(int id)
		{
			Product = _context.Products.FirstOrDefault(p => p.Id == id);

			if (Product == null)
			{
				return RedirectToPage("Index", new { info = "Product not found" });
			}
			return Page();
		}

		public IActionResult OnPost()
		{
			if (Product != null)
			{
				var editProduct = _context.Products.FirstOrDefault(p => p.Id == Product.Id);

				if (editProduct != null)
				{
					editProduct.Name = Product.Name;
					editProduct.Price = Product.Price;
					_context.SaveChanges();

					return RedirectToPage("Index", new { info = $"{Product.Name} updated successfully!" });
				}
			}
			return RedirectToPage("Index", new { info = "Product update failed" });
		}
	}
}
