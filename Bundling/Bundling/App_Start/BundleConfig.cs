using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
namespace Bundling
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            var bundle = new ScriptBundle("~/bundles/js");
            bundle.Include("~/Content/JS/JavaScript1.js",
                "~/Content/JS/JavaScript2.js",
                "~/Content/JS/JavaScript3.js" );

            bundles.Add(bundle);
           BundleTable.EnableOptimizations = true;
        }
    }
}