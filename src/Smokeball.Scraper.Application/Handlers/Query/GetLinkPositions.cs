using MediatR;
using Smokeball.Scraper.Application.DataProcessor;
using Smokeball.Scraper.Application.SyncDataServices.Http;
using Smokeball.Scraper.Application.Validation;
using Smokeball.Scraper.Core.Validator;

namespace Smokeball.Scraper.Application.Handlers.Query
{
    public class GetLinkPositions : Entity, IRequest<List<int>>
    {
        public int Take { get; set; }
        public string SearchText { get; set; }
        public string Url { get; set; }

        public class Handler : IRequestHandler<GetLinkPositions, List<int>>
        {
            private readonly IGoogleHttpClient _googleHttpClient;
            private readonly IScraper _scraper;
            public Handler(
                IGoogleHttpClient googleHttpClient,
                IScraper scraper)
            {
                _googleHttpClient = googleHttpClient;
                _scraper = scraper;
            }

            public async Task<List<int>> Handle(GetLinkPositions request, CancellationToken cancellationToken)
            {
                ValidateRequest(request);
                var html = await _googleHttpClient.GetGoogleSearchResult(
                    request.SearchText,
                    request.Take);
                return _scraper.FindPositions(html, request.Url);
            }

            private static void ValidateRequest(GetLinkPositions request)
            {
                Validate(new SearchTextShouldHaveValue(request.SearchText));
                Validate(new UrlShouldHaveValue(request.Url));
            }
        }
    }
}
