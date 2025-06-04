using Bulky.DataAccess;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Category> lisCate = _unitOfWork.Category.GetAll().ToList(); 
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
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

            Category? cateDb = _unitOfWork.Category.Get(u => u.Id == id);

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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
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
            Category? cateDb = _unitOfWork.Category.Get(u => u.Id == id);
            if  (cateDb == null)
            {
                return NotFound();
            }

            return View(cateDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(Category obj)
        {
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["error"] = "Category Deleted Successfull";
            return RedirectToAction("Index");
        }
    }
}
