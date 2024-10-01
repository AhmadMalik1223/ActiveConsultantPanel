using IlmdostPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IlmdostPanel.Controllers
{
    public class HomeController : Controller
    {
        JobPortalEntities db = new JobPortalEntities();
        // GET: Home
        public ActionResult Dashboard()
        {
            try
            {
               if(@Session["usernamecshow"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                ViewBag.RegisteredCompanies = db.Companies.Count();
                ViewBag.RegisteredJobs = db.Jobs.Count();
                ViewBag.ApplicantsApplied = db.Users.Count();
                ViewBag.ApplicantsHired = db.Users.Count();

                var reg = db.Users.ToList();
                return View(reg);
            }
            catch(Exception ex)
            {
                return View();
            }
           
        }
    }
}