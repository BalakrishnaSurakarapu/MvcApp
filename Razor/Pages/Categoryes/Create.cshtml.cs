using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Data;
using Razor.Models;

namespace Razor.Pages.Categoryes
{
  
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContextcs _db;
        [BindProperty]
        public Category Category { set; get; }
        public CreateModel(ApplicationDbContextcs db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            _db.Categories.Add(Category);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
           // return RedirectToPage("Index");
        
    }
}
