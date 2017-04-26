using E_Matura.Data.Contracts;
using Ninject.Modules;

namespace E_Matura.Data.DependencyContainer
{
    public class InjectionModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
            //this.Bind<IUsersService>().To<UsersService>();
            //this.Bind<IAdminService>().To<AdminService>();
            //this.Bind<IHomeService>().To<HomeService>();
        }
    }
}
