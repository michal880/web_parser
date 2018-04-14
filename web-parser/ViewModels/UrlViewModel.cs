using System.ComponentModel.DataAnnotations;
namespace web_parser.ViewModels
{
    public class UrlViewModel
    {
        [Required]
        public string Url { get; set; }
    }
}