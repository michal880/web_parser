using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_parser.ViewModels
{
    public class ResponseViewModel
    {
        public DateTime Date { get; set; }
        public string SourceUrl { get; set; }
        public string SourceContent { get; set; }
        public List<string> Markups { get; set; }
    }
}