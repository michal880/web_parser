using System.ComponentModel.DataAnnotations;
namespace web_parser.ViewModels
{
    public class ApiCredentialsViewModel
    {
        [Required]
        public string WebsiteUrl { get; set; }
        [Required]
        public string ApiKey { get; set; }
    }
}