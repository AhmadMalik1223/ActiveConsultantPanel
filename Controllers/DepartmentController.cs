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
            //try
            //{
            //    var remdept = db.Departments.Find(department_id);
            //    db.Departments.Remove(remdept);
            //    db.SaveChanges();
            //    return RedirectToAction("Managedepartment");
            //}
            //catch (Exception ex)
            //{
            //    return View();
            //}
            try
            {
                // Check if the company has related departments or jobs
                var hasJobs = db.Jobs.Any(d => d.department_id == department_id);
                //var hasJobs = db.Jobs.Any(j => j.company_id == company_id);

                //if (hasDepartments || hasJobs)
                //{
                //    ViewBag.Error = "Unable to delete company as it has related departments or jobs.";
                //    return RedirectToAction("ManageCompany");
                //}

                var deldepartment = db.Departments.Find(department_id);
                if (deldepartment != null)
                {
                    db.Departments.Remove(deldepartment);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Department deleted successfully.";
                    // ViewBag.DeptMsg = "Department deleted successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Department not found.";
                    // ViewBag.DeptMsg = "Department not found.";
                }

                return RedirectToAction("Managedepartment");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while trying to delete the department. Please try again.";
                // ViewBag.DeptMsg = "An error occurred while trying to delete the company. Please try again.";
                return RedirectToAction("Managedepartment");
            }
        }
    }
}