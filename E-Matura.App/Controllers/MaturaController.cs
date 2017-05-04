using System.Collections.Generic;
using System.Web.Mvc;
using E_Matura.Models.BindingModels.Questions;
using E_Matura.Models.EntityModels.Matura;
using E_Matura.Models.EntityModels.Questions;
using E_Matura.Models.ViewModels.Matura;
using E_Matura.Models.ViewModels.Questions;
using E_Matura.Services;
using Microsoft.AspNet.Identity;

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
        public ActionResult Matura(int grade, string subject)
        {
            var maturaVm = this.service.GenerateMatura(grade, subject);
            return this.View(maturaVm);
        }

        [HttpPost]
        [Route("{grade}/{subject}")]
        public ActionResult Matura(MaturaVm matura)
        {
            var userId = this.User.Identity.GetUserId();
            MaturaResult maturaResult = this.service.VerificateMatura(matura.Questions, userId);
            return this.MaturaResult(maturaResult);
        }

        [HttpGet]
        [Route("results")]
        public ActionResult MaturaResult(MaturaResult result)
        {
            return this.View(result);
        }
    }
}