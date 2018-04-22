using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_parser.ViewModels
{
    public class ApiResponseViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime DatePublished { get; set; }
        public string LeadImageUrl { get; set; }
        public string Dek { get; set; }
        public string NextPageUrl { get; set; }
        public string Url { get; set; }
        public string Domain { get; set; }
        public string Excerpt { get; set; }
        public int WordCount { get; set; }
        public string Direction { get; set; }
        public int TotalPages { get; set; }
        public int RenderedPages { get; set; }

    }
}