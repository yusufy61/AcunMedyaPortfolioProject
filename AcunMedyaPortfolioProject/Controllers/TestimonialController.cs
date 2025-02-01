using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        PortfolioDBEntities1 db = new PortfolioDBEntities1();

        [HttpGet]
        public ActionResult Index()
        {
            var testimonials = db.Testimonials.ToList();

            return View(testimonials);
        }

        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial testimonial)
        {
            db.Testimonials.Add(testimonial);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteTestimonial(int id)
        {
            var testimonial = db.Testimonials.Find(id);
            db.Testimonials.Remove(testimonial);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var testimonial = db.Testimonials.Find(id);

            return View(testimonial);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var updatedTestimonial = db.Testimonials.Find(testimonial.Id);

            updatedTestimonial.NameSurname = testimonial.NameSurname;
            updatedTestimonial.Title = testimonial.Title;
            updatedTestimonial.ImageUrl = testimonial.ImageUrl;
            updatedTestimonial.Comment = testimonial.Comment;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}