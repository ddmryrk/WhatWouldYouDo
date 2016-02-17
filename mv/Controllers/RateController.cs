using mv.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mv.Controllers
{
    public class RateController : Controller
    {
        DataModel.Model1 ent = new DataModel.Model1();
        // GET: Rate
        public ActionResult Index()
        {
            int userID = 6;
            var raters = (from r in ent.RateUserRelations
                          where r.UserID == userID
                          select r.RateID).ToList();
            var rate = (from rt in ent.Rates
                        where !(raters.Contains(rt.ID)) && rt.UserID != userID
                        orderby Guid.NewGuid()
                        select rt).FirstOrDefault();
            if (rate != null)
            {
                return View(rate);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult Rating(int rateID)
        {
            RateUserRelations r = new RateUserRelations();
            r.RateID = rateID;
            r.UserID = 6;
            double rate = Convert.ToDouble(ViewBag.rate);
            var ratee = (from rt in ent.Rates
                         where rt.ID == rateID
                         select rt).FirstOrDefault();
            ratee.StarPoint = ratee.StarPoint + (Convert.ToDouble(Request.Form["rate"]) / 10);
            ratee.RateCount = ratee.RateCount + 1;
            ent.RateUserRelations.Add(r);
            try
            {
                ent.SaveChanges();
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
            }
            return RedirectToAction("Index");
        }

        public ActionResult ShareRate()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ShareRate(string p)
        {
            Rates r = new Rates();
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/ratePics"), fileName);
                    file.SaveAs(path);
                    r.PictureLoc = "~/Content/ratePics/" + fileName;
                    r.StarPoint = 0;
                    r.RateCount = 0;
                }
            }
            ent.Rates.Add(r);
            try
            {
                ent.SaveChanges();
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
            }

            return RedirectToAction("Index","ProfilePage");

        }
    }
}