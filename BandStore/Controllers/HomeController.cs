using System.Web.Mvc;

namespace AbstraktApp.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Having trouble? Send us a message.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string msg)
        {
            //TODO : send message to HQ
            ViewBag.Message = "Thanks, we got your message.";

            return View();
        }
    }
}