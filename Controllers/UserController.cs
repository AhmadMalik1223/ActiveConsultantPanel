using IlmdostPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IlmdostPanel.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        ActiveConsultantEntities db = new ActiveConsultantEntities();
        public ActionResult Adduser()
        {
            if (@Session["usernamecshow"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        public ActionResult Userlist()
        {
            if (@Session["usernamecshow"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}