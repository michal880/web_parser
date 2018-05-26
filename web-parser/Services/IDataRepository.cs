using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.Web;
using web_parser.Models;
using web_parser.ViewModels;

namespace web_parser.Services
{
    public interface IDataRepository
    {
        IQueryable<Response> GetAll();
        Response GetLast();
        IEnumerable<Response> GetLastFive();
        bool Add(ApiResponseViewModel response);
       
        
    }
}
