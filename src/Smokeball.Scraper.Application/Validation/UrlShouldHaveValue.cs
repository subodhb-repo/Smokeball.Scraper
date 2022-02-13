using Smokeball.Scraper.Core.Validator;

namespace Smokeball.Scraper.Application.Validation
{
    internal class UrlShouldHaveValue : IValidation
    {
        private readonly string _url;
        public UrlShouldHaveValue(string url)
        {
            _url = url;
        }

        public string Message => "Invalid URL";

        public bool IsBroken() => string.IsNullOrWhiteSpace(_url);
    }
}
