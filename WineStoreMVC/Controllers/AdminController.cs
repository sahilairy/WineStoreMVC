using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineStoreMVC.Models;

namespace WineStoreMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Login_Admin()
        {
            return View();
        }

        // GET: Admin
        public ActionResult AdminBlock()
        {
            return View();
        }

        // GET: Admin
        public ActionResult InvalidBlock()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Match_Login(AdminBlockLogin Login_Block)
        {
            //generate the query to check the user name or passwod
            String qry = "select * from Admin_Login where User_Name='" + Login_Block.txtUserName + "' and User_Password='" + Login_Block.txtUserPassword + "'";
            DataTable tbl = new DataTable();
            tbl = Login_Block.verify_Login(qry);
              if (tbl.Rows.Count > 0)
              {
                  return View("AdminBlock");
              }
              else {
                  return View("InvalidBlock");
              }
            

        }
    }
}