using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using web_parser.Services;
using web_parser.ViewModels;
namespace web_parser.Controllers
{
    public class HomeController : Controller
    {
        private IApiService _apiService;
        private IDataRepository _dataRepository;

        public HomeController()
        {
            _dataRepository = new InMemoryDataRepository();
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
            ViewBag.Message = model.WebsiteUrl+model.ApiKey;
            var requestSucceeded = _apiService.sendRequest(model.WebsiteUrl, model.ApiKey);
            ViewBag.Message = requestSucceeded;
            if(requestSucceeded)
            ViewBag.Response =  _apiService.getResponse();

            

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Response = _dataRepository.GetLastFive().Count;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}