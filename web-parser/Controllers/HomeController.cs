using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using web_parser.Services;
using web_parser.ViewModels;
using AutoMapper;
using web_parser.Models;

namespace web_parser.Controllers
{
    public class HomeController : Controller
    {
        private IApiService _apiService;
        private IDataRepository _dataRepository;

        public HomeController()
        {
            _dataRepository = new InMemoryDataRepository();
            _apiService = new ApiService(_dataRepository);
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
            if(requestSucceeded)
            ViewBag.Response =  _apiService.getResponse();

            return View();
        }
        [HttpGet]
        public ActionResult LastFive()
        {
            var model = Mapper.Map<IEnumerable<Response>, IEnumerable <ResponseViewModel>>(_dataRepository.GetLastFive());
            return View(model);
        }
    }
}