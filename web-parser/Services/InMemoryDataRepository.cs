using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using web_parser.Models;
using web_parser.ViewModels;

namespace web_parser.Services
{
    public class InMemoryDataRepository : IDataRepository
    {
        private List<Response> _responses = new List<Response>();

        public bool Add(ApiResponseViewModel sourceResponse)
        {
            var parsedResponse = CreateParsedResponse(sourceResponse);
            _responses.Add(parsedResponse);
            return true;
        }

        public List<Response> GetLastFive()
        {
            return _responses.Take(5).ToList();
        }

        private Response CreateParsedResponse(ApiResponseViewModel sourceResponse)
        {
            var response = new Response(sourceResponse);
            return response;
        }
    }
}