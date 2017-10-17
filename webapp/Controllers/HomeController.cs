#region Using

using Falco.WebApi.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using System.Web.Security;

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