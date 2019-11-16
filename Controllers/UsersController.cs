using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Banking.Models;
namespace Banking.Controllers
{
    public class UsersController : Controller
    {
        ProjectPayV7Entities db = new ProjectPayV7Entities();
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(UserLoginVM obj)
        {
            if (ModelState.IsValid)
            {
                var res = (from s in db.Users
                           where s.UserName == obj.UserName
                           && s.UserPassword == obj.UserPassword
                           select s).SingleOrDefault();
                String uname = res.UserName;
                Session["User"] = uname;
                if (res != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Password...Pls re-type");
                    return View();
                }
            }
                else
              {
                ModelState.AddModelError("", "Invalid Email ID");
              }
            return View();

        }

        public bool UserExist(string UserName)
        {
            var res = (from s in db.Users
                       where s.UserName == UserName
                       select s).SingleOrDefault();
            if (res != null)
                return true;
            else
                return false;
        }
        public JsonResult IsUserExist(string UserName)
        {
            return UserExist(UserName) ?
                Json(true, JsonRequestBehavior.AllowGet)
                : Json(false, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult logoff()
        //{
        //    Session.Clear();
        //    Session.Abandon();
        //    return View();
        //}
        [HttpGet]
        public ActionResult ForgetPass(string id)
        {
            var obj = db.Users.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult ForgetPass(Class1 obj)
        {
           
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            //return View();
            //var res = (from s in db.Users
            //         where s.UserName == obj.UserName
            //        select s).SingleOrDefault();
            ////var obj = db.Users.Find(id);
            //var m = o.UserPassword;
            //obj.UserPassword = m;
            //db.Entry(o).State = EntityState.Modified;
            //db.SaveChanges();
            //return RedirectToAction("Index");

        }
        //[HttpPost]
        //public ActionResult ForgetPass(User o)
        //{
        //    //var k = db.User.Find(obj);
        //    //return View(obj);
        //    var res = (from s in db.Users
        //              where s.UserName == obj.UserName
        //              select s).SingleOrDefault();
        //    o.UserPassword = obj.UserPassword;
        //    db.Entry(res).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");

        //}
    }
}