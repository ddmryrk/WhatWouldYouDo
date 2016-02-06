using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mv.Controllers
{
    public class UsersController : Controller
    {
        WWYDEntities ent = new WWYDEntities();
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewUser()
        {

            return View();
        }
        [HttpPost]
        public ActionResult NewUser(Users users)
        {

            ent.Users.Add(users);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}