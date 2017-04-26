namespace E_Matura.Data.DependencyContainer
{
    using Ninject;
    public class DependencyContainer
    {
        private static StandardKernel kernel;

        public static StandardKernel Kernel => kernel ?? (kernel = new StandardKernel(new InjectionModule()));
    }
}
