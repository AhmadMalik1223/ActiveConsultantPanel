using IlmdostPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IlmdostPanel.Controllers
{
    public class JobController : Controller
    {
        JobPortalEntities db = new JobPortalEntities();
        // GET: Job
        public ActionResult Addjob()
        {
            try {
                if (@Session["usernamecshow"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                Job job = new Job();    
                ViewBag.Companylist= db.Companies.ToList();
                ViewBag.Departmentlist= db.Departments.ToList();
                return View();
            }
            catch (Exception ex) { 
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Addjob(Job model)
        {
            try
            {
                if (@Session["usernamecshow"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                ViewBag.Companylist = db.Companies.ToList();
                ViewBag.Departmentlist = db.Departments.ToList();
                Job job = new Job();
                job.company_id = model.company_id;
                job.department_id = model.department_id;
                job.job_title = model.job_title;
                job.start_time  = model.start_time; 
                job.end_time = model.end_time;
                job.job_description = model.job_description;
                job.created_at = DateTime.Now;
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Managejob");
            }
            catch (Exception ex)
            {
                ViewBag.Companylist = db.Companies.ToList();
                ViewBag.Departmentlist = db.Departments.ToList();
                return View();
            }
        }
        public ActionResult Managejob()
        {
            if (@Session["usernamecshow"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var reg = db.Jobs.ToList();
            return View(reg);
        }
        public ActionResult Editjob(int job_id)
        {
            try
            {
                if (@Session["usernamecshow"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                Job job = new Job();
                ViewBag.Companylist = db.Companies.ToList();
                ViewBag.Departmentlist = db.Departments.ToList();
                var jobget = db.Jobs.Find(job_id);
                return View(jobget);
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Editjob(Job model)
        {
            try
            {
                if (@Session["usernamecshow"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                ViewBag.Companylist = db.Companies.ToList();
                ViewBag.Departmentlist = db.Departments.ToList();
                Job job = new Job();
                job.job_id = model.job_id;
                job.company_id = model.company_id;
                job.department_id = model.department_id;
                job.job_title = model.job_title;
                job.start_time = model.start_time;
                job.end_time = model.end_time;
                job.job_description = model.job_description;
                job.created_at = DateTime.Now;
                db.Entry(job).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Managejob");
            }
            catch (Exception ex)
            {
                ViewBag.Companylist = db.Companies.ToList();
                ViewBag.Departmentlist = db.Departments.ToList();
                return View();
            }
        }
        public ActionResult Delete(int job_id) 
        {
            try
            {
                var remdept = db.Jobs.Find(job_id);
                db.Jobs.Remove(remdept);
                db.SaveChanges();
                return RedirectToAction("Managejob");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

    }
}