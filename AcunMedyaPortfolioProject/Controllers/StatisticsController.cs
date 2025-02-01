using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        PortfolioDBEntities1 db = new PortfolioDBEntities1();
        public ActionResult Index()
        {
            //istatistikler, tablolarımızdaki veri sayılarını alıyoruz

            var projects = db.Projects.Count();
            var experiences = db.Experiences.Count();
            var testimonials = db.Testimonials.Count();

            ViewData["projects"] = projects;
            ViewData["experiences"] = experiences;
            ViewData["testimonials"] = testimonials;

            return View();
        }
    }
}