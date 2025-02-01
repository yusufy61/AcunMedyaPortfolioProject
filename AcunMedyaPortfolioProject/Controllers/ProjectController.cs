using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        PortfolioDBEntities1 db = new PortfolioDBEntities1();

        public ActionResult Index()
        {
            var projects = db.Projects.ToList();

            return View(projects);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            var categories = db.Categories.ToList();
            var List = new SelectList(categories,"Id","Name");
            ViewBag.Categories = List;
            //ViewData["Categories"] = List;
            //TempData["Categories"] = db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id)
        {
            var project = db.Projects.Find(id);
            if (project == null)
            {
                return View("Error");
            }
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var project = db.Projects.Find(id);
            var categories = db.Categories.ToList();
            var list = new SelectList(categories,"Id","Name",project.CategoryId);
            ViewBag.Categories = list;
            
            return View(project);
        }

        public ActionResult UpdateProject(Project project)
        {
            var updated_Project = db.Projects.Find(project.Id);
            updated_Project.Name = project.Name;
            updated_Project.CategoryId = project.CategoryId;
            updated_Project.CoverImageUrl = project.CoverImageUrl;
            updated_Project.Description = project.Description;
            updated_Project.ProjectLink = project.ProjectLink;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}