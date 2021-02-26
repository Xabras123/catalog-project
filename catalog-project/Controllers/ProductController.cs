using catalog_project.Data;
using catalog_project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog_project.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _db;

        private readonly ILogger<ProductController> _logger;


        public ProductController(ILogger<ProductController> logger, ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;

        }
        [Authorize]
        public IActionResult Index()
        {
            CatalogFrontData viewData = new CatalogFrontData();
            viewData.categories =  _db.Category;
            viewData.products = _db.Product;
            return View(viewData);
        }
        [Authorize]
        //Get
        public IActionResult CreateProduct()
        {

            //IEnumerable<Category> categories = _db.Category;
            ViewBag.Types = new SelectList(_db.Category.ToList(), "id", "name", "0");
            return View();
        }
        [Authorize]
        //Post  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(Product product)
        {

            if (ModelState.IsValid)
            {
                product.creationDate = DateTime.Now;
                _db.Product.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);

        }

        [Authorize]
        public IActionResult EditProduct(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Product.Find(id);

            if(obj == null)
            {
                return NotFound();
            }
            ViewBag.Types = new SelectList(_db.Category.ToList(), "id", "name", "0");
            return View(obj);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(Product product)
        {

            if (ModelState.IsValid)
            {
                _db.Product.Update(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);

        }



        [Authorize]
        public IActionResult DeleteProduct(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Product.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            ViewBag.Types = new SelectList(_db.Category.ToList(), "id", "name", "0");
            return View(obj);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProductPost(int? id)
        {
            var obj = _db.Product.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Product.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
