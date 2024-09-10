using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Data;
using Razor.Models;
namespace Razor.Pages.Categoryes
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContextcs _db;
        [BindProperty]
        public Category Category { set; get; }
        public EditModel(ApplicationDbContextcs db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if(id!=null && id != 0)
            {
                Category=_db.Categories.Find(id);
            }
        }
        public IActionResult OnUpdate(Category obj) {
            Console.WriteLine("haii", obj);
            _db.Categories.Update(obj);
            _db.SaveChanges();
            return RedirectToPage();
        }
    }
}
