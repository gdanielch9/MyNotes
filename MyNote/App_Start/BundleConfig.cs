﻿using System.Web;
using System.Web.Optimization;

namespace MyNote
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
                      "~/Content/site.css",
                      "~/Content/ShowEvents.css"));

            bundles.Add(new StyleBundle("~/Content/validators").Include(
                    "~/Content/Validation*"));

            bundles.Add(new ScriptBundle("~/bundles/dropzone").Include(
                    "~/Scripts/dropzone/dropzone.js",
                    "~/Scripts/dropzone/dropzone-amd-module.js"));

            bundles.Add(new StyleBundle("~/Content/dropzone").Include(
                    "~/Content/dropzone/dropzone.css",
                    "~/Content/dropzone/basic.css"));
        }
    }
}
