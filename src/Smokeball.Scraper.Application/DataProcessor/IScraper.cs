namespace Smokeball.Scraper.Application.DataProcessor
{
    public interface IScraper
    {
        List<int> FindPositions(string html, string url);
    }
}