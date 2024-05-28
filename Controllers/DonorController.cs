using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IlmdostPanel.Controllers
{
    public class DonorController : Controller
    {
        // GET: Donor
        public ActionResult Adddonor()
        {
            return View();
        }
        public ActionResult Managedonors()
        {
            return View();
        }
    }
}