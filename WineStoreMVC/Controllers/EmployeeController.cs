using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineStoreMVC.Models;

namespace WineStoreMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        WineStoreEntities instance_MVC = new WineStoreEntities();


        public ActionResult AllEmployee()
        {
            return View(instance_MVC.Employee_Table.ToList());
        }

        public ActionResult Team()
        {
            return View(instance_MVC.Employee_Table.ToList());
        }


        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee_Table employee_Data)
        {
            //following the concept of crud to register new employee
            if (!ModelState.IsValid)
                return View();
            instance_MVC.Employee_Table.Add(employee_Data);
            instance_MVC.SaveChanges();

            return RedirectToAction("AllEmployee");


        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            //get the id and the pass to the funtion to update the record
            var EmployeeID= (from m in instance_MVC.Employee_Table where m.id == id select m).First();
            return View(EmployeeID);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee_Table employeeID)
        {
            var orignalRecord = (from m in instance_MVC.Employee_Table where m.id == employeeID.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance_MVC.Entry(orignalRecord).CurrentValues.SetValues(employeeID);

            instance_MVC.SaveChanges();
            return RedirectToAction("AllEmployee");
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(Employee_Table employeeID)
        {
            var d = instance_MVC.Employee_Table.Where(x => x.id == employeeID.id).FirstOrDefault();
            instance_MVC.Employee_Table.Remove(d);
            instance_MVC.SaveChanges();
            return RedirectToAction("AllEmployee");
        }



        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
