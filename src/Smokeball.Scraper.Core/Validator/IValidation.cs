namespace Smokeball.Scraper.Core.Validator
{
    public interface IValidation
    {
        string Message { get; }

        bool IsBroken();
    }
}
