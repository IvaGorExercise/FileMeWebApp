using FileMe.Models;
using FileMe.Utility;
using Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace FileMe.Controllers
{
    public class HomeController : Controller
    {

        private UnitOfWork _uow = new UnitOfWork();

        public ActionResult Index(string Jezik)
        {
            string jezikIzBrowsera = Request.UserLanguages[0];
            string kojiView = "Index.hr-HR";

            string jezikDefault = "hr-HR";

            if (!String.IsNullOrEmpty(Jezik))
            {
                jezikDefault = Jezik;

                if (Jezik == "hr-HR")
                {
                    kojiView = "Index.hr-HR";
                }
                else
                {
                    kojiView = "Index.en-US";
                }
            }

            else
            {
            }

            //SetCulture(jezikDefault);

            //ChangeCulture(jezikDefault);

            return View(kojiView);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}


        [HttpGet]
        public ActionResult Contact()
        {
          
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Contact(HttpPostedFileBase file, FileMe.Models.Pitanje pitanjeVM)
        {
            //var slika = Request.Files["file"];
            var slika = file;

            pitanjeVM.File = file;

            if (ModelState.IsValid)
            {

                if (slika != null && slika.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(slika.FileName);
                    var path = Path.Combine(Server.MapPath("~/SlikaPitanje/"), fileName);
                    slika.SaveAs(path);
                    pitanjeVM.Slika = "/SlikaPitanje/" + fileName;
                }

       
                    Model.Pitanje pitanje = new Model.Pitanje();

                    pitanje.Ime = pitanjeVM.Ime;
                    pitanje.Prezime = pitanjeVM.Prezime;
                    pitanje.Email = pitanjeVM.Email;
                    pitanje.PitanjeTekst = pitanjeVM.PitanjeTekst;
                    pitanje.Slika = pitanjeVM.Slika;
                    pitanje.Tag = pitanjeVM.Tag;
                    pitanje.DatumPitanja = DateTime.Now;
                    _uow.basicRepository.Pitanje_Insert(pitanje);

                    pitanjeVM = new FileMe.Models.Pitanje();  // modified line
                    pitanjeVM.SuccessMessage = "Hvala što ste nam poslali svoj upit.";
                    

                //return RedirectToAction("Contact");
            }
            else{

                pitanjeVM.SuccessMessage = "";
                return View(pitanjeVM);

            }

            
            ModelState.Clear();
                   return View(pitanjeVM);

            //return Content("Thanks for uploading", "text/plain");
        }


        public ActionResult SetCulture(string culture)
        {
            culture = CultureHelper.GetValidCulture(culture); ;

            //// Save culture in a cookie
            //HttpCookie cookie = Request.Cookies["_culture"];
            //if (cookie != null)
            //    cookie.Value = culture;   // update cookie value
            //else
            //{

            //    cookie = new HttpCookie("_culture");
            //    cookie.HttpOnly = false; // Not accessible by JS.
            //    cookie.Value = culture;
            //    cookie.Expires = DateTime.Now.AddYears(1);
            //}
            //Response.Cookies.Add(cookie);

            CultureInfo ci = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);


            //return RedirectToAction("Index");

            return RedirectToAction("Index", new { Jezik = culture });
        }



        public ActionResult ChangeCulture(string lang)

        {

            Session["Culture"] = new CultureInfo(lang);

            //return Redirect(returnUrl);

            return RedirectToAction("Index", new { Jezik = lang });

        }

        public ActionResult IndexEn()
        {

            return View();
        }



    }
}
