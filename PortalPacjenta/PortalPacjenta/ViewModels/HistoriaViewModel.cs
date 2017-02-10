using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalPacjenta.Models;

namespace PortalPacjenta.ViewModels
{
    public class HistoriaViewModel
    {
        public ICollection<Pracownik> pracownicy { get; set; }
        public ICollection<Rezerwacja> rezerwacje { get; set; }
        public ICollection<Wizyta> wizyty { get; set; }
        public ICollection<Rezerwacja> rezerwacjeDzisiejsze { get; set; }
    }
}