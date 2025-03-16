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
        ActiveConsultantEntities db = new ActiveConsultantEntities();
        // GET: Home
        public ActionResult Dashboard()
        {
            try
            {
               if(@Session["usernamecshow"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                var reg = db.Users.ToList();
                if (reg == null || !reg.Any())
                {
                    ViewBag.Message = "No records found.";
                    return View(new List<User>());
                }
                ViewBag.RegisteredCompanies = db.Companies.Count();
                ViewBag.RegisteredJobs = db.Jobs.Count();
                ViewBag.ApplicantsApplied = db.Users.Count();
                ViewBag.ApplicantsHired = db.Users.Where(x => (bool)(x.status == true)).Count();

               
                return View(reg);
            }
            catch(Exception ex)
            {
                return View();
            }
           
        }
    }
}