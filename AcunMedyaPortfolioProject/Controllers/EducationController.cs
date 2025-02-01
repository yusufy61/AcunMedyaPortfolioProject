using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        PortfolioDBEntities1 db = new PortfolioDBEntities1();
        public ActionResult Index()
        {
            var educations = db.Educations.ToList();
            return View(educations);
        }

        public ActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEducation(Education education)
        {
            db.Educations.Add(education);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteEducation(int id)
        {
            var education = db.Educations.Find(id);
            db.Educations.Remove(education);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var education = db.Educations.Find(id);
            return View(education);
        }

        [HttpPost]
        public ActionResult UpdateEducation(Education education)
        {
            var educationUpdated = db.Educations.Find(education.id);
            educationUpdated.title = education.title;
            educationUpdated.institutionName = education.institutionName;
            educationUpdated.startdate = education.startdate;
            educationUpdated.enddate = education.enddate;
            educationUpdated.Description = education.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}