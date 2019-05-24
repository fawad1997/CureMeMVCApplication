using System.Web;
using System.Web.Optimization;

namespace Cure_Me
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //System.Web.Optimization.BundleTable.EnableOptimizations = false;
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new StyleBundle("~/Content/apps/css").Include(
                "~/Content/apps/inbox.min.css",
                "~/Content/apps/ticket.min.css",
                "~/Content/apps/todo-2.min.css",
                "~/Content/apps/todo.min.css"));
            bundles.Add(new StyleBundle("~/Content/fontawesome/css").Include(
                "~/Content/global/font-awesome.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/Content/fonts").Include(
                "~/Content/global/simple-line-icons.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/Content/global/css").Include(
                "~/Content/global/plugins.min.css",
                "~/Content/global/components.min.css",
                "~/Content/global/bootstrap-switch.min.css",
                "~/Content/global/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Content/layout/css").Include(
                "~/Content/layout/custom.min.css",
                "~/Content/layout/layout.min.css"));
            bundles.Add(new StyleBundle("~/Content/layout/themes/css").Include(
                "~/Content/layout/themes/default.min.css" , new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/pages/css").Include(
                "~/Content/pages/profile.min.css",
                "~/Content/pages/profile-2.min.css",
                "~/Content/pages/bootstrap-fileinput.css"));
            //scripts
            bundles.Add(new ScriptBundle("~/Scripts/plugins/global/js").Include(
                "~/Scripts/plugins/global/bootstrap-switch.min.js",
                "~/Scripts/plugins/global/bootstrap.min.js",
                "~/Scripts/plugins/global/jquery.blockui.min.js",
                "~/Scripts/plugins/global/jquery.min.js",
                "~/Scripts/plugins/global/jquery.slimscroll.min.js",
                "~/Scripts/plugins/global/js.cookie.min.js"));
            bundles.Add(new ScriptBundle("~/Scripts/plugins/page/js").Include(
                 "~/Scripts/plugins/page/amcharts.js",
                 "~/Scripts/plugins/page/chalk.js",
                 "~/Scripts/plugins/page/daterangepicker.min.js",
                 "~/Scripts/plugins/page/fullcalendar.min.js",
                 "~/Scripts/plugins/page/horizontal-timeline.js",
                 "~/Scripts/plugins/page/jquery.counterup.min.js",
                 "~/Scripts/plugins/page/jquery.flot.categories.min.js",
                 "~/Scripts/plugins/page/jquery.flot.min.js",
                 "~/Scripts/plugins/page/jquery.flot.resize.min.js",
                 "~/Scripts/plugins/page/jquery.sparkline.min.js",
                 "~/Scripts/plugins/page/jquery.waypoints.min.js",
                 "~/Scripts/plugins/page/light.js",
                 "~/Scripts/plugins/page/moment.min.js",
                 "~/Scripts/plugins/page/morris.min.js",
                 "~/Scripts/plugins/page/patterns.js",
                 "~/Scripts/plugins/page/pie.js",
                 "~/Scripts/plugins/page/radar.js",
                 "~/Scripts/plugins/page/raphael-min.js",
                 "~/Scripts/plugins/page/serial.js",
                 "~/Scripts/plugins/page/bootstrap-fileinput.js"));
            bundles.Add(new ScriptBundle("~/Scripts/global/js").Include(
                "~/Scripts/global/app.min.js",
                "~/Scripts/global/bootstrap-switch.min.js"));
            bundles.Add(new ScriptBundle("~/Scripts/layout/js").Include(
                "~/Scripts/layout/demo.min.js",
                "~/Scripts/layout/layout.min.js",
                "~/Scripts/layout/quich-nav.min.js",
                "~/Scripts/layout/quick-sidebar.min.js"
                ));
            bundles.Add(new ScriptBundle("~/Scripts/page/js").Include(
                "~/Scripts/page/dashboard.min.js",
                "~/Scripts/page/components-bootstrap-switch.min.js",
                "~/Scripts/page/components-bootstrap-switch.min.js",
                "~/Scripts/page/components-date-time-pickers.min.js"));
            bundles.Add(new ScriptBundle("~/Scripts/core/js").Include(
                "~/Scripts/core/bootstrap-switch.min.js"));
            bundles.Add(new ScriptBundle("~/Scripts/amcharts/js").Include(
                "~/Scripts/amcharts/anchart.js",
                "~/Scripts/amcharts/funnel.js",
                "~/Scripts/amcharts/gantt.js",
                "~/Scripts/amcharts/gauge.js",
                "~/Scripts/amcharts/pie.js",
                "~/Scripts/amcharts/radar.js",
                "~/Scripts/amcharts/serial.js",
                "~/Scripts/amcharts/xy.js"));
        }

    }

}
