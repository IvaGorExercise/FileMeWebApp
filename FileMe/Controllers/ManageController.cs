using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;
using Repository.Repository.T4;
using System.IO;


namespace FileMe.Controllers
{
    public class ManageController : Controller
    {

        private UnitOfWork _uow = new UnitOfWork();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pitanja()
        {
            return View(_uow.basicRepository.Pitanje_Select().OrderByDescending(x => x.ID_Pitanje).ToArray());
        }

        [HttpGet]
        public ActionResult UrediPitanje(int id)
        {
            var pitanje = _uow.basicRepository.PitanjeFindByKey(id);
            FileMe.Models.PitanjeVM pitanjeVM = new FileMe.Models.PitanjeVM();

            if (pitanje != null)
            {
             
                pitanjeVM.ID_Pitanje = pitanje.ID_Pitanje;
                pitanjeVM.Ime = pitanje.Ime;
                pitanjeVM.Prezime = pitanje.Prezime;
                pitanjeVM.Email = pitanje.Email;
                pitanjeVM.PitanjeTekst = pitanje.PitanjeTekst;
                pitanjeVM.Slika = pitanje.Slika;
                pitanjeVM.Tag = pitanje.Tag;
                pitanjeVM.Odgovor = pitanje.Odgovor;
                pitanjeVM.DatumPitanja = pitanje.DatumPitanja;
                pitanjeVM.DatumOdgovora = pitanje.DatumOdgovora;
                pitanjeVM.Komentar = pitanje.Komentar;
                pitanjeVM.Odgovor = pitanje.Odgovor;
                pitanjeVM.Odgovoreno = pitanje.Odgovoreno;

                if (pitanje.Procitano == false)
                {
                    pitanje.Procitano = true;

                    bool itemupdate = _uow.basicRepository.Pitanje_Update(pitanje);

                    if (itemupdate)
                    {
                        pitanjeVM.Procitano = true;
                    }

                    else
                    {
                        pitanjeVM.Procitano = false;
                    }

                }
                else
                {
                    pitanjeVM.Procitano = pitanje.Procitano;
                }
            }



            return View(pitanjeVM);
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult UrediPitanje(FileMe.Models.PitanjeVM pitanjeVM)
        {
            //var slika = Request.Files["file"];

            Model.Pitanje pitanjeIzBaze = _uow.basicRepository.PitanjeFindByKey(pitanjeVM.ID_Pitanje);

            if (pitanjeIzBaze != null)
            {
                if (ModelState.IsValid)
                {
                    pitanjeIzBaze.ID_Pitanje = pitanjeVM.ID_Pitanje;
                    pitanjeIzBaze.Ime = pitanjeVM.Ime;
                    pitanjeIzBaze.Prezime = pitanjeVM.Prezime;
                    pitanjeIzBaze.Email = pitanjeVM.Email;
                    pitanjeIzBaze.PitanjeTekst = pitanjeVM.PitanjeTekst;
                    pitanjeIzBaze.Slika = pitanjeVM.Slika;
                    pitanjeIzBaze.Tag = pitanjeVM.Tag;
                    pitanjeIzBaze.Procitano = pitanjeVM.Procitano;
                    pitanjeIzBaze.Odgovoreno = pitanjeVM.Odgovoreno;
                    pitanjeIzBaze.Odgovor = pitanjeVM.Odgovor;
                    pitanjeIzBaze.DatumPitanja = pitanjeVM.DatumPitanja;
                    pitanjeIzBaze.DatumOdgovora = pitanjeVM.DatumOdgovora;
                    pitanjeIzBaze.Komentar = pitanjeVM.Komentar;
                    pitanjeIzBaze.Odgovor = pitanjeVM.Odgovor;

                    bool itemupdate = _uow.basicRepository.Pitanje_Update(pitanjeIzBaze);

                    return RedirectToAction("Pitanja");

                }

                else
                {
                    return View(pitanjeVM);
                }
            }


      
    
            return View();
        }

        public ActionResult ObrisiPitanje(int id)
        {
            Model.Pitanje vijest = _uow.basicRepository.PitanjeFindByKey(id);

            if (vijest.Slika != null)
                System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(vijest.Slika));

            _uow.basicRepository.Pitanje_Delete(id);
            //return Redirect(Request.UrlReferrer.ToString());
            return RedirectToAction("Pitanja");
        }

    }
}
