using System.Web.Mvc;

namespace FormBuilder.Controllers
{
    public class PageController : Controller
    {
        public ActionResult MainPage()
        {
            return PartialView();
        }

        public ActionResult BuilderPage()
        {
            return PartialView();
        }

        public ActionResult DetailsPage()
        {
            return PartialView();
        }

        public ActionResult ResultsPage()
        {
            return PartialView();
        }
    }
}