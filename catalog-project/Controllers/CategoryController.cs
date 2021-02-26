using catalog_project.Data;
using catalog_project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog_project.Controllers
{
    public class CategoryController : Controller
    {



        private readonly ApplicationDbContext _db;


        private readonly ILogger<CategoryController> _logger;


        public CategoryController(ILogger<CategoryController> logger, ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;

        }
        [Authorize]
        public IActionResult Index()
        {

            IEnumerable<Category> categories = _db.Category;
            return View(categories);
            
        }



        [Authorize]
        //Get
        public IActionResult CreateCategory()
        {

            return View();
        }

        [Authorize]
        //Post  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(Category category)
        {

            if (ModelState.IsValid)
            {
                _db.Category.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);

        }

        [Authorize]
        public IActionResult EditCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Category.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(Category category)
        {

            if (ModelState.IsValid)
            {
                _db.Category.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);

        }


        [Authorize]

        public IActionResult DeleteCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Category.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategoryPost(int? id)
        {
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
