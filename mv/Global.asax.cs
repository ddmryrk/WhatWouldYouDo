using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace mv
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_PreRequestHandlerExecute()
        {
            try
            {
                if (Session["lang"] != null)
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["lang"].ToString());
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["lang"].ToString());
                }
            }
            catch (HttpException ex)
            {
                string hata = ex.Message;
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
        {
            Session["lang"] = "tr-TR";
        }
    }
}
