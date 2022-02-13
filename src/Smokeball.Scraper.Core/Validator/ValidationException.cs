namespace Smokeball.Scraper.Core.Validator
{
    public class ValidationException : Exception
    {
        public ValidationException(IValidation brokenValidation)
            : base(brokenValidation.Message)
        {
            BrokenValidation = brokenValidation;
            this.Details = brokenValidation.Message;
        }

        public IValidation BrokenValidation { get; }

        public string Details { get; }

        public override string ToString()
        {
            return $"{BrokenValidation.GetType().FullName}: {BrokenValidation.Message}";
        }
    }
}
