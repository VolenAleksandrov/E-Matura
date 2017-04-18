using System.Web.Mvc;
using E_Matura.Models.ViewModels.Matura;
using E_Matura.Services;

namespace E_Matura.App.Controllers
{
    [RoutePrefix("matura")]
    [Authorize(Roles = "Student, Teacher, Admin")]
    public class MaturaController : Controller
    {
        private MaturaService service;

        public MaturaController()
        {
            this.service = new MaturaService();
        }

        [HttpGet]
        [Route("{grade}/{subject}")]
        public ActionResult Generate12BgMatura(int grade, string subject)
        {
            MaturaVm maturaVm = this.service.GenerateMatura(grade, subject);
            return this.View(maturaVm);
        }
    }
}