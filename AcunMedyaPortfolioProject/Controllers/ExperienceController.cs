using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        PortfolioDBEntities1 db = new PortfolioDBEntities1();
        public ActionResult Index()
        {
            var experiences = db.Experiences.ToList();
            return View(experiences);
        }

        public ActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateExperience(Experience experience)
        {
            db.Experiences.Add(experience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            var experience = db.Experiences.Find(id);
            db.Experiences.Remove(experience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateExperience(int id)
        {
            var experience = db.Experiences.Find(id);
            return View(experience);
        }

        [HttpPost]
        public ActionResult UpdateExperience(Experience experience)
        {
            var updatedExperience = db.Experiences.Find(experience.Id);

            updatedExperience.Title = experience.Title;
            updatedExperience.CompanyName = experience.CompanyName;
            updatedExperience.StartDate = experience.StartDate;
            updatedExperience.EndDate = experience.EndDate;
            updatedExperience.Description = experience.Description;
            db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}