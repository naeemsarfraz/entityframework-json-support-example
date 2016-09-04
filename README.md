# Proposal: SQL 2016 JSON support for Linq to Entities\Entity Framework

Now that [SQL 2016 has introduced JSON support](https://blogs.msdn.microsoft.com/jocapc/2015/05/16/json-support-in-sql-server-2016/) in the form of new in-built operators I am looking at ways to utilise them in C# using Entity Framework.

This repository is a self-contained example of how I'd like to query JSON data. JSON in SQL 2016 will continue to be stored in a nvarchar column so any C# Linq query will have to begin by operating on the `string` type. Here's an example of how I think this can work as a consumer.


    db.Translations.Where(
        t => t.APIResult.WhereJson<GoogleTranslateResult>
    (p => p.data.detections[0][0].language == "en"))


This would translate into the following SQL query.


    SELECT *
    FROM Translations
    WHERE JSON_VALUE(APIResult, '$.data.detections[0][0].language)') == 'en'


`APIResult` is a property of type `string` and `GoogleTranslateResult` is a class representation of the JSON string. The JSON in this example looks like this:


    {
        "data": {
            "detections": [
                [
                    {
                        "language":"en",
                        "isReliable":false,
                        "confidence":0.011111111
                    }
                ]
            ]
        }
    }


I'm looking for a solution that works with EF 6 and might look at EF Core at some point. I'm looking for feedback on this syntax as I'm only looking at the new `JSON_VALUE` function. 

What do you think? Have an alternative? Feel free to fork and send a PR. I'll be working on this in the coming weeks.