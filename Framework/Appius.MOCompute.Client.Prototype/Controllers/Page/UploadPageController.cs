using System.Web.Mvc;

namespace Appius.MOCompute.Client.Controllers
{
    /// <summary>
    /// Uoload page controller
    /// </summary>
    public class UploadPageController : Controller
    {
        /// <summary>
        /// Page default action
        /// </summary>
        [Route("upload")]
        public ActionResult Index()
        {
            return View("~/Views/Pages/UploadPage.cshtml");
        }
    }
}
