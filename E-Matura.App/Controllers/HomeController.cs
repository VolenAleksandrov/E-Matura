using System.Web.Mvc;

namespace E_Matura.App.Controllers
{
    [RoutePrefix("home")]
	public class HomeController : Controller
	{
        [Route]
		public ActionResult Index()
		{
			return this.View();
		}
        [Route("about")]
		public ActionResult About()
		{
			this.ViewBag.Message = "Your application description page.";

			return this.View();
		}
        [Route("contacts")]
		public ActionResult Contact()
		{
			this.ViewBag.Message = "Your contact page.";

			return this.View();
		}
	}
}