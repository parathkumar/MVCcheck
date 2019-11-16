using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webhi2.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace webhi2.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            var res = db.Customers.OrderByDescending(c => c.ContactName);
            return View(res);
            //return View(db.Customers.ToList());
        }
        #region Details
        public ActionResult Details(string id)
        {
            var res = db.Customers.Find(id);
            return View(res);
        }
        #endregion Details
        public string Hello()
        {
            return "You have requested to Create a New Customer";
        }
        #region create
        [HttpGet]
        public ActionResult AddNew()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddNew(Customer obj)
        {
            if (ModelState.IsValid)
            {
                //try
                //{
                if (obj.CustomerID.Length == 5)
                {
                    db.Customers.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "invalids";
                    ModelState.AddModelError("CustomerId", "Invalid Customer Id");
                    return View();
                }
                //    }
                //    catch (Exception e)
                //    {
                //        ModelState.AddModelError("msg", e.Message);
                //        ViewBag.Error = e.Message;
                //    }
                //    return View();
            }
            return View();
        }
        #endregion 
        #region EditCustomer
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var obj = db.Customers.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(Customer obj)
        {
            try
            {
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException e)
            {
                ModelState.AddModelError("", "Sorry...We faced an Unexpected Error...\n" + e.Message);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Sorry...We faced an Unexpected Error for databae...\n" + e.Message);
            }
            return View();
        }

        #endregion EditCustomer

       
        public ActionResult Delete(string id)
        {
            try { 
            var obj = db.Customers.Find(id);
            
                db.Customers.Remove(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "for databae...\n" + e.Message);
            }
            return View();
         
        }
    }
}
