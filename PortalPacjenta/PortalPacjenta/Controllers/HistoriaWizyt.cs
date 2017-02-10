using Microsoft.AspNet.Identity;
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
    public class HistoriaWizytController : PortalPacjentaMasterController
    {
        SopelContext db = new SopelContext();


        // GET: RejestracjaOnline
        public ActionResult Index()
        {

            
            var user = UserManager.FindById(User.Identity.GetUserId());
            var prac = db.Pracownicy.ToList();
            var wiz = db.Wizyty.Where(w=> w.Pacjent.Pesel==user.Pesel).ToList();
            var rez = db.Rezerwacje.Where(w=>w.Pacjent.Pesel==user.Pesel && w.Stat==0).ToList();
           
            var model = new HistoriaViewModel { pracownicy = prac, rezerwacje = rez, wizyty = wiz };
            return View(model);
        }

        public PartialViewResult pokazHistorie(int idwizy)
        {
           Wizyta wizyta = db.Wizyty.Find(idwizy);
           return PartialView("_KartaWizytyHistoria", wizyta);
        }



    }
}