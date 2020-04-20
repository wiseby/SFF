namespace Persistence
{
    public class RefDataMovies
    {
        /// <summary>
        /// Checks that the reference data exists in the database
        /// </summary>
        /// <param name="context"></param>
        public static void StartSeeding(DataContext context)
        {
            CategorySeed(context);
        }

        private static void CategorySeed(DataContext context)
        {
            
        }
    }
}