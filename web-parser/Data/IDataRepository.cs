using System.Collections.Generic;
using System.Linq;
using web_parser.Models;
using web_parser.ViewModels;

namespace web_parser.Data
{
    public interface IDataRepository
    {
        IQueryable<Response> GetAllResponses();
        IQueryable<string> GetAllUrls();
        Response GetLastResponse();
        bool Add(ApiResponseViewModel response);
        bool Add(string attemptedUrl);


    }
}
