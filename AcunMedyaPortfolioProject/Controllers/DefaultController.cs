using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        PortfolioDBEntities1 db = new PortfolioDBEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialSiteHeader()
        {
            return PartialView();
        }

        public PartialViewResult PartialIntro()
        {
            var intro = db.Introductions.FirstOrDefault();
            return PartialView(intro);
        }
        public PartialViewResult PartialAbout()
        {
            var about = db.Abouts.FirstOrDefault();
            return PartialView(about);
        }
        public PartialViewResult PartialExperience()
        {
            var experiences = db.Experiences.ToList();
            return PartialView(experiences);
        }
        public PartialViewResult PartialEducation()
        {
            var educations = db.Educations.ToList();
            return PartialView(educations);
        }
        public PartialViewResult PartialProject()
        {
            var projects = db.Projects.ToList();
            return PartialView(projects);
        }
        public PartialViewResult PartialTestimonial()
        {
            var testimonials = db.Testimonials.ToList();
            return PartialView(testimonials);
        }
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }
    }
}