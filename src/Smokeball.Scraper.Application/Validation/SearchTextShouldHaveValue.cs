using Smokeball.Scraper.Core.Validator;

namespace Smokeball.Scraper.Application.Validation
{
    internal class SearchTextShouldHaveValue : IValidation
    {
        private readonly string _searchText;
        public SearchTextShouldHaveValue(string searchText)
        {
            _searchText = searchText;
        }

        string IValidation.Message => "Invalid search string";

        public bool IsBroken() => string.IsNullOrWhiteSpace(_searchText);
    }
}
