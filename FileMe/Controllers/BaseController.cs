using FileMe.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace FileMe.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            ViewResultBase view = filterContext.Result as ViewResultBase;
            if (view == null)
                return;

            string cultureName = Thread.CurrentThread.CurrentCulture.Name;

            if (cultureName == CultureHelper.GetDefaultCulture())
                return;


            bool viewImplemented = CultureHelper.IsViewSeparate(cultureName);
            if (viewImplemented == false)
                return;

            string viewName = view.ViewName;

            int i = 0;

            if (string.IsNullOrEmpty(viewName))
                viewName = filterContext.RouteData.Values["action"] + "." + cultureName; // Index.en-US
            else if ((i = viewName.IndexOf('.')) > 0)
            {
                viewName = viewName.Substring(0, i + 1) + cultureName + viewName.Substring(i);
            }
            else
                viewName += "." + cultureName;

            view.ViewName = viewName;

            filterContext.Controller.ViewBag._culture = "." + cultureName;

            base.OnActionExecuted(filterContext);
        }


        protected override void ExecuteCore()
        {
            string cultureName = null;
            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages[0]; // obtain it from HTTP header AcceptLanguages

            // Validate culture name
            cultureName = CultureHelper.GetValidCulture(cultureName); // This is safe

            string Ime = Request.UserLanguages[0].ToString();


            // Modify current thread's culture            
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);


            base.ExecuteCore();
        }
    }
}
