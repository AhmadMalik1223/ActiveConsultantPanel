using IlmdostPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IlmdostPanel.Controllers
{
    public class ApplicantController : Controller
    {
        JobPortalEntities db = new JobPortalEntities();
        // GET: Student
        public ActionResult Createapplicant()
        {
            return View();
        }
        public ActionResult Applicantlist()
        {
            try
            {
                if (@Session["usernamecshow"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                var reg = db.Users.ToList();
                return View(reg);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}