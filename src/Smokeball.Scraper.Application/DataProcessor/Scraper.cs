using System.Text.RegularExpressions;
using Smokeball.Scraper.Application.Constants;

namespace Smokeball.Scraper.Application.DataProcessor
{
    public class Scraper : IScraper
    {
        public List<int> FindPositions(string html, string url)
        {
            var expressions = new Regex(Patterns.GoogleSearchResultLinks);
            var matches = expressions.Matches(html);
            var positions = new List<int>();
            for (int i = 0; i < matches.Count; i++)
            {
                string match = matches[i].Groups[2].Value;
                if (match.Contains(url))
                {
                    positions.Add(i + 1);
                }                    
            }

            return positions;
        }
    }
}
