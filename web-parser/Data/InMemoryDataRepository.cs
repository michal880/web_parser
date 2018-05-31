using System;
using System.Collections.Generic;
using System.Linq;
using web_parser.Models;
using web_parser.ViewModels;

namespace web_parser.Data
{
    public class InMemoryDataRepository : IDataRepository
    {
        private static readonly Stack<Response> Responses = new Stack<Response>();
        private static readonly Stack<string> AttemptedUrls = new Stack<string>();

        public IQueryable<Response> GetAllResponses()
        {
            return Responses.AsQueryable();
        }
        public IQueryable<string> GetAllUrls()
        {
            return AttemptedUrls.AsQueryable();
        }
        public bool Add(ApiResponseViewModel sourceResponse)
        {
            var count = Responses.Count;
            var parsedResponse = CreateParsedResponse(sourceResponse);
            Responses.Push(parsedResponse);

            return Responses.Count > count;
        }

        public bool Add(string attemptedUrl)
        {
            var count = AttemptedUrls.Count;
            AttemptedUrls.Push(attemptedUrl);

            return Responses.Count > count;
        }
        public Response GetLastResponse()
        {
            try
            {
                return Responses.Peek();
            }
            catch (Exception e)
            {
                //log ex
            }

            return null;

        }
        
        private Response CreateParsedResponse(ApiResponseViewModel sourceResponse)
        {
            var response = new Response(sourceResponse);
            return response;
        }
    }
}