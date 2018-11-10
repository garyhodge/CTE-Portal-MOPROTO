using System.Web.Mvc;

namespace Appius.MOCompute.Client.Controllers
{
    /// <summary>
    /// Homepage controller
    /// </summary>
    public class HomePageController : Base.BasePageController
    {
        /// <summary>
        /// Default action
        /// </summary>
        public ActionResult Index()
        {
            return View("~/Views/Pages/HomePage.cshtml");
        }
    }
}
