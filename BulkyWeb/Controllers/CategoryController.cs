using Bulky.DataAccess;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _cateRepo;

        public CategoryController (ICategoryRepository db)
        {
            _cateRepo = db;
        }

        public IActionResult Index()
        {
            List<Category> lisCate = _cateRepo.GetAll().ToList(); 
            return View(lisCate);
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _cateRepo.Add(obj);
                _cateRepo.Save();
                TempData["success"] = "Category Created Succefully !! ";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit (int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            Category? cateDb = _cateRepo.Get(u => u.Id == id);

            if (cateDb == null)
            {
                return NotFound();
            }
            return View(cateDb);
        }

        [HttpPost]
        public IActionResult Edit (Category obj)
        {
            if (ModelState.IsValid)
            {
                _cateRepo.Update(obj);
                _cateRepo.Save();
                TempData["success"] = "Category Updated Successfully !";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete (int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category? cateDb = _cateRepo.Get(u => u.Id == id);
            if  (cateDb == null)
            {
                return NotFound();
            }

            return View(cateDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(Category obj)
        {
                _cateRepo.Remove(obj);
                _cateRepo.Save();
                TempData["error"] = "Category Deleted Successfull";
                return RedirectToAction("Index");
            return View();
        }
    }
}
