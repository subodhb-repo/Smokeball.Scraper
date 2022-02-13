using System.Collections.Generic;
using Smokeball.Scraper.Presentation.Extensions;
using Xunit;

namespace Smokeball.Scraper.UnitTests.Presentation
{
    public class OutputFormatterTests
    {

        [Fact]
        public void SearchButton_Click_Should_GetUrlPositions()
        {
            // Arrange
            var positions = new List<int> { 1, 2, 3 };

            // Act
            var result = positions.Format();

            // Assert
            Assert.Equal("1, 2, 3", result);
        }
    }
}
