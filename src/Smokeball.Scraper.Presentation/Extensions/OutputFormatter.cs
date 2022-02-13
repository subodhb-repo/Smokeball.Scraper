using System.Collections.Generic;

namespace Smokeball.Scraper.Presentation.Extensions
{
    public static class OutputFormatter
    {
        public static string Format(this List<int> positions)
        {
            var positionsString = string.Empty;
            foreach (int position in positions)
            {
                positionsString += $" {position},";
            }
            return positionsString.Trim().TrimEnd(',');
        }
    }
}
