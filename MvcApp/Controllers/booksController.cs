using Microsoft.AspNetCore.Mvc;
using MvcApp.Data;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class booksController : Controller
    {
        private ApplicationDbContext _db;
        public booksController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Book> books = _db.Books.ToList();
            return View(books);
        }
        public IActionResult addbook()
        {
            return View();
        }


        [HttpPost]
        public IActionResult addbook(Book obj)
        {
            if (obj.Name == obj.Orders.ToString())
            {
                ModelState.AddModelError("name", "the Displayordes can not exactly match the name");
            }
            if (ModelState.IsValid)
            {

                _db.Books.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "book is Saved Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Book booksfromdb = _db.Books.Find(id);//get data
                                                  //Category categoryfromdb1 = _db.Categories.FirstOrDefault(u=>u.Id==id); //get data
                                                  //Category categoryfromdb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault(); //get data
            if (booksfromdb == null)
            {
                return NotFound();
            }
            return View(booksfromdb);
            //return View();
        }
        [HttpPost]
        public IActionResult Edit(Book obj)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category is Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Book booksfromd = _db.Books.Find(id);//get data
                                                 //Category categoryfromdb1 = _db.Categories.FirstOrDefault(u=>u.Id==id); //get data
                                                 //Category categoryfromdb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault(); //get data

            return View(booksfromd);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Book? Obj = _db.Books.Find(id);
            if (Obj == null)
            {
                return NotFound();
            }
            _db.Books.Remove(Obj);
            _db.SaveChanges();
            TempData["Success"] = "Book is Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
