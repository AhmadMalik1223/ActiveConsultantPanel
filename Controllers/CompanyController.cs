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
        ActiveConsultantEntities db = new ActiveConsultantEntities();
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
                company.created_at = DateTime.Now;
                company.company_status = true;
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
            var reg = db.Companies.ToList();
            return View(reg);
        }
        public ActionResult Editcompany(int company_id)
        {
            try
            {
                var compnyid = db.Companies.Find(company_id);
                return View(compnyid);
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Editcompany(Company model)
        {
            try
            {
                Company company = new Company();
                company.company_id = model.company_id;
                company.company_name = model.company_name;
                company.company_registration = model.company_registration;
                company.company_address = model.company_address;
                company.company_email = model.company_email;
                company.company_contact = model.company_contact;
                company.company_owner = model.company_owner;
                company.company_about = model.company_about;
                company.created_at = DateTime.Now;
                company.company_status = true;

                db.Entry(company).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Managecompany");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Deletecompany(int company_id) 
        {
            try
             {
                var delcompany = db.Companies.Find(company_id);
                db.Companies.Remove(delcompany);
                db.SaveChanges();
                return RedirectToAction("Managecompany");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}