using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using RestSharp;
using System.Threading.Tasks;
using System.Web.Helpers;
using AutoMapper;
using RestSharp.Deserializers;
using RestSharp.Extensions;
using web_parser.Data;
using web_parser.Models;
using web_parser.ViewModels;

namespace web_parser.Services
{
    public class ApiService : IApiService
    {
        public ApiService()
        {
            _dataRepository = new InMemoryDataRepository();
        }
        private string baseUrl = "https://mercury.postlight.com/";

        private IRestResponse _response;
        private readonly IDataRepository _dataRepository;
        
        public bool sendRequest(string url, string apiKey)
        {
            try
            {
                var apiClient = new RestClient(baseUrl);
                var request = new RestRequest("parser?", Method.GET);
                request.RequestFormat = DataFormat.Json;
                request.AddParameter("url", url);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-api-key", apiKey);
                _response = apiClient.Execute(request);

                if (_response.StatusCode == HttpStatusCode.OK)
                {
                    var model = new JsonDeserializer().Deserialize<ApiResponseViewModel>(_response);
                    _dataRepository.Add(model);
                    return true;
                }
                else
                {
                    //handle other situations
                }
            }
            catch(Exception ex)
            {
                // log ex
            }
            return false;
        }

        public ApiResponseViewModel getResponse() =>
            new JsonDeserializer().Deserialize<ApiResponseViewModel>(_response);

        public IEnumerable<ResponseViewModel> GetLastFive()
        {
            var query = _dataRepository.GetAll().Take(5);
            return Mapper.Map<IEnumerable<Response>, IEnumerable<ResponseViewModel>>(query);
        }

    }
}