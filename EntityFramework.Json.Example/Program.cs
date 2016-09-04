using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EntityFramework.Json.Example.Models.GoogleTranslate;

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
                db.Database.Log = s => Console.WriteLine(s);

                await Seed(db);

                await QueryExamples(db);
            }

            return 0;
        }

        private static Task QueryExamples(TranslationContext db)
        {
            db.Translations.Where(
                t => t.APIResult.Contains<GoogleTranslateResult>(p => p.data.detections[0][0].isReliable)).ToListAsync();

            db.Translations.Where(
                t => t.APIResult.Contains<GoogleTranslateResult>(p => p.data.detections[0][0].language == "en")).ToListAsync();

            db.Translations.Where(
                t => t.APIResult.Contains<GoogleTranslateResult>(p => p.data.detections[0][0].confidence > 0.5)).ToListAsync();

            return Task.FromResult(0);
        }

        private static Task Seed(TranslationContext db)
        {
            return Task.FromResult(0);
        }
    }

    public static class QueryExtensions
    {
        public static bool Contains<TSource>(this string source, Expression<Func<TSource, bool>> predicate)
        {
            return false;
        }
    }
}
