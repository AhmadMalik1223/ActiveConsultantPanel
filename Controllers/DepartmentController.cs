using IlmdostPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IlmdostPanel.Controllers
{
    public class DepartmentController : Controller
    {
        ActiveConsultantEntities db = new ActiveConsultantEntities();
        // GET: Department
        public ActionResult Adddepartment()
        {
            try {
                if (@Session["usernamecshow"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }

                ViewBag.Companylist = db.Companies.ToList();
                Department dept = new Department();
                return View();
            }
            catch (Exception e) {
                return View();
            }
            
        }
        [HttpPost]
        public ActionResult Adddepartment(Department model)
        {
            try
            {
                if (@Session["usernamecshow"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                ViewBag.Companylist = db.Companies.ToList();
                Department dept = new Department();
           //     dept.department_id = model.department_id;
                dept.company_id = model.company_id;
                dept.department_title = model.department_title;
                db.Departments.Add(dept);
                db.SaveChanges();
                return RedirectToAction("Managedepartment");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Managedepartment()
        {
            if (@Session["usernamecshow"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var reg = db.Departments.ToList();
            return View(reg);
        }
        public ActionResult Editdepartment(int department_id)
        {
            try
            {
                ViewBag.Companylist = db.Companies.ToList();
                var departmentid = db.Departments.Find(department_id);
                return View(departmentid);
            }
            catch(Exception ex) 
            { 
                return View();
            }
        }
        [HttpPost]
        public ActionResult Editdepartment(Department model)
        {
            try
            {
                if (@Session["usernamecshow"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }

                ViewBag.Companylist = db.Companies.ToList();

                Department dept = new Department();
                dept.department_id = model.department_id;
               // dept.company_id = model.company_id;
                dept.department_title = model.department_title;

                db.Entry(dept).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Managedepartment");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Deletedepartment(int department_id)
        {
            try
            {
                var remdept = db.Departments.Find(department_id);
                db.Departments.Remove(remdept);
                db.SaveChanges();
                return RedirectToAction("Managedepartment");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}