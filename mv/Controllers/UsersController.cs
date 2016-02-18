using mv.DataModel;
using mv.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
        public ActionResult Login(string Email,string Password, string returnUrl)
        {
            var model = ent.Users.Where(u => u.Email.Equals(Email) && u.Password.Equals(Password)).FirstOrDefault();

            if (ModelState.IsValid)
            {
                using (Model1 entities = new Model1())
                {
                    string email = model.Email;
                    string username = model.Name + " " + model.Surname;
                    string password = model.Password;

                    bool userValid = entities.Users.Any(user => user.Email == email && user.Password == password);

                    if (userValid)
                    {

                        FormsAuthentication.SetAuthCookie(username, false);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    }
                }
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
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