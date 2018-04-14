using RestSharp;
using System.Threading.Tasks;
namespace web_parser.Services
{
    public class ApiService : IApiService
    {
        private string baseUrl = "https://mercury.postlight.com/";

        private string apiKey = "";

        public async Task<bool> sendRequest(string url)
        {
            var apiClient = new RestClient(baseUrl);
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content - Type", "application / json");
            request.AddHeader("x-api-key", apiKey);
            
        }

        public string getResponse()
        {
            return "";
        }
    }
}