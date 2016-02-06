using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mv.Controllers
{
    public class UsersController : Controller
    {
        DataModel.Model1 du = new DataModel.Model1();
        // GET: Users
        public ActionResult Index()
        {
            du.SaveChanges();
            return View();
        }
        
    }
}