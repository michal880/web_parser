using System.Collections.Generic;
using System.Linq;
using web_parser.Models;
using web_parser.ViewModels;

namespace web_parser.Services
{
    public class InMemoryDataRepository : IDataRepository
    {
        private static readonly Stack<Response> _responses = new Stack<Response>();

        public bool Add(ApiResponseViewModel sourceResponse)
        {
            var parsedResponse = CreateParsedResponse(sourceResponse);
            _responses.Push(parsedResponse);
            return true;
        }

        public Response GetLast()
        {
            return _responses.Peek();
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