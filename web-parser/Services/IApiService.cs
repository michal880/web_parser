﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_parser.Models;
using web_parser.ViewModels;

namespace web_parser.Services
{
    public interface IApiService
    {
        bool sendRequest(string url, string apiKey);
        ApiResponseViewModel GetResponse();
        Response GetLastParsedResponse();
        IEnumerable<string> GetLastFiveUrls();
    }
}
