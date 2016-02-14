using mv.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mv.Controllers
{
    public class UsersController : Controller
    {
        DataModel.Model1 ent = new DataModel.Model1();
        // GET: Users
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(DataModel.Users u)
        {
            var kullanici = (from item in ent.Users
                             where item.Email == u.Email && item.Password == u.Password
                             select item).FirstOrDefault();
            Session["KullaniciLogin"] = kullanici;
            return RedirectToAction("Index", "ProfilePage");
        }

    }
}