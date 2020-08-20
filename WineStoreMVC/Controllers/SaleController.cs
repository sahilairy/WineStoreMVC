using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineStoreMVC.Models;

namespace WineStoreMVC.Controllers
{
    public class SaleController : Controller
    {
        WineStoreEntities instance_MVC = new WineStoreEntities();

        // GET: Sale
        public ActionResult SaleDetail()
        {
            return View(instance_MVC.Sale_Data.ToList());
        }

        // GET: Sale/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sale/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sale/Create
        [HttpPost]
        public ActionResult Create(Sale_Data SaleData)
        {


            //following the concept of crud to register new employee
            if (!ModelState.IsValid)
                return View();
            instance_MVC.Sale_Data.Add(SaleData);
            instance_MVC.SaveChanges();

            return RedirectToAction("SaleDetail");
        }

        // GET: Sale/Edit/5
        public ActionResult Edit(int id)
        {
            //get the id and the pass to the funtion to update the record
            var SaleID = (from m in instance_MVC.Sale_Data where m.id == id select m).First();
            return View(SaleID);
        }

        // POST: Sale/Edit/5
        [HttpPost]
        public ActionResult Edit(Sale_Data saleData)
        {

            var orignalRecord = (from m in instance_MVC.Sale_Data where m.id == saleData.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance_MVC.Entry(orignalRecord).CurrentValues.SetValues(saleData);

            instance_MVC.SaveChanges();
            return RedirectToAction("SaleDetail");
        }

        // GET: Sale/Delete/5
        public ActionResult Delete(Sale_Data saleData)
        {

            var d = instance_MVC.Sale_Data.Where(x => x.id == saleData.id).FirstOrDefault();
            instance_MVC.Sale_Data.Remove(d);
            instance_MVC.SaveChanges();
            return RedirectToAction("SaleDetail");
        }

        // POST: Sale/Delete/5
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
