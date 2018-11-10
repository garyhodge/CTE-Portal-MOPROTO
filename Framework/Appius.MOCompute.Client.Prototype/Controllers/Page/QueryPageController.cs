using System.Web.Mvc;

namespace Appius.MOCompute.Client.Controllers
{
    /// <summary>
    /// Query page controller
    /// </summary>
    public class QueryPageController : Controller
    {
        /// <summary>
        /// Page default action
        /// </summary>
        [Route("query")]
        public ActionResult Index()
        {
            return View("~/Views/Pages/QueryPage.cshtml");
        }
    }
}
