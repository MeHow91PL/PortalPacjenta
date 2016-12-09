using PortalPacjenta.DAL;
using PortalPacjenta.Infrastructure;
using PortalPacjenta.Models;
using PortalPacjenta.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PortalPacjenta.Controllers
{
    [Authorize]
    public class RejestracjaOnlineController : PortalPacjentaMasterController
    {
        SopelContext db = new SopelContext();


        // GET: RejestracjaOnline
        public ActionResult Index()
        {
            var model = pobierzTerminarzViewModels(DateTime.Today.ToString("yyyy-MM-dd"));
            ViewBag.GodzOd = model.opcje.Single(o => o.Nazwa == "term_godz_od").Wartosc;
            ViewBag.GodzDo = model.opcje.Single(o => o.Nazwa == "term_godz_do").Wartosc;
            ViewBag.CzasWiz = model.opcje.Single(o => o.Nazwa == "term_czas_wiz").Wartosc;
            return View("Index", model);
        }

        private TerminarzViewModels pobierzTerminarzViewModels(string wybranaData = null, int pracownikId = 0)
        {
            List<Opcja> opcje = null;
            List<Pracownik> prac = null;
            List<Rezerwacja> rez = null;

            if (wybranaData != null)
            {
                wybranaData = String.Format("{0:yyyy-MM-dd}", wybranaData);

                DateTime data = new DateTime(
                    Convert.ToInt32(wybranaData.Substring(0, 4)),
                    Convert.ToInt32(wybranaData.Substring(5, 2)),
                    Convert.ToInt32(wybranaData.Substring(8, 2))
                    );

                rez = db.Rezerwacje.Where(r => r.DataRezerwacji == data).ToList();
            }
            else
            {
                rez = db.Rezerwacje.ToList();
            }

            if (pracownikId > 0)
            {
                prac = db.Pracownicy.Where(p => p.ID == pracownikId).ToList();
            }
            else
            {
                prac = db.Pracownicy.ToList();
            }

            opcje = db.Opcje.ToList();
            var model = new TerminarzViewModels { opcje = opcje, pracownicy = prac, rezerwacje = rez };

            return model;
        }

        public ViewResult pobierzTerminarzWybranegoLekarza(string data, int idi = 0)
        {
            var model = pobierzTerminarzViewModels(data, idi);

            ViewBag.GodzOd = model.opcje.Single(o => o.Nazwa == "term_godz_od").Wartosc;
            ViewBag.GodzDo = model.opcje.Single(o => o.Nazwa == "term_godz_do").Wartosc;
            ViewBag.CzasWiz = model.opcje.Single(o => o.Nazwa == "term_czas_wiz").Wartosc;

            return View("SiatkaTerminarza", model);
        }

        public JsonResult pobiarzWybranaSpecjalizacje(string spec = "")
        {
            if (string.IsNullOrEmpty(spec))
            {
                return Json(db.Pracownicy.ToList());
            }
            else
            {
                return Json(db.Pracownicy.Where(p => p.Specjalizacja == spec).ToList());
            }
        }

        public PartialViewResult WyświetlKartęRezerwacji(string dataRez, int idLek, string godzRez)
        {

            var rez = new Rezerwacja { DataRezerwacji = DateTime.Parse(dataRez), godzOd = godzRez, PracownikID = idLek };

            var model = new KartaRezerwacji() { Rezerwacja = rez, Pacjent = new Pacjent() };
            return PartialView("KartaRezerwacji", model);
        }

        public ActionResult ZapiszRezerwacje(KartaRezerwacji kartaRezerwacji)
        {
            kartaRezerwacji.Rezerwacja.DataModyfikacji = DateTime.Now;
            string pesel = kartaRezerwacji.Pacjent.Pesel;
            string dataUrodzenia = "";

            if (Convert.ToInt32(pesel.Substring(2, 1)) > 1)
            {
                dataUrodzenia = "20" + pesel.Substring(0, 2) + "-" + pesel.Substring(2, 2) + "-" + pesel.Substring(4, 2);
            }
            else
            {
                dataUrodzenia = "19" + pesel.Substring(0, 2) + "-" + pesel.Substring(2, 2) + "-" + pesel.Substring(4, 2);
            }


            if (db.Pacjenci.Any(p => p.Pesel == kartaRezerwacji.Pacjent.Pesel))
            {
                kartaRezerwacji.Rezerwacja.PacjentID = db.Pacjenci.Single(p => p.Pesel == kartaRezerwacji.Pacjent.Pesel).ID;
            }
            else
            {
                kartaRezerwacji.Pacjent.DataUrodzenia = DateTime.Parse(dataUrodzenia);
                kartaRezerwacji.Rezerwacja.Pacjent = kartaRezerwacji.Pacjent;
                db.Pacjenci.Add(kartaRezerwacji.Pacjent);
            }

            db.Rezerwacje.Add(kartaRezerwacji.Rezerwacja);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public JsonResult ListaPracownikow(string spec)
        {
            List<Pracownik> pracownicy = new List<Pracownik>();

            //Database.otworzPolaczenie("serwer1518407.home.pl", "18292517_0000002", "Sopel2016", "18292517_0000002");
            //NpgsqlDataReader dr = Database.wykonajZapytanieDQL("SELECT * FROM pracownicy where specjalizacja like '" + spec + "'");

            //while (dr.Read())
            //{
            //    pracownicy.Add(new Pracownik() { Id = (int)dr["id"], Imie = dr["imie"].ToString(), Nazwisko = dr["nazwisko"].ToString(), Specjalizacja = dr["specjalizacja"].ToString() });
            //}

            //dr.Close();

            return Json(pracownicy);
        }

        [HttpPost]
        public ActionResult Index(Rezerwacja rezerwacja, string idrez)//idrez ma następujący format idLekarza-godzina-data
        {
            //Database.otworzPolaczenie("serwer1518407.home.pl", "18292517_0000002", "Sopel2016", "18292517_0000002");

            //string[] rez = idrez.Split('-');

            //NpgsqlDataReader dr = Database.wykonajZapytanieDQL("SELECT count(pesel) from pacjenci where pesel = '" + rezerwacja.Pacjent.Pesel + "'");
            //dr.Read();
            //if (dr[0].ToString() == "0")
            //{
            //    dr.Close();

            //    Database.wykonajZapytanieDML("INSERT INTO pacjenci (imie,nazwisko,pesel,dok_toz,telefon,email,plec)" +
            //        "VALUES('" + rezerwacja.Pacjent.Imie.ToUpper() + "', '" + rezerwacja.Pacjent.Nazwisko.ToUpper() + "', '"
            //        + rezerwacja.Pacjent.Pesel + "', '" + rezerwacja.Pacjent.DokumentTozsamosci.ToUpper()
            //        + "', '" + rezerwacja.Pacjent.Telefon.ToUpper() + "', '"
            //        + rezerwacja.Pacjent.Email.ToUpper() + "', '" + rezerwacja.Pacjent.Plec.ToUpper() + "')");
            //}
            //dr.Close();
            //dr = Database.wykonajZapytanieDQL("Select id from pacjenci where pesel = '" + rezerwacja.Pacjent.Pesel + "'");

            //dr.Read();

            //string id = dr["Id"].ToString();

            //dr.Close();

            //Database.wykonajZapytanieDML("INSERT INTO REZERWACJE (ID_PRACOWNIKA,ID_PACJENTA,data)" +
            //    "VALUES(" + rez[0] + ", " + id + ", '" + rezerwacja.DataRezerwacji.ToString("yyyy-MM-dd") + " " + rezerwacja.GodzinaRezerwacji + "')");

            //Database.zamknijPolaczenie();
            return RedirectToAction("Index");
        }



        public ActionResult wczytaj()
        {
            Pacjent pac = new Pacjent();
            //NpgsqlDataReader wynik = Database.wykonajZapytanieDQL("Select * from pacjenci");
            //while (wynik.Read())
            //{
            //    pac.Imie = wynik[2] as string;
            //    pac.Nazwisko = wynik[1] as string;
            //}
            //Database.zamknijPolaczenie();

            return View("Index", pac);
        }

        public JsonResult GetJsonPrac(string term)
        {
            List<string> listaPracowników = new List<string>();
            //NpgsqlDataReader dr = Database.wykonajZapytanieDQL("Select imie || ' ' || nazwisko || ' (' || specjalizacja || ')' from pracownicy");
            //while (dr.Read())
            //{
            //    if((dr[0]as string).ToUpper().Contains(term.ToUpper()))
            //    listaPracowników.Add(dr[0].ToString());
            //}

            //Database.zamknijPolaczenie();

            return Json(listaPracowników, JsonRequestBehavior.AllowGet);
        }


        //public ActionResult pokazLekarza(Rezerwacja rezerwacja)
        //{
        //    List<Pracownik> wybranyLekarz = new List<Pracownik>();

        //    Database.otworzPolaczenie("serwer1518407.home.pl", "18292517_0000002", "Sopel2016", "18292517_0000002");

        //    NpgsqlDataReader dr = Database.wykonajZapytanieDQL("Select * from prac"); /*from prac where nazw=" + rezerwacja.pracownik.nazwisko);*/

        //    while (dr.Read())
        //    {
        //        wybranyLekarz.Add(new Pracownik() { id = (int)dr["id"], imie = dr["imie"].ToString(), nazwisko = dr["nazw"].ToString(), specjalizacja = dr["spec"].ToString() });
        //    }

        //    ViewBag.pokazLekarza = wybranyLekarz;

        //    return View();
        //}
    }
}