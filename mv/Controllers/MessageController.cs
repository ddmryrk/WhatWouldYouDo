using mv.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mv.Controllers
{
    public class MessageController : Controller
    {
        DataModel.Model1 ent = new DataModel.Model1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Conversations()
        {

            Users u = (Users)Session["KullaniciLogin"];
            Session["UserID"] = u.ID;
            var kullanici = (from k in ent.Users
                             where k.ID == u.ID
                             select k).FirstOrDefault();
            Int64 k2 = (from c in ent.Conversations
                        where c.UserID1 == u.ID
                        select c.UserID2).FirstOrDefault();
            if (k2 == 0)
            {
                k2 = (from c in ent.Conversations
                      where c.UserID2 == u.ID
                      select c.UserID1).FirstOrDefault();
            }
            var kullanici2 = (from k in ent.Users
                              where k.ID == k2
                              select k).FirstOrDefault();
            Session["k2Ad"] = kullanici2.Name + " " + kullanici2.Surname;
            Session["k2Pic"] = kullanici2.PictureLoc;
            Session["kullanici"] = kullanici.Name + kullanici.Surname;
            var conv = (from c in ent.Conversations
                        where c.UserID1 == u.ID || c.UserID2 == u.ID
                        select c).ToList();
            return PartialView(conv);
        }
        public ActionResult Messages(int ConversationID)
        {
            Session["convID"] = ConversationID;
            var mess = (from m in ent.Messages
                        where m.ConversationID == ConversationID
                        select m).ToList();
            return PartialView(mess);
        }
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(string Msg)
        {
            DataModel.Messages m = new DataModel.Messages();
            m.ConversationID = Convert.ToInt32(Session["convID"]);
            m.Message = Msg;
            m.SendingID = Convert.ToInt64(Session["UserID"]);
            m.Datetime = DateTime.Now;
            ent.Messages.Add(m);
            try
            {
                ent.SaveChanges();
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
            }

            return RedirectToAction("Conversations");
        }
    }
}