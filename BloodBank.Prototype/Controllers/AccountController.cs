using BloodBank.Prototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Prototype.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            SignUpModel model = new SignUpModel();
            return View(model);
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult EditProfile()
        {
            return View();
        }
        public ActionResult EditPassword()
        {
            return View();
        }
    }
}