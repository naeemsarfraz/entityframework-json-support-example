using System;
using System.Linq;
using System.Linq.Expressions;
using EntityFramework.Json.Example.Models.GoogleTranslate;

namespace EntityFramework.Json.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TranslationContext())
            {
                db.Database.Log = s => Console.WriteLine(s);

                Seed(db);

                QueryExamples(db);
            }
        }

        private static void QueryExamples(TranslationContext db)
        {
            db.Translations.Where(
                t => t.APIResult.Contains<GoogleTranslateResult>(p => p.data.detections[0][0].isReliable)).ToList();

            db.Translations.Where(
                t => t.APIResult.Contains<GoogleTranslateResult>(p => p.data.detections[0][0].language == "en")).ToList();

            db.Translations.Where(
                t => t.APIResult.Contains<GoogleTranslateResult>(p => p.data.detections[0][0].confidence > 0.5)).ToList();
        }

        private static void Seed(TranslationContext db)
        {
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
