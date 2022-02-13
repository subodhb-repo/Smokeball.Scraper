namespace Smokeball.Scraper.Application.SyncDataServices.Http
{
    public interface IGoogleHttpClient
    {
        Task<string> GetGoogleSearchResult(string searchString, int take);
    }
}
