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
        bool Add(ApiResponseViewModel response);
        List<Response> GetLastFive();
    }
}
