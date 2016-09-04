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
            var results1 = db.Translations.Where(
                t => t.APIResult.WhereJson<GoogleTranslateResult>(p => p.data.detections[0][0].isReliable)).ToList();
            //SELECT * FROM Translations WHERE JSON_VALUE(APIResult, '$.data.detections[0][0].isReliable)') == true

            var results2 = db.Translations.Where(
                t => t.APIResult.WhereJson<GoogleTranslateResult>(p => p.data.detections[0][0].language == "en")).ToList();
            //SELECT * FROM Translations WHERE JSON_VALUE(APIResult, '$.data.detections[0][0].language)') == 'en'

            var results3 = db.Translations.Where(
                t => t.APIResult.WhereJson<GoogleTranslateResult>(p => p.data.detections[0][0].confidence > 0.5)).ToList();
            //SELECT * FROM Translations WHERE JSON_VALUE(APIResult, '$.data.detections[0][0].confidence)') > 0.5
        }

        private static void Seed(TranslationContext db)
        {
            db.Translations.Add(Translation.From(1, "en", true, 1, "to be or not to be"));
            db.Translations.Add(Translation.From(2, "fr", false, 0.0, "to be or not to be"));
            db.Translations.Add(Translation.From(3, "nl", true, 78.2436452, "zijn of niet zijn"));
            db.Translations.Add(Translation.From(4, "ar", true, 45.56756, "أكون أو لا أكون"));
            db.Translations.Add(Translation.From(5, "fr", true, 1, "être ou ne pas être"));
            db.Translations.Add(Translation.From(6, "de", true, 89.4545, "sein oder nicht sein"));
            db.Translations.Add(Translation.From(7, "fr", false, 43.2535234, "être ou ne pas être"));
            db.Translations.Add(Translation.From(8, "fr", true, 84.4353463, "être ou ne pas être"));
            db.Translations.Add(Translation.From(9, "fr", true, 55.456456, "Bonjour"));
            db.Translations.Add(Translation.From(10, "de", false, 25.456443, "Hallo"));

            db.SaveChanges();
        }
    }

    public static class QueryExtensions
    {
        public static bool WhereJson<TSource>(this string source, Expression<Func<TSource, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
