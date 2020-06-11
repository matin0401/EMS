using EMS.Core.Contracts;
using EMS.Core.Models;
using EMS.Core.VIewModels;
using EMS.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.WebUI.Controllers
{
    public class EmployeeManagerController : Controller
    {
        private readonly IRepository<Employee> _empContext;
        private readonly IRepository<Department> _deptContext;

        public EmployeeManagerController(IRepository<Employee> empContext, IRepository<Department> deptContext)
        {
            this._empContext = empContext;
            this._deptContext = deptContext;
        }

        public ActionResult Index()
        {
            List<Employee> employees = _empContext.Collection().ToList();
            return View(employees);
        }

        public ActionResult Create()
        {
            EmployeeViewModel model = new EmployeeViewModel();
            model.Employee = new Employee();
            model.Department = _deptContext.Collection();

            return View(model);

        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel emp)
        {
            if (ModelState.IsValid)
            {
                _empContext.Insert(emp.Employee);
                _empContext.Commit();

                return RedirectToAction("Index");
            }
            else
            {
                emp.Department = _deptContext.Collection();
                return View(emp);
            }
        }

        public ActionResult Edit(string Id)
        {
            Employee emp = _empContext.Find(Id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            else
            {
                EmployeeViewModel empModel = new EmployeeViewModel();
                empModel.Employee = emp;
                empModel.Department = _deptContext.Collection();

                return View(empModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Employee employee, string Id)
        {
            Employee empToEdit = _empContext.Find(Id);
            if (empToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    empToEdit.Fname = employee.Fname;
                    empToEdit.Lname = employee.Lname;
                    empToEdit.Email = employee.Email;
                    empToEdit.MobileNo = employee.MobileNo;
                    empToEdit.Department = employee.Department;
                    empToEdit.Image = employee.Image;
                    empToEdit.City = employee.City;

                    _empContext.Commit();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(employee);
                }
            }
        }
        public ActionResult Delete(string Id)
        {
            Employee empToDelete = _empContext.Find(Id);
            if (empToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(empToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Employee empToDelete = _empContext.Find(Id);
            if (empToDelete != null)
            {
                _empContext.Delete(Id);
                _empContext.Commit();

                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}