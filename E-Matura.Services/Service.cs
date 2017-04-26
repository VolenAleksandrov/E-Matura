namespace E_Matura.Services
{
    using Data.Contracts;
    using Ninject;
    using static Data.DependencyContainer.DependencyContainer;
	public class Service
	{
		private IUnitOfWork context;

		protected Service()
		{
		    this.context = Kernel.Get<IUnitOfWork>();
		}

		protected IUnitOfWork Context => this.context;
	}
}