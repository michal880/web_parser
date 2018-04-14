using RestSharp;
using System.Threading.Tasks;
namespace web_parser.Services
{
    public class ApiService : IApiService
    {
        private string baseUrl = "https://mercury.postlight.com/";

        private string apiKey = "";

        private string parameter;

        public bool sendRequest(string url)
        {
            var apiClient = new RestClient(baseUrl);
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("url", parameter);
            request.AddHeader("Content - Type", "application / json");
            request.AddHeader("x-api-key", apiKey);
            return false;
        }

        public string getResponse()
        {
            return "";
        }
    }
}