using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Banking.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Banking.Controllers
{
    public class RegisterController : Controller
    {
        ProjectPayV7Entities db = new ProjectPayV7Entities();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegisterCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterCustomer( User obj)
                     {
                        db.Users.Add(obj);
                        db.SaveChanges();
                        return RedirectToAction("Index"); }
         }
    }

