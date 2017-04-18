using E_Matura.Data;

namespace E_Matura.Services
{
	public class Service
	{
		private EMaturaContext context;

		protected Service()
		{
			this.context = new EMaturaContext();
		}

		protected EMaturaContext Context => this.context;
	}
}