using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PortalPacjenta.Models;
using System.Data.Entity.Migrations;
using PortalPacjenta.Migrations;
using static PortalPacjenta.Infrastructure.Enums;

namespace PortalPacjenta.DAL
{
    internal class SopelInitializer : MigrateDatabaseToLatestVersion<SopelContext, Configuration>
    {
        //zostało to przenesione do configuration.cs w migracjach
        //protected override void Seed(SopelContext context)
        //{

        //        SeedsopelLocal(context);
        //        base.Seed(context);


        //}

        public static void SeedsopelLocal(SopelContext context)
        {
            var opcje = new List<Opcja>
            {
               new Opcja() { Nazwa="term_godz_od", ID=1, Wartosc="08:00"},
               new Opcja() { Nazwa="term_godz_do", ID=2, Wartosc="16:00"},
               new Opcja() { Nazwa="term_czas_wiz", ID=3, Wartosc="10"},
               new Opcja() { Nazwa="term_indw_graf", ID=4, Wartosc="0"},
               new Opcja() { Nazwa="ogol_podz_imie_nazw", ID=5, Wartosc=";"}
            };
            opcje.ForEach(s => context.Opcje.AddOrUpdate(s));
            context.SaveChanges();

            var pracownicy = new List<Pracownik>
            {
                new Pracownik() { ID=1, Imie="Stephen", Nazwisko="Strange", Pesel="86062905358", Telefon="666555444", Email="ss@marvel.pl", PWZ="1234565", Specjalizacja="Chirurgia", TytulNaukowy="dr"},
                new Pracownik() {ID=2, Imie="Michaela", Nazwisko="Quinn", Pesel="86062905358", Telefon="123456789", Email="dr@quinn.pl", PWZ="7654323", Specjalizacja="Internista", TytulNaukowy="dr"}

            };
            pracownicy.ForEach(z => context.Pracownicy.AddOrUpdate(z));
            context.SaveChanges();



            var pacjenci = new List<Pacjent>
           {
               new Pacjent() { ID=1, Imie="Jan", Nazwisko="Kowalski", Pesel="86062905358", Telefon="666555444", Email="kowalski@wp.pl", Aktw= Aktywny.Tak},
                new Pacjent() { ID=2, Imie="Piotr", Nazwisko="Nowak", Pesel="86062905359", Telefon="666555444", Email="nowak@poczta.onet.pl", Aktw = Aktywny.Tak}
           };
            pacjenci.ForEach(g => context.Pacjenci.AddOrUpdate(g));
            context.SaveChanges();





            var rezerwacje = new List<Rezerwacja>();
            {


                for (int i = 0; i < 30; i++)
                {
                    rezerwacje.Add(new Rezerwacja()
                    {
                        Id = i,
                        DataModyfikacji = DateTime.Today.AddDays(i),
                        DataRezerwacji = DateTime.Today.AddDays(i),
                        godzOd = "09:30",
                        godzDo = "10:00",
                        PacjentID = 1,
                        PracownikID = 1
                    });
                }

                rezerwacje.ForEach(g => context.Rezerwacje.AddOrUpdate(g));
                context.SaveChanges();


                var rozpoznania = new List<ICD10>
           {
             new ICD10() { Id=1, Kod="999",Nazwa="Kod strajkowy"},
new ICD10() { Id=2, Kod="A",Nazwa="Choroby zakażne i pasożytnicze"},
new ICD10() { Id=3, Kod="A00",Nazwa="Cholera"},
new ICD10() { Id=4, Kod="A00.0",Nazwa="Cholera wywołana przecinkowcem klasycznym Vibrio cholerae 01, biotyp cholerae"},
new ICD10() { Id=5, Kod="A00.1",Nazwa="Cholera wywołana przecinkowcem Vibrio cholerae 01, biotyp El-Tor"},
new ICD10() { Id=6, Kod="A00.9",Nazwa="Cholera, nie określona"},
new ICD10() { Id=7, Kod="A01",Nazwa="Dur brzuszny i dury rzekome"},
new ICD10() { Id=8, Kod="A01.0",Nazwa="Dur brzuszny"},
new ICD10() { Id=9, Kod="A01.1",Nazwa="Dur rzekomy A"},
new ICD10() { Id=10, Kod="A01.2",Nazwa="Dur rzekomy B"},
new ICD10() { Id=11, Kod="A01.3",Nazwa="Dur rzekomy C"},
new ICD10() { Id=12, Kod="A01.4",Nazwa="Dur rzekomy, nie określony"},
new ICD10() { Id=13, Kod="A02",Nazwa="Inne zakażenia wywołane pałeczkami Salmonella"},
new ICD10() { Id=14, Kod="A02.0",Nazwa="Zatrucia pokarmowe wywołane przez pałeczki Salmonella"},
new ICD10() { Id=15, Kod="A02.1",Nazwa="Posocznica wywołana pałeczkami Salmonella"},
new ICD10() { Id=16, Kod="A02.2",Nazwa="+Umiejscowione zakażenia pałeczkami Salmonella"},
new ICD10() { Id=17, Kod="A02.8",Nazwa="Inne określone zakażenia pałeczkami Salmonella"},
new ICD10() { Id=18, Kod="A02.9",Nazwa="Zakażenia pałeczkami Salmonella, nie określone"},
new ICD10() { Id=19, Kod="A03",Nazwa="Zakażenia wywołane pałeczkami Shigella (szigeloza)"},
new ICD10() { Id=20, Kod="A03.0",Nazwa="Szigeloza wywołana przez pałeczkę Shigella dysenteriae"},
new ICD10() { Id=21, Kod="A03.1",Nazwa="Szigeloza wywołana przez pałeczkę Shigella flexneri"},
new ICD10() { Id=22, Kod="A03.2",Nazwa="Szigeloza wywołana przez pałeczkę Shigella boydii"},
new ICD10() { Id=23, Kod="A03.3",Nazwa="Szigeloza wywołana przez pałeczkę Shigella sonnei"},
new ICD10() { Id=24, Kod="A03.8",Nazwa="Inne szigelozy"},
new ICD10() { Id=25, Kod="A03.9",Nazwa="Szigeloza, nie określona"},
new ICD10() { Id=26, Kod="A04",Nazwa="Inne bakteryjne zakażenia jelitowe"},
new ICD10() { Id=27, Kod="A04.0",Nazwa="Zakażenia Escherichia coli enteropatogenną"},
new ICD10() { Id=28, Kod="A04.1",Nazwa="Zakażenie Escherichia coli enterotoksyczną"},
new ICD10() { Id=29, Kod="A04.2",Nazwa="Zakażenie Escherichia coli enteroinwazyjną"},
new ICD10() { Id=30, Kod="A04.3",Nazwa="Zakażenie Escherichia coli enterokrwotoczną"},
new ICD10() { Id=31, Kod="A04.4",Nazwa="Inne jelitowe zakażenia Escherichia coli"},
new ICD10() { Id=32, Kod="A04.5",Nazwa="Zapalenie jelit wywołane przez Campylobacter"},
new ICD10() { Id=33, Kod="A04.6",Nazwa="Zapalenie jelit wywołane przez Yersinia enterocolitica"},
new ICD10() { Id=34, Kod="A04.7",Nazwa="Zapalenie jelita cienkiego i grubego wywołane przez Clostridium difficile"},
new ICD10() { Id=35, Kod="A04.8",Nazwa="Inne określone zakażenia bakteryjne jelit"},
new ICD10() { Id=36, Kod="A04.9",Nazwa="Zakażenie bakteryjne jelit, nie określone"},
new ICD10() { Id=37, Kod="A05",Nazwa="Inne bakteryjne zatrucia pokarmowe"},
new ICD10() { Id=38, Kod="A05.0",Nazwa="Zatrucie pokarmowe gronkowcowe"},
new ICD10() { Id=39, Kod="A05.1",Nazwa="Zatrucie jadem kiełbasianym"},
new ICD10() { Id=40, Kod="A05.2",Nazwa="Zatrucie pokarmowe wywołane przez laseczkę Clostridium perfringens (Clostridium welchii)"},
new ICD10() { Id=41, Kod="A05.3",Nazwa="Zatrucie pokarmowe wywołane przez Vibrio parahemolyticus"},
new ICD10() { Id=42, Kod="A05.4",Nazwa="Zatrucie pokarmowe wywołane przez Bacillus cereus"},
new ICD10() { Id=43, Kod="A05.8",Nazwa="Inne określone bakteryjne zatrucie pokarmowe"},
new ICD10() { Id=44, Kod="A05.9",Nazwa="Bakteryjne zatrucie pokarmowe, nie określone"},
new ICD10() { Id=45, Kod="A06",Nazwa="Pełzakowica"},
new ICD10() { Id=46, Kod="A06.0",Nazwa="Pełzakowa czerwonka ostra"},
new ICD10() { Id=47, Kod="A06.1",Nazwa="Pełzakowica jelitowa przewlekła"},
new ICD10() { Id=48, Kod="A06.2",Nazwa="Pełzakowy nieżyt jelita grubego, nieczerwonkowy"},
new ICD10() { Id=49, Kod="A06.3",Nazwa="Guzowate nacieczenie ściany jelita"},
new ICD10() { Id=50, Kod="A06.4",Nazwa="Pełzakowy ropień wątroby"},
new ICD10() { Id=51, Kod="A06.5",Nazwa="+Pełzakowy ropień płuc (J99.8*)"},
new ICD10() { Id=52, Kod="A06.6",Nazwa="+Pełzakowy ropień mózgu (G07*)"},
new ICD10() { Id=53, Kod="A06.7",Nazwa="Pełzakowica skórna"},
new ICD10() { Id=54, Kod="A06.8",Nazwa="Pełzakowe zakażenie umiejscowione gdzie indziej"},
new ICD10() { Id=55, Kod="A06.9",Nazwa="Pełzakowica, nie określona"},
new ICD10() { Id=56, Kod="A07",Nazwa="Zakażenia jelitowe wywołane przez inne pierwotniaki"},
new ICD10() { Id=57, Kod="A07.0",Nazwa="Szparkoszyca [balantydioza]"},
new ICD10() { Id=58, Kod="A07.1",Nazwa="Giardiaza (lamblioza)"},
new ICD10() { Id=59, Kod="A07.2",Nazwa="Kryptosporydioza"},
new ICD10() { Id=60, Kod="A07.3",Nazwa="Izosporydoza"},
new ICD10() { Id=61, Kod="A07.8",Nazwa="Inne określone choroby jelit wywołane przez pierwotniaki"},
new ICD10() { Id=62, Kod="A07.9",Nazwa="Choroby jelit wywołane przez pierwotniaki, nie określone"},
new ICD10() { Id=63, Kod="A08",Nazwa="Wirusowe i inne określone zakażenia jelitowe"},
new ICD10() { Id=64, Kod="A08.0",Nazwa="Nieżyt jelitowy wywołany przez rotawirusy"},
new ICD10() { Id=65, Kod="A08.1",Nazwa="Ostra gastroenteropatia wywołana przez czynnik Norwalk"},
new ICD10() { Id=66, Kod="A08.2",Nazwa="Nieżyt jelitowy wywołany przez adenowirusy"},
new ICD10() { Id=67, Kod="A08.3",Nazwa="Nieżyt jelitowy wywołany przez inne wirusy"},
new ICD10() { Id=68, Kod="A08.4",Nazwa="Zakażenia wirusowe jelit, nie określone"},
new ICD10() { Id=69, Kod="A08.5",Nazwa="Inne określone zakażenia jelit"},
new ICD10() { Id=70, Kod="A09",Nazwa="Biegunka i zapalenie żołądkowo-jelitowe o prawdopodobnie zakaźnym pochodzeniu"},
new ICD10() { Id=71, Kod="A15",Nazwa="Gruźlica układu oddechowego, bakteriologicznie i histologicznie potwierdzona"},
new ICD10() { Id=72, Kod="A15.0",Nazwa="Gruźlica płuc, potwierdzona mikroskopowym badaniem plwociny, z posiewem lub bez posiewu"},
new ICD10() { Id=73, Kod="A15.1",Nazwa="Gruźlica płuc potwierdzona wyłącznie posiewem"},
new ICD10() { Id=74, Kod="A15.2",Nazwa="Gruźlica płuc potwierdzona histologicznie"},
new ICD10() { Id=75, Kod="A15.3",Nazwa="Gruźlica płuc potwierdzona nieokreślonymi sposobami"},
new ICD10() { Id=76, Kod="A15.4",Nazwa="Gruźlica wewnątrzpiersiowych węzłów chłonnych, potwierdzona bakteriologicznie i histologicznie"},
new ICD10() { Id=77, Kod="A15.5",Nazwa="Gruźlica krtani, tchawicy i oskrzela, potwierdzona bakteriologicznie i histologicznie"},
new ICD10() { Id=78, Kod="A15.6",Nazwa="Gruźlicze zapalenie opłucnej, potwierdzone bakteriologicznie i histologicznie"},
new ICD10() { Id=79, Kod="A15.7",Nazwa="Pierwotna gruźlica układu oddechowego, potwierdzona bakteriologicznie i histologicznie"},
new ICD10() { Id=80, Kod="A15.8",Nazwa="Inne postacie gruźlicy układu oddechowego, potwierdzone bakteriologicznie i histologicznie"},
new ICD10() { Id=81, Kod="A15.9",Nazwa="Gruźlica układu oddechowego nie określona, potwierdzona bakteriologicznie i histologicznie"},
new ICD10() { Id=82, Kod="A16",Nazwa="Gruźlica układu oddechowego, nie potwierdzona bakteriologicznie i histologicznie"},
new ICD10() { Id=83, Kod="A16.0",Nazwa="Gruźlica płuc, bakteriologicznie i histologicznie ujemna"},
new ICD10() { Id=84, Kod="A16.1",Nazwa="Gruźlica płuc, badań bakteriologicznych i histologicznych nie przeprowadzono"},
new ICD10() { Id=85, Kod="A16.2",Nazwa="Gruźlica płuc, bez wzmiankowania o potwierdzeniu bakteriologicznym lub histologicznym"},
new ICD10() { Id=86, Kod="A16.3",Nazwa="Gruźlica wewnątrzpiersiowych węzłów chłonnych, bez wzmianki o potwierdzeniu bakteriologicznym lub histologicznym"},
new ICD10() { Id=87, Kod="A16.4",Nazwa="Gruźlica krtani, tchawicy i oskrzela, bez wzmianki o potwierdzeniu bakteriologicznym lub histologicznym"},
new ICD10() { Id=88, Kod="A16.5",Nazwa="Gruźlicze zapalenie opłucnej, bez wzmianki o potwierdzeniu bakteriologicznym lub histologicznym"},
new ICD10() { Id=89, Kod="A16.7",Nazwa="Pierwotna gruźlica układu oddechowego, bez wzmianki o potwierdzeniu bakteriologicznym lub histologicznym"},
new ICD10() { Id=90, Kod="A16.8",Nazwa="Inne postacie gruźlicy układu oddechowego, bez wzmianki o potwierdzeniu bakteriologicznym lub histologicznym"},
new ICD10() { Id=91, Kod="A16.9",Nazwa="Gruźlica układu oddechowego, nie określona, bez wzmianki o potwierdzeniu bakteriologicznym lub histologicznym"},
new ICD10() { Id=92, Kod="A17",Nazwa="+Gruźlica układu nerwowego"},
new ICD10() { Id=93, Kod="A17.0",Nazwa="+Gruźlicze zapalenie opon mózgowych (G01*)"},
new ICD10() { Id=94, Kod="A17.1",Nazwa="+Gruźliczak oponowy (G07*)"},
new ICD10() { Id=95, Kod="A17.8",Nazwa="+Inne postacie gruźlicy układu nerwowego"},
new ICD10() { Id=96, Kod="A17.9",Nazwa="+Gruźlica układu nerwowego, nie określona (G99.8*)"},
new ICD10() { Id=97, Kod="A18",Nazwa="Gruźlica innych narządów"},
new ICD10() { Id=98, Kod="A18.0",Nazwa="+Gruźlica kości i stawów"},
new ICD10() { Id=99, Kod="A18.1",Nazwa="+Gruźlica układu moczowo-płciowego"},
new ICD10() { Id=100, Kod="A18.2",Nazwa="Gruźlicza obwodowa limfadenopatia"},
new ICD10() { Id=101, Kod="A18.3",Nazwa="Gruźlica jelit, otrzewnej i węzłów chłonnych krezkowych"},
new ICD10() { Id=102, Kod="A18.4",Nazwa="Gruźlica skóry i tkanki podskórnej"},
new ICD10() { Id=103, Kod="A18.5",Nazwa="+Gruźlica oka"},
new ICD10() { Id=104, Kod="A18.6",Nazwa="+Gruźlica ucha"},
new ICD10() { Id=105, Kod="A18.7",Nazwa="+Gruźlica nadnerczy (E35.1*)"},
new ICD10() { Id=106, Kod="A18.8",Nazwa="+Gruźlica innych określonych narządów"},
new ICD10() { Id=107, Kod="A19",Nazwa="Gruźlica prosówkowa"},
new ICD10() { Id=108, Kod="A19.0",Nazwa="Gruźlica prosówkowa ostra o pojedynczej określonej lokalizacji"},
new ICD10() { Id=109, Kod="A19.1",Nazwa="Gruźlica prosówkowa ostra o wielomiejscowej lokalizacji"},
new ICD10() { Id=110, Kod="A19.2",Nazwa="Gruźlica prosówkowa ostra, nie określona"},
new ICD10() { Id=111, Kod="A19.8",Nazwa="Inne postacie gruźlicy prosówkowej"},
new ICD10() { Id=112, Kod="A19.9",Nazwa="Gruźlica prosówkowa, nie określona"},
new ICD10() { Id=113, Kod="A20",Nazwa="Dżuma"},
new ICD10() { Id=114, Kod="A20.0",Nazwa="Dżuma dymienicza"},
new ICD10() { Id=115, Kod="A20.1",Nazwa="Dżuma skóry i tkanki podskórnej"},
new ICD10() { Id=116, Kod="A20.2",Nazwa="Dżuma płucna"},
new ICD10() { Id=117, Kod="A20.3",Nazwa="Zapalenie opon mózgowych (dżumowe)"},
new ICD10() { Id=118, Kod="A20.7",Nazwa="Dżuma posocznicowa"},
new ICD10() { Id=119, Kod="A20.8",Nazwa="Inne postacie dżumy"},
new ICD10() { Id=120, Kod="A20.9",Nazwa="Dżuma, nie określona"},
new ICD10() { Id=121, Kod="A21",Nazwa="Tularemia"},
new ICD10() { Id=122, Kod="A21.0",Nazwa="Tularemia, postać wrzodziejąco-węzłowa"},
new ICD10() { Id=123, Kod="A21.1",Nazwa="Tularemia, postać oczno-węzłowa"},
new ICD10() { Id=124, Kod="A21.2",Nazwa="Tularemia płucna"},
new ICD10() { Id=125, Kod="A21.3",Nazwa="Tularemia, postać żołądkowo-jelitowa"},
new ICD10() { Id=126, Kod="A21.7",Nazwa="Tularemia uogólniona"},
new ICD10() { Id=127, Kod="A21.8",Nazwa="Inne formy tularemii"},
new ICD10() { Id=128, Kod="A21.9",Nazwa="Tularemia, nie określona"},
new ICD10() { Id=129, Kod="A22",Nazwa="Wąglik"},
new ICD10() { Id=130, Kod="A22.0",Nazwa="Wąglik skórny"},
new ICD10() { Id=131, Kod="A22.1",Nazwa="Wąglik płucny"},
new ICD10() { Id=132, Kod="A22.2",Nazwa="Wąglik jelitowy"},
new ICD10() { Id=133, Kod="A22.7",Nazwa="Posocznica wąglikowa"},
new ICD10() { Id=134, Kod="A22.8",Nazwa="Inne postacie wąglika"},
new ICD10() { Id=135, Kod="A22.9",Nazwa="Wąglik, nie określony"},
new ICD10() { Id=136, Kod="A23",Nazwa="Bruceloza"},
new ICD10() { Id=137, Kod="A23.0",Nazwa="Bruceloza wywołana pałeczką maltańską [Br.melitensis]"},
new ICD10() { Id=138, Kod="A23.1",Nazwa="Bruceloza wywołana pałeczką ronienia krów [Br.abortus var.bovis]"},
new ICD10() { Id=139, Kod="A23.2",Nazwa="Bruceloza wywołana pałeczką ronienia świń [Br.abortus var.suis]"},
new ICD10() { Id=140, Kod="A23.3",Nazwa="Bruceloza wywołana pałeczką psią [Br.canis]"},
new ICD10() { Id=141, Kod="A23.8",Nazwa="Inne postacie brucelozy"},
new ICD10() { Id=142, Kod="A23.9",Nazwa="Bruceloza, nie określona"},
new ICD10() { Id=143, Kod="A24",Nazwa="Nosacizna i melioidoza"},
new ICD10() { Id=144, Kod="A24.0",Nazwa="Nosacizna"},
new ICD10() { Id=145, Kod="A24.1",Nazwa="Ostra i piorunująca postać melioidozy"},
new ICD10() { Id=146, Kod="A24.2",Nazwa="Podostra i przewlekła postać melioidozy"},
new ICD10() { Id=147, Kod="A24.3",Nazwa="Inne postacie melioidozy"},
new ICD10() { Id=148, Kod="A24.4",Nazwa="Melioidoza, nie określona"},
new ICD10() { Id=149, Kod="A25",Nazwa="Gorączka szczurza [choroba od ukąszenia przez szczura]"},
new ICD10() { Id=150, Kod="A25.0",Nazwa="Krętkowica (spiriloza)"},
new ICD10() { Id=151, Kod="A25.1",Nazwa="Streptobaciloza (choroba wywołana przez Streptobacillus)"},
new ICD10() { Id=152, Kod="A25.9",Nazwa="Gorączka szczurza, nie określona"},
new ICD10() { Id=153, Kod="A26",Nazwa="Różyca"},
new ICD10() { Id=154, Kod="A26.0",Nazwa="Różyca skórna"},
new ICD10() { Id=155, Kod="A26.7",Nazwa="Posocznica wywołana włoskowcami różycy"},
new ICD10() { Id=156, Kod="A26.8",Nazwa="Inne formy różycy"},
new ICD10() { Id=157, Kod="A26.9",Nazwa="Różyca, nie określona"},
new ICD10() { Id=158, Kod="A27",Nazwa="Krętkowica [leptospiroza]"},
new ICD10() { Id=159, Kod="A27.0",Nazwa="Żółtaczkowo-krwotoczna postać leptospirozy"},
new ICD10() { Id=160, Kod="A27.8",Nazwa="Inne formy leptospirozy"},
new ICD10() { Id=161, Kod="A27.9",Nazwa="Leptospiroza, nie określona"},
new ICD10() { Id=162, Kod="A28",Nazwa="Inne bakteryjne choroby odzwierzęce, niesklasyfikowane gdzie indziej"},
new ICD10() { Id=163, Kod="A28.0",Nazwa="Zakażenie wywołane przez pałeczki Pasteurella (pastereloza)"},
new ICD10() { Id=164, Kod="A28.1",Nazwa="Choroba kociego pazura"},
new ICD10() { Id=165, Kod="A28.2",Nazwa="Jersinioza pozajelitowa"},
new ICD10() { Id=166, Kod="A28.8",Nazwa="Inna określona bakteryjna choroba odzwierzęca, niesklasyfikowana gdzie indziej"},
new ICD10() { Id=167, Kod="A28.9",Nazwa="Bakteryjna choroba odzwierzęca, nie określona"},
new ICD10() { Id=168, Kod="A30",Nazwa="Trąd [choroba Hansena]"},
new ICD10() { Id=169, Kod="A30.0",Nazwa="Trąd, nie określony"},
new ICD10() { Id=170, Kod="A30.1",Nazwa="Trąd tuberkuloidowy"},
new ICD10() { Id=171, Kod="A30.2",Nazwa="Trąd graniczny tuberkuloidowy"},
new ICD10() { Id=172, Kod="A30.3",Nazwa="Trąd graniczny"},
new ICD10() { Id=173, Kod="A30.4",Nazwa="Trąd graniczny lepromatyczny"},
new ICD10() { Id=174, Kod="A30.5",Nazwa="Trąd lepromatyczny"},
new ICD10() { Id=175, Kod="A30.8",Nazwa="Inne postacie trądu"},
new ICD10() { Id=176, Kod="A30.9",Nazwa="Trąd, nie określony"},
new ICD10() { Id=177, Kod="A31",Nazwa="Zakażenia wywołane przez inne prątki"},
new ICD10() { Id=178, Kod="A31.0",Nazwa="Płucne zakażenia prątkowe"},
new ICD10() { Id=179, Kod="A31.1",Nazwa="Skórne zakażenia prątkowe"}
 };
                rozpoznania.ForEach(g => context.KodyICD10.AddOrUpdate(g));
                context.SaveChanges();


            }
        }
    }
}


