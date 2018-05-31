using System.Collections.Generic;
using System.Linq;
using web_parser.Models;
using web_parser.ViewModels;

namespace web_parser.Data
{
    public class InMemoryDataRepository : IDataRepository
    {
        private static readonly Stack<Response> Responses = new Stack<Response>();

        public bool Add(ApiResponseViewModel sourceResponse)
        {
            var parsedResponse = CreateParsedResponse(sourceResponse);
            Responses.Push(parsedResponse);
            return true;
        }

        public Response GetLast()
        {
            return Responses.Peek();
        }
        public IQueryable<Response> GetAll()
        {
            return Responses.AsQueryable();
        }
        private Response CreateParsedResponse(ApiResponseViewModel sourceResponse)
        {
            var response = new Response(sourceResponse);
            return response;
        }
    }
}