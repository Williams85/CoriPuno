using System.Web;
using System.Web.Optimization;

namespace CoriPuno
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/script-layaout").Include(
                                  "~/Scripts/Controladores/functions.js",
                                  "~/Scripts/Controladores/ajax-mvc.js"));
            //Programacion Carguio
            bundles.Add(new ScriptBundle("~/bundles/prog-carguio").Include(
                                  "~/Scripts/Controladores/ProgramacionCarguio/programacioncarguio-route.js",
                                  "~/Scripts/Controladores/ProgramacionCarguio/programacioncarguio-controller.js"));
            //Distribucion de Equipos
            bundles.Add(new ScriptBundle("~/bundles/distribucion-equipos").Include(
                                  "~/Scripts/Controladores/DistribucionMaquinaria/distribucionmaquinaria-route.js",
                                  "~/Scripts/Controladores/DistribucionMaquinaria/distribucionmaquinaria-controller.js"));

            //Mantenimiento de Labores
            bundles.Add(new ScriptBundle("~/bundles/mantenimiento-labor").Include(
                                  "~/Scripts/Controladores/Labor/labor-route.js",
                                  "~/Scripts/Controladores/Labor/labor-controller.js"));

            //Mantenimiento de Rutas
            bundles.Add(new ScriptBundle("~/bundles/mantenimiento-ruta").Include(
                                  "~/Scripts/Controladores/Ruta/ruta-route.js",
                                  "~/Scripts/Controladores/Ruta/ruta-controller.js"));

            //Revision de Carguio
            bundles.Add(new ScriptBundle("~/bundles/cierre-carguio").Include(
                                  "~/Scripts/Controladores/CierreCarguio/cierre-carguio-route.js",
                                  "~/Scripts/Controladores/CierreCarguio/cierre-carguio-controller.js"));

            //Captar Peso
            bundles.Add(new ScriptBundle("~/bundles/captura-peso").Include(
                                  "~/Scripts/Controladores/CapturaPeso/captura-peso-route.js",
                                  "~/Scripts/Controladores/CapturaPeso/captura-peso-controller.js"));

            //Modificacion Peso
            bundles.Add(new ScriptBundle("~/bundles/modificacion-peso").Include(
                                  "~/Scripts/Controladores/ModificacionPeso/modificacion-peso-route.js",
                                  "~/Scripts/Controladores/ModificacionPeso/modificacion-peso-controller.js"));


        }
    }
}
