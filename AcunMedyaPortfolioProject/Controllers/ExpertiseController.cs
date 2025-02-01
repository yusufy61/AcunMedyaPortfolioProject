using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class ExpertiseController : Controller
    {
        // GET: Expertise
        PortfolioDBEntities1 db = new PortfolioDBEntities1();
        public ActionResult Index()
        {
            var expertises = db.Expertises.ToList();
            return View(expertises);
        }

        public ActionResult CreateExpertise()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateExpertise(Expertise expertise)
        {
            db.Expertises.Add(expertise);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExpertise(int id)
        {
            var expertise = db.Expertises.Find(id);
            db.Expertises.Remove(expertise);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateExpertise(int id)
        {
            var expertise = db.Expertises.Find(id);
            return View(expertise);
        }

        [HttpPost]
        public ActionResult UpdateExpertise(Expertise expertise)
        {
            var updatedExpertise = db.Expertises.Find(expertise.id);
            updatedExpertise.Name = expertise.Name;
            updatedExpertise.Description = expertise.Description;
            updatedExpertise.isActive = expertise.isActive;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}