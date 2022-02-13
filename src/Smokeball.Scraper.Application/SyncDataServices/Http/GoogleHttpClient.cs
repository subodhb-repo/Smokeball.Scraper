using System.Web;
using Microsoft.Extensions.Logging;

namespace Smokeball.Scraper.Application.SyncDataServices.Http
{
    public class GoogleHttpClient : IGoogleHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<GoogleHttpClient> _logger;

        public GoogleHttpClient(
            HttpClient httpClient,
            ILogger<GoogleHttpClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<string> GetGoogleSearchResult(string searchString, int take)
        {
            string url = $"search?num={take}&q={HttpUtility.UrlEncode(searchString)}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = _httpClient.Send(request);
            try
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "HTTP Request to {URL} failed", url);
                throw;
            }
        }
    }
}
