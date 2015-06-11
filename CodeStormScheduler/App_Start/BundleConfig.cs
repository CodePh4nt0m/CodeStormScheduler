using System.Web;
using System.Web.Optimization;

namespace CodeStormScheduler
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/PixelAdmin").Include(
                      "~/Content/PixelAdmin/bootstrap.min.css",
                      "~/Content/PixelAdmin/pixel-admin.min.css",
                      "~/Content/PixelAdmin/widgets.min.css",
                      "~/Content/PixelAdmin/pages.min.css",
                      "~/Content/PixelAdmin/rtl.min.css",
                      "~/Content/PixelAdmin/themes.min.css"));

            bundles.Add(new StyleBundle("~/Content/Custom").Include(
                      "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/pixeladmin").Include(
                      "~/Scripts/PixelAdmin/bootstrap.min.js",
                      "~/Scripts/PixelAdmin/pixel-admin.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                      "~/Scripts/PixelAdmin/jquery.slimscroll.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-route.js",
                      "~/Scripts/angular-cookies.js"));

            
        }
    }
}
