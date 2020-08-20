using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineStoreMVC.Models;

namespace WineStoreMVC.Controllers
{
    public class PurchaseController : Controller
    {
        WineStoreEntities instance_MVC = new WineStoreEntities();

        // GET: Purchase


        public ActionResult PurchaseDetail()
        {
            return View(instance_MVC.Purchase_Data.ToList());
        }

        // GET: Purchase/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Purchase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Purchase/Create
        [HttpPost]
        public ActionResult Create(Purchase_Data PurchaseData)
        {
            //following the concept of crud to register new employee
            if (!ModelState.IsValid)
                return View();
            instance_MVC.Purchase_Data.Add(PurchaseData);
            instance_MVC.SaveChanges();

            return RedirectToAction("PurchaseDetail");
        }

        // GET: Purchase/Edit/5
        public ActionResult Edit(int id)
        {
            //get the id and the pass to the funtion to update the record
            var PurchaseID = (from m in instance_MVC.Purchase_Data where m.id == id select m).First();
            return View(PurchaseID);
        }

        // POST: Purchase/Edit/5
        [HttpPost]
        public ActionResult Edit(Purchase_Data purchaseData)
        {

            var orignalRecord = (from m in instance_MVC.Purchase_Data where m.id == purchaseData.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance_MVC.Entry(orignalRecord).CurrentValues.SetValues(purchaseData);

            instance_MVC.SaveChanges();
            return RedirectToAction("PurchaseDetail");

        }

        // GET: Purchase/Delete/5
        public ActionResult Delete(Purchase_Data PurchaseData)
        {
            var d = instance_MVC.Purchase_Data.Where(x => x.id == PurchaseData.id).FirstOrDefault();
            instance_MVC.Purchase_Data.Remove(d);
            instance_MVC.SaveChanges();
            return RedirectToAction("PurchaseDetail");
            
        }

        // POST: Purchase/Delete/5
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
