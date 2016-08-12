using System.Web.Optimization;

namespace FormBuilder.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/vendor").Include(
                        "~/lib/jquery/dist/jquery.js",
                        "~/lib/jquery-ui/jquery-ui.js",
                        "~/Scripts/spin.min.js",
                        "~/Scripts/jquery.ext.js",
                        "~/Scripts/jquery-postjson.js",
                        "~/lib/bootstrap/dist/js/bootstrap.js",
                        "~/lib/handlebars/handlebars.min.js",
                        "~/lib/alpaca/bootstrap/alpaca.js",
                        // Beautify (used by EditorField)
                        "~/lib/js-beautify/js/lib/beautify.js",
                        "~/lib/js-beautify/js/lib/beautify-css.js",
                        "~/lib/js-beautify/js/lib/beautify-html.js",
                        // typeahead.js
                        "~/lib/typeahead.js/dist/bloodhound.min.js",
                        "~/lib/typeahead.js/dist/typeahead.bundle.min.js",
                        "~/lib/datatables.net/js/jquery.dataTables.js",
                        "~/lib/datatables.net-bs/js/dataTables.bootstrap.js",
                        "~/lib/datatables.net-rowreorder/js/dataTables.rowReorder.js",
                         // fck editor
                        "~/lib/ckeditor/ckeditor.js",
                         // handsontable (for GridField)
                        "~/lib/handsontable/dist/jquery.handsontable.full.js",
                         // moment js for localization
                        "~/lib/moment/min/moment-with-locales.min.js",
                        // datetime control
                        "~/lib/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js",
                        "~/lib/bootstrap-multiselect/js/bootstrap-multiselect.js",
                        "~/lib/jquery-price-format/jquery.price_format.min.js",
                        "~/lib/ace-builds/src-min-noconflict/ace.js",
                        "~/lib/notify/notify.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/common.js",
                      "~/Scripts/pageManager.js",
                      "~/Scripts/pageController.js",
                      //"~/Scripts/tree.js",
                      //
                      "~/Scripts/Home/page.js",
                      //builder
                      "~/Scripts/Builder/builder.js",
                      "~/Scripts/Builder/page.js",
                      //Details
                      "~/Scripts/Details/formListControl.js",
                      "~/Scripts/Details/formList.js",
                      "~/Scripts/Details/formList2.js",
                      "~/Scripts/Details/formDetails.js",
                      "~/Scripts/Details/page.js",
                      //Results
                      "~/Scripts/Results/formResults.js",
                      "~/Scripts/Results/page.js"
                      ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/Fonts/fontawesome/css/font-awesome.min.css",
                      "~/lib/bootstrap/dist/css/bootstrap.css",
                      "~/lib/bootstrap/dist/css/bootstrap-theme.css",
                      "~/lib/datatables.net-bs/css/dataTables.bootstrap.css",
                      "~/lib/handsontable/dist/jquery.handsontable.full.css",
                      "~/lib/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.css",
                      "~/lib/bootstrap-multiselect/css/bootstrap-multiselect.css",
                      "~/content/form-builder.css",
                      "~/Content/site.css"));
        }
    }
}
