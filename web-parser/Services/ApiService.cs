using System.Collections.Generic;
using System.Linq;
using System.Net;
using RestSharp;
using System.Threading.Tasks;
using System.Web.Helpers;
using RestSharp.Deserializers;
using RestSharp.Extensions;
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
        private IDataRepository _dataRepository;
        public bool sendRequest(string url, string apiKey)
        {
            var apiClient = new RestClient(baseUrl);
            var request = new RestRequest("parser?", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("url", url);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-api-key", apiKey);
            _response = apiClient.Execute(request);
            System.Diagnostics.Debug.WriteLine(request.Parameters.FirstOrDefault().ToString());
            System.Diagnostics.Debug.WriteLine(_response.ErrorMessage);

            if (_response.StatusCode == HttpStatusCode.OK)
            {
                // Newtonsoft.Json Deserialzer is not compatible with RestSharp's response when it comes to Json Date
                var model = new JsonDeserializer().Deserialize<ApiResponseViewModel>(_response);
                _dataRepository.Add(model);
                return true;
            }

            return false;
        }

        public string getResponse()
        {
            return _response.Content;
        }
    }
}