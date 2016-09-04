namespace EntityFramework.Json.Example
{
    public class Translation
    {
        public short ID { get; private set; }
        public string Text { get; private set; }
        public string APIResult { get; private set; }

        public static Translation From(short id, string languageCode, bool isReliable, double confidence, string text)
        {
            return new Translation
            {
                ID = id,
                APIResult = $"{{\"data\":{{\"detections\":[[{{\"language\":\"{languageCode}\",\"isReliable\":{isReliable},\"confidence\":{confidence}}}]]}}}}",
                Text = text
            };
        }
    }
}