using System.Web;
using System.Web.Optimization;

namespace ExercicioFuncionario
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/Libs/jquery/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/JQueryValidation").Include(
                        "~/Scripts/Libs/JQueryValidation/jquery.validate.min.js",
                        "~/Scripts/Libs/JQueryValidation/localization/messages_pt_BR.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                        "~/Scripts/Libs/DataTable/datatable*",
                        "~/Scripts/Libs/DataTable/bootstrap/dataTables.*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                          "~/Scripts/Libs/jquery/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                       "~/Scripts/Libs/select2/select2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Libs/bootstrap/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/select2").Include(
                      "~/Content/select2/select2.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/Content").Include(
                        "~/Content/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/datatable").Include(
                      "~/Content/Datatable/datatable*",
                      "~/Content/Datatable/bootstrap/dataTables.*"));




        }
    }
}
