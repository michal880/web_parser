﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_parser.Services
{
    public interface IApiService
    {
        bool sendRequest(string url);

        bool getResponse();
    }
}