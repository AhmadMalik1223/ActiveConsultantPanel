using IlmdostPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IlmdostPanel.Controllers
{
    public class AccountController : Controller
    {
        JobPortalEntities db = new JobPortalEntities();


        // GET: Account
        public ActionResult Login()
        {
            try
            {
                Admin us = new Admin();
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Login(string user, string pass, Admin model)
        {
            try
            {
                Admin us = new Admin();
                var result = db.Admins.Where(x=>x.username == model.username && x.password == model.password);
                var username = db.Admins.FirstOrDefault(x=>x.username == model.username);
                ViewBag.Username = username;
                if(result.Count() != 0 )
                {
                    Session["usernamecshow"] = result.FirstOrDefault().username;

                    FormsAuthentication.SetAuthCookie(model.username, false);

                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    ViewBag.Errorlogin = "Please enter valid username & password";
                    return View();
                }
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            return View();
        }
       
        public ActionResult Forgetpassword()
        {
            return View();
        }
    }
}