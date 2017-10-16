#region Using

using System.Web.Mvc;

#endregion

namespace FalcoMvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: home/index
        public ActionResult Index()
        {
            return View();
        }
    }
}