using System.ComponentModel.DataAnnotations;

namespace Smokeball.Scraper.Presentation.Configurations
{
    public class GoogleClientOptions
    {
        [Required]
        [Url]
        public string BaseUrl { get; set; }
    }
}