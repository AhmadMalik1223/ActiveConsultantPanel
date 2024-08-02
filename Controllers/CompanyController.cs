using IlmdostPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IlmdostPanel.Controllers
{
    public class CompanyController : Controller
    {
        JobPortalEntities db = new JobPortalEntities();
        // GET: Donor
        public ActionResult Addcompany()
        {
            try
            {

                return View();
            }
            catch(Exception ex)
            {

                return View();
            }
        }
        [HttpPost]
        public ActionResult Addcompany(Company model)

        {
            try
            {
                Company company = new Company();
                company.company_name = model.company_name;
                company.company_registration = model.company_registration;
                company.company_address = model.company_address;
                company.company_email = model.company_email;
                company.company_contact = model.company_contact;
                company.company_owner = model.company_owner;
                company.company_about = model.company_about;
                db.Companies.Add(company);
                db.SaveChanges();

                return RedirectToAction("Managecompany");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        public ActionResult Managecompany()
        {
            return View();
        }
    }
}