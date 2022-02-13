using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Smokeball.Scraper.Application.DataProcessor;
using Smokeball.Scraper.Application.Handlers.Query;
using Smokeball.Scraper.Application.SyncDataServices.Http;
using Smokeball.Scraper.Core.Validator;
using Xunit;
using static Smokeball.Scraper.Application.Handlers.Query.GetLinkPositions;

namespace Smokeball.Scraper.UnitTests.Application.HandlersTests
{
    public class GetLinkPositionsTests
    {
        private Mock<IGoogleHttpClient> _mockGoogleHttpClient;
        private Mock<IScraper> _mockScraper;
        private Handler _handler;
        public GetLinkPositionsTests()
        {
            _mockGoogleHttpClient = new Mock<IGoogleHttpClient>();
            _mockScraper = new Mock<IScraper>();
            _handler = new Handler(
                _mockGoogleHttpClient.Object,
                _mockScraper.Object);
        }

        [Fact]
        public async Task Handler_SearchesAndReturnsPositions()
        {
            // Arrange
            var request = new GetLinkPositions
            {
                SearchText = "test",
                Url = "www.testurl.com",
                Take = 100,
            };
            var expectedPositions = new List<int>{ 1, 2 };
            _mockScraper.Setup(
                s => s.FindPositions(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(expectedPositions);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            _mockGoogleHttpClient.Verify(
                c => c.GetGoogleSearchResult(
                    It.Is<string>(v => v == request.SearchText),
                    It.Is<int>(v => v == request.Take)),
                Times.Once());
            Assert.Equal(expectedPositions.Count, result.Count);
            Assert.Collection(result,
                item => Assert.Equal(expectedPositions[0], item),
                item => Assert.Equal(expectedPositions[1], item)
            );
        }

        [Theory]
        [InlineData("","www.smokeball.com.au", "Invalid search string")]
        [InlineData("smoke ball", null, "Invalid URL")]
        public async Task Handler_ValidatesRequest(string searchString, string url, string errorMessage)
        {
            // Arrange
            var request = new GetLinkPositions
            {
                SearchText = searchString,
                Url = url,
                Take = 100,
            };

            // Act & Assert
            var result = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(request, CancellationToken.None));
            Assert.Equal(errorMessage, result.Message);
        }
    }
}