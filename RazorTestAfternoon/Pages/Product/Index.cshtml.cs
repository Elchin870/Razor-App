using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTestAfternoon.Data;

namespace RazorTestAfternoon.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly ProductDbContext _context;

        public IndexModel(ProductDbContext context)
        {
            _context = context;
        }

        public List<Entities.Product> Products { get; set; }
        [BindProperty]
        public Entities.Product Product { get; set; }

        public string Message { get; set; }
        public string Info { get; set; }
        public void OnGet(string info="")
        {
            Message = "Hello My Students";
            Products = _context.Products.ToList();
            Info = info;
        }

        public IActionResult OnPost()
        {
            if(Product != null)
            {
                _context.Products.Add(Product);
                _context.SaveChanges();
                Info = $"{Product.Name} added successfully";
                return RedirectToPage("Index", new { info = Info });
            }
            return RedirectToPage("Index", new { info = "Data is empty" });
        }

		public IActionResult OnPostDelete(int id)
		{
			var product = _context.Products.Find(id);
			if (product != null)
			{
				_context.Products.Remove(product);
				_context.SaveChanges();
				Info = $"{product.Name} deleted successfully";
			}
			else
			{
				Info = "Product not found";
			}

			return RedirectToPage("Index", new { info = Info });
		}         

    }
}
