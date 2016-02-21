﻿using mv.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

        public ActionResult About(Int64 uid)
        {
            if (uid.Equals(null))
            {
                uid = Convert.ToInt64(Request.Cookies["userID"].Value);
            }

            var kullanici = (from item in ent.Users
                             where item.ID == uid
                             select item).FirstOrDefault();

            
            return PartialView(kullanici);
        }

        public ActionResult Friends(Int64 uid)
        {
            if (uid.Equals(null))
            {
                uid = Convert.ToInt64(Request.Cookies["userID"].Value);
            }

            var friends = (from f in ent.UserRelationShips
                           where f.UserID1 == uid && f.Status == 2
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