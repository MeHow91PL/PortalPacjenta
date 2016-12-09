using PortalPacjenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalPacjenta.ViewModels
{
    public class TerminarzViewModels
    {
        public List<Pracownik> pracownicy { get; set; }
        public ICollection<Rezerwacja> rezerwacje { get; set; }
        public ICollection<Opcja>opcje { get; set; }
    }

    public class KartaRezerwacji
    {
        public Pacjent Pacjent { get; set; }
        public Rezerwacja Rezerwacja { get; set; }
    }
}