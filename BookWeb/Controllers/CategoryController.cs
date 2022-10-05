using BookWeb.Data;
using BookWeb.Models;
using Microsoft.AspNetCore.Mvc;

//this is the controller for categories.
namespace BookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        ////////////controller Index///////////////////////////////
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        //To use Http POST request.
        //The ValidateAntiForgeryToken attribute is used to prevent cross-site request forgery attacks
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The Display Order cannot exatly match the name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Created successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //edit && edit.....//////////////////////////////Edit///////////////////////////////////
        //GET
        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.Categories.Find(id);
            //var CategoryFromDbFirst = _db.Categories.FirstOrDefault(x => x.Id == id);
            //var categoryFromSingle= _db.Categories.SingleOrDefault(x => x.Id == id);

            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        //POST


        
        [HttpPost]
        //To use Http POST request.
        //The ValidateAntiForgeryToken attribute is used to prevent cross-site request forgery attacks
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The Display Order cannot exatly match the name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["update"] = "Updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        /////////////////////////////////Delete///////////////////////////////////////
        //GET
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.Categories.Find(id);
            //var CategoryFromDbFirst = _db.Categories.FirstOrDefault(x => x.Id == id);
            //var categoryFromSingle= _db.Categories.SingleOrDefault(x => x.Id == id);

            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        //We can use [ActionName("Delete")]

        [HttpPost]
        [ValidateAntiForgeryToken]

        //POST
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["remove"] = "Deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
