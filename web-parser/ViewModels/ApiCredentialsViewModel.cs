using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Serialization;

namespace web_parser.ViewModels
{
    public class ApiCredentialsViewModel
    {
        [Required, Url]
        public string WebsiteUrl { get; set; }
        [Required]
        public string ApiKey { get; set; }
    }
}