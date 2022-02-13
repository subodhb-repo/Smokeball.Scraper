namespace Smokeball.Scraper.Core.Validator
{
    public abstract class Entity
    {
        protected static void Validate(IValidation rule)
        {
            if (rule.IsBroken())
            {
                throw new ValidationException(rule);
            }
        }
    }
}
