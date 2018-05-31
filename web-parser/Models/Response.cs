using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using web_parser.ViewModels;
using HtmlAgilityPack;
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
            SourceUrl = sourceResponse.Url;
            SourceContent = sourceResponse.Content;
            Markups = GetMarkups(sourceResponse.Content);
            Date = DateTime.Now.ToLocalTime();
        }
        private static List<string> GetMarkups(string htmlContent)
        {
            var list = new List<string>();
            var doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);
            foreach (var item in doc.DocumentNode.Descendants())
            {
                if (item.Name != "#text")
                {
                    list.Add(item.Name);
                }
            }
            return list;
        }
    }
}
