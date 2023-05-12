using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Prototype.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult UserManagement()
        {
            return View();
        }
        public ActionResult DonateRequests()
        {
            return View();
        }
        public ActionResult ReceiveRequests()
        {
            return View();
        }
    }
}