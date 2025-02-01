using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        PortfolioDBEntities1 db = new PortfolioDBEntities1();

        public ActionResult CategoryList()
        {

            var categoryList = db.Categories.ToList();
            return View(categoryList);
        }

        [HttpGet] // Create sayfasını açmak için
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost] //Yeni kayıt oluştır butonuna tıklamak için
        public ActionResult CreateCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public ActionResult DeleteCategory(int id)
        {
            var category = db.Categories.Find(id);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = db.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var UpdatedCategory = db.Categories.Find(category.Id);
            UpdatedCategory.Name = category.Name;
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}