using System.Web;
using System.Web.Optimization;

namespace MiracleStone.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(Links.Bundles.Scripts.CoreScripts).Include(
                        "~" + Links.Scripts.JQuery.Validation.jquery_validate_js,
                        "~" + Links.Scripts.JQuery.Validation.jquery_validate_unobtrusive_js,
                        "~" + Links.Scripts.JQuery.Ajax.jquery_unobtrusive_ajax_js));
        }
    }
}
