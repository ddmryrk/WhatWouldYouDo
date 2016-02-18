using mv.DataModel;
using mv.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mv.Controllers
{
    public class UsersController : Controller
    {
        Model1 ent = new Model1();
        // GET: Users
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users u)
        {
            var kullanici = (from item in ent.Users
                             where item.Email == u.Email && item.Password == u.Password
                             select item).FirstOrDefault();
            Session["KullaniciLogin"] = kullanici;
            //System.Web.Security.FormsAuthentication.SetAuthCookie(kullanici.Name + kullanici.Surname,true);

            return RedirectToAction("Index", "ProfilePage");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register r)
        {
            Users u = new Users();
            u.Name = r.Name;
            u.Surname = r.Surname;
            u.Email = r.Email;
            u.Password = r.Password;
            u.Phone = r.Phone;
            u.City = r.City;
            u.Country = r.Country;
            u.Gender = Convert.ToBoolean(r.Gender);
            u.Birthdate = r.Birthdate;

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/pi"), fileName);
                    file.SaveAs(path);
                    u.PictureLoc = "~/Content/pi/" + fileName;
                }
            }
            u.SignDate = DateTime.Today;
            u.ConfMail = true;
            u.Deleted = false;
            ent.Users.Add(u);
            try
            {
                ent.SaveChanges();
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
            }

            return RedirectToAction("Register");

        }


    }
}