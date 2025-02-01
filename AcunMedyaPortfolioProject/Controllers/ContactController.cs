using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;
using Microsoft.Ajax.Utilities;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        PortfolioDBEntities1 db = new PortfolioDBEntities1();
        public ActionResult Index()
        {
            var contacts = db.Contacts.ToList();
            return View(contacts);
        }

        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteContact(int id)
        {
            var contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var contact = db.Contacts.Find(id);

            return View(contact);
        }

        [HttpPost]
        public ActionResult UpdateContact(Contact contact)
        {
            var updatedContact = db.Contacts.Find(contact.Id);
            updatedContact.Phone = contact.Phone;
            updatedContact.MailAddress = contact.MailAddress;
            updatedContact.Address = contact.Address;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}