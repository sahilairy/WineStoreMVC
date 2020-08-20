using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineStoreMVC.Models;

namespace WineStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        WineStoreEntities instance_MVC = new WineStoreEntities();

        public ActionResult AllMessages()
        {
            return View(instance_MVC.Contact_Data.ToList());
        }
        
        // GET: Employee/Delete/5
        public ActionResult Delete(Contact_Data ContactData)
        {
            var d = instance_MVC.Contact_Data.Where(x => x.ID == ContactData.ID).FirstOrDefault();
            instance_MVC.Contact_Data.Remove(d);
            instance_MVC.SaveChanges();
            return RedirectToAction("AllMessages");
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Confirmation()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }





        [HttpPost]
        public ActionResult SendMessage(feedBack Feed_Back)
        {

            //get the value from the user to pass in the database 



            String query = "insert into Contact_Data(Name,Email,Phone,Message) values('" + Feed_Back.txtName + "','" + Feed_Back.txtEmail + "','"+Feed_Back.txtNo+"','" + Feed_Back.txtMsg + "')";

            Feed_Back.AddMessage(query);

            return View("Confirmation");


        }


    }
}