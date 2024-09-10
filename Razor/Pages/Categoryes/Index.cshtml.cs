using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Data;
using Razor.Models;

namespace Razor.Pages.Categoryes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContextcs _db;

        public List<Category> Categoryeslist { set; get; }
        public IndexModel (ApplicationDbContextcs db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Categoryeslist = _db.Categories.ToList();
        }
    }
}
