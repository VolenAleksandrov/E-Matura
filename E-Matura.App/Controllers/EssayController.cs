using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Matura.Models.ViewModels.Matura;
using E_Matura.Services;

namespace E_Matura.App.Areas.Essaies.Controllers
{
    [RoutePrefix("essay")]
    public class EssayController : Controller
    {
        private EssayService service;
        public EssayController()
        {
            this.service = new EssayService();
        }
        [HttpGet]
        [Route("upload")]
        public ActionResult UploadEssay()
        {
            return this.View(new UploadEssayVm());
        }
    }
}