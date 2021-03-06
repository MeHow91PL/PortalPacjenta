﻿using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace PortalPacjenta.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Przychodnia").Include(
                        "~/Scripts/Przychodnia.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Pacjenci").Include(
                        "~/Scripts/Pacjenci.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Terminarz").Include(
                        "~/Scripts/Terminarz.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Account").Include(
             "~/Scripts/Account.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Walidacje").Include(
            "~/Scripts/Walidacje.js"));

            bundles.Add(new ScriptBundle("~/Scripts/RejestracjaOnline").Include(
                        "~/Scripts/RejestracjaOnline.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new StyleBundle("~/Content/RejestracjaOnline").Include(
                      "~/Content/RejestracjaOnline.css"));

            bundles.Add(new StyleBundle("~/Content/Layout").Include(
                      "~/Content/reset.css",
                      "~/Content/Site.css",
                      "~/Content/Layout.css",
                      "~/Content/KartaRezerwacji.css",
                      "~/Content/KartaLogowania.css",
                      "~/Content/KartaRezerwacjiPortalPacjentaNiezalogowany.css"));

            bundles.Add(new StyleBundle("~/Content/Terminarz").Include(
                      "~/Content/Terminarz.css"));

            bundles.Add(new StyleBundle("~/Content/Pacjenci").Include(
                     "~/Content/Pacjenci.css"));

            bundles.Add(new StyleBundle("~/Content/Main").Include(
                      "~/Content/reset.css",
                      "~/Content/index.css",
                      "~/Content/KartaLogowania.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/bootstrap-theme.css",
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
              "~/Content/themes/base/core.css",
              "~/Content/themes/base/resizable.css",
              "~/Content/themes/base/selectable.css",
              "~/Content/themes/base/accordion.css",
              "~/Content/themes/base/autocomplete.css",
              "~/Content/themes/base/button.css",
              "~/Content/themes/base/dialog.css",
              "~/Content/themes/base/slider.css",
              "~/Content/themes/base/tabs.css",
              "~/Content/index.css",
              "~/Content/themes/base/datepicker.css",
              "~/Content/themes/base/progressbar.css",
              "~/Content/themes/base/theme.css"));
        }
    }
}