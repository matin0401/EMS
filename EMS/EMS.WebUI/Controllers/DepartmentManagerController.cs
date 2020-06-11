using EMS.Core.Contracts;
using EMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.WebUI.Controllers
{
    public class DepartmentManagerController : Controller
    {
        // GET: DepartmentManager
        IRepository<Department> deptContext;

        public DepartmentManagerController(IRepository<Department> deptContext)
        {
            this.deptContext = deptContext;
        }

        public ActionResult Index()
        {
            List<Department> departments = deptContext.Collection().ToList();
            return View(departments);
        }

        public ActionResult Create()
        {
            Department dept = new Department();
            return View(dept);
        }


        [HttpPost]
        public ActionResult Create(Department dept)
        {
            if (ModelState.IsValid)
            {
                deptContext.Insert(dept);
                deptContext.Commit();

                return RedirectToAction("Index");
            }
            else
            {
                return View(dept);
            }
        }

        public ActionResult Edit(string Id)
        {
            Department dept = deptContext.Find(Id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(dept);
            }
        }

        [HttpPost]

        public ActionResult Edit(Department dept, string Id)
        {
            Department deptToEdit = deptContext.Find(Id);
            if (deptToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    deptToEdit.Name = dept.Name;
                    deptContext.Commit();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(dept);
                }
            }
        }

        public ActionResult Delete(string Id)
        {
            Department deptToDelete = deptContext.Find(Id);
            if (deptToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(deptToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Department deptToDelete = deptContext.Find(Id);
            if (deptToDelete != null)
            {
                deptContext.Delete(Id);
                deptContext.Commit();

                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}