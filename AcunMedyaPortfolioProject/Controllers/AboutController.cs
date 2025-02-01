using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;
using Antlr.Runtime.Tree;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        PortfolioDBEntities1 db = new PortfolioDBEntities1();
        public ActionResult Index()
        {
            var abouts = db.Abouts.ToList();
            return View(abouts);
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(About about)
        {
            db.Abouts.Add(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var about = db.Abouts.Find(id);
            db.Abouts.Remove(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var about = db.Abouts.Find(id);
            return View(about);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var updated_About = db.Abouts.Find(about.Id);
            updated_About.Title = about.Title;
            updated_About.Description = about.Description;
            updated_About.ImageUrl = about.ImageUrl;
            updated_About.CVLink = about.CVLink;
            db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}