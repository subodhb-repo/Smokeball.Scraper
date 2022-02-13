namespace Smokeball.Scraper.Application.Constants
{
    public static class Patterns
    {
        public const string GoogleSearchResultLinks = @"(?inx)
        <a \s
            href =
                (?<q> ['""] )
                    (?<url> [^""]+ )
                \k<q>
        [^>]* ><h3";
    }
}
