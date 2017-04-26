namespace E_Matura.Data
{
    public class Data
    {
        private static EMaturaContext context;

        public static EMaturaContext Context => context ?? (context = new EMaturaContext());
    }
}
