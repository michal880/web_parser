using System.ComponentModel.DataAnnotations;
namespace web_parser.ViewModels
{
    public class UrlViewModel
    {
        [Required]
        public string ApiUrl { get; set; }
        [Required]
        public string ApiKey { get; set; }
    }
}