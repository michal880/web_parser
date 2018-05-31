using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using web_parser.Services;
using web_parser.ViewModels;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using web_parser.Data;
using web_parser.Models;

namespace web_parser.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;

        public HomeController()
        {
            _apiService = new ApiService();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ApiCredentialsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            ViewBag.Message = model.WebsiteUrl+model.ApiKey;
            var requestSucceeded = _apiService.sendRequest(model.WebsiteUrl, model.ApiKey);
            ViewBag.Message = requestSucceeded;
            if (requestSucceeded)
            {
                // this is workaround because RestSharp's json response does not properly format the HTML content(single quotation marks)
                var response = _apiService.getResponse();
                var dateFormatSettings = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DateParseHandling = DateParseHandling.DateTimeOffset
                };
                // Strange issue with date serialization, 
                // for some reason it works with deserializing and not serializing, probably related to RestSharp.
                ViewBag.Response = JsonConvert.SerializeObject(response, dateFormatSettings);
            }

            return View();
        }
        [HttpGet]
        public ActionResult LastFive()
        {
            var model = _apiService.GetLastFive();
            return View(model);
        }
    }
}