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
        public ActionResult Adduser()
        {
            return View();
        }
        public ActionResult Userlist()
        {
            return View();
        }
    }
}