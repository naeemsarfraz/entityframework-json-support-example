using System.Threading.Tasks;

namespace EntityFramework.Json.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task<int> MainAsync(string[] args)
        {
            using (var db = new TranslationContext())
            {
                await Seed(db);

                await QueryExamples(db);
            }

            return 0;
        }

        private static Task QueryExamples(TranslationContext db)
        {
            return Task.FromResult(0);
        }

        private static Task Seed(TranslationContext db)
        {
            return Task.FromResult(0);
        }
    }
}
