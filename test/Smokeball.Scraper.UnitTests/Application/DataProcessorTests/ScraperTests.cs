using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit;
using DataProcessor = Smokeball.Scraper.Application.DataProcessor;

namespace Smokeball.Scraper.UnitTests.Application.DataProcessorTests
{
    public class ScraperTests
    {
        [Fact]
        public void Scraper_Should_Return_SearchPositions()
        {
            // Arrange
            var scraper = new DataProcessor.Scraper();
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestFile.html");
            var html = File.ReadAllText(path);
            var url = "www.smokeball.com.au";
            var expectedPositions = new List<int> { 1, 3 };

            // Act
            var result = scraper.FindPositions(html, url);

            // Assert
            Assert.Collection(result,
                item => Assert.Equal(expectedPositions[0], item),
                item => Assert.Equal(expectedPositions[1], item)
            );
        }
    }
}
