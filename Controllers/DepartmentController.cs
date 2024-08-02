using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IlmdostPanel.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Adddepartment()
        {
            return View();
        }
        public ActionResult Managedepartment()
        {
            return View();
        }
    }
}