using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_parser.ViewModels;

namespace web_parser.Models
{
    public class Response
    {
        public DateTime Date { get; set; }
        public string SourceUrl { get; set; }
        public string SourceContent { get; set; }
        public List<string> Markups { get; set; }
        public Response(ApiResponseViewModel sourceResponse)
        {
            SourceContent = sourceResponse.Content;
            Date = DateTime.Now.ToLocalTime();
        }
    }
}
