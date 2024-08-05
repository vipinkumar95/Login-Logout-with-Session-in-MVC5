using LoginMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginMVC.Controllers
{
    public class LoginController : Controller
    {
        MvcLoginEntities1 db = new MvcLoginEntities1();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(logindb logindb)
        {
            if (ModelState.IsValid) 
            {
                var data =  db.logindbs.Where(x => x.Username.Equals(logindb.Username) && x.password.Equals(logindb.password)).FirstOrDefault();
                if (data != null) 
                {
                    ViewBag.check = "Login Successfully";
                    Session["Username"] = logindb.Username;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.check = "Login Failed";
                }
            }

            return View();
        }

        public ActionResult Logout() 
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}