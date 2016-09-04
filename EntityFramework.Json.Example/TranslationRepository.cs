namespace EntityFramework.Json.Example
{
    public class TranslationRepository
    {
        private readonly TranslationContext _context;

        public TranslationRepository(TranslationContext context)
        {
            _context = context;
        }
    }
}
