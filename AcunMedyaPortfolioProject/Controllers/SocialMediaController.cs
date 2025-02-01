﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        PortfolioDBEntities1 db = new PortfolioDBEntities1();
        public ActionResult Index()
        {
            var socialMedias = db.SocialMedias.ToList();
            return View(socialMedias);
        }

        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            db.SocialMedias.Add(socialMedia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var socialMedia = db.SocialMedias.Find(id);
            db.SocialMedias.Remove(socialMedia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateSocialMedia(int id)
        {
            var socialMedia = db.SocialMedias.Find(id);
            return View(socialMedia);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var socialMediaToUpdate = db.SocialMedias.Find(socialMedia.id);
            socialMediaToUpdate.platform_Name = socialMedia.platform_Name;
            socialMediaToUpdate.platform_URL = socialMedia.platform_URL;
            socialMediaToUpdate.platform_username = socialMedia.platform_username;
            socialMediaToUpdate.image_url = socialMedia.image_url;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}