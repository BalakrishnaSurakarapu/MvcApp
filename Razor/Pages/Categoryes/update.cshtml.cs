using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Data;
using Razor.Models;

namespace Razor.Pages.Categoryes
{
    public class updateModel : PageModel
    {
        private readonly ApplicationDbContextcs _db;
        public Category Category { get; set; }

        public updateModel(ApplicationDbContextcs db, Category category)
        {
            _db = db;   
        }
        public void OnGet(int?id)
        {if(id==0 && id==null)
                Category = _db.Categories.Find(id);
        }
        public IActionResult OnPost() {
         Category? obj = _db.Categories.Find(Category.Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Update(obj);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
