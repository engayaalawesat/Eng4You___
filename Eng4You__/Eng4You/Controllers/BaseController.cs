using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;
using System.Data.Entity;

namespace WebLanguages.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // If the session language is not set, default to English
            if (Session["Lang"] == null)
            {
                Session["Lang"] = "en"; // Assuming "en" is the code for English
            }

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
        }

        internal void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
