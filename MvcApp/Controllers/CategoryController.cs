using Microsoft.AspNetCore.Mvc;
using MvcApp.Data;
using MvcApp;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
                List<Category> catagories = _db.Categories.ToList();
                return View(catagories);
        }

        // [HttpPost]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //custom Validations
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "the Displayordes can not exactly match the name");
            }
            if (ModelState.IsValid)
            {

                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category is Saved Successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryfromdb = _db.Categories.Find(id);//get data
            //Category categoryfromdb1 = _db.Categories.FirstOrDefault(u=>u.Id==id); //get data
            //Category categoryfromdb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault(); //get data
            if (categoryfromdb == null)
            {
                return NotFound();
            }
            return View(categoryfromdb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category is Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryfromdb = _db.Categories.Find(id);//get data
            //Category categoryfromdb1 = _db.Categories.FirstOrDefault(u=>u.Id==id); //get data
            //Category categoryfromdb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault(); //get data
            if (categoryfromdb == null)
            {
                return NotFound();
            }
            return View(categoryfromdb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? Obj = _db.Categories.Find(id);
            if (Obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(Obj);
            _db.SaveChanges();
            TempData["Success"] = "Category is Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}


