using mv.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mv.Controllers
{
    public class ProfilePageController : Controller
    {
        // GET: ProfilePage
        Model1 ent = new Model1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(int ID = 6)
        {
            var kullanici = (from item in ent.Users
                             where item.ID == ID
                             select item).ToList();


            return PartialView(kullanici);
        }


        public ActionResult Friends()
        {
            //ession["UserID"] = 1;
            var friends = (from f in ent.UserRelationShips
                           where f.UserID1 ==1 && f.Status == 2
                           select f.UserID2).ToList();
            List<Users> friendDetails = new List<Users>();
            foreach (var item in friends)
            {
                friendDetails.Add((from fd in ent.Users where fd.ID == item select fd).FirstOrDefault());
            }
            return PartialView(friendDetails);
        }
    }
}