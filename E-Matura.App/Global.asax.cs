using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using E_Matura.Models.EntityModels.Answers;
using E_Matura.Models.EntityModels.Matura;
using E_Matura.Models.ViewModels.Answers;
using E_Matura.Models.ViewModels.Matura;

namespace E_Matura.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.ConfigureManager();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureManager()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<List<ClosedAnswer>,
                List<ClosedAnswerVm>>();
                expression.CreateMap<MaturaResult, MaturaResultVm>();
            });
        }
    }
}
