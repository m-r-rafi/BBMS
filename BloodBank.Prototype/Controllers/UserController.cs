using BloodBank.Prototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Prototype.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Donate()
        {
            return View();
        }
        public ActionResult DonateHistory()
        {
            return View();
        }
        public ActionResult Receive()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Receive(ReceiveTypeModel model)
        {
            return View(model);
        }
        public ActionResult ReceiveHistory()
        {
            return View();
        }
        
    }
}