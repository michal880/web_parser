using System.Linq;
using System.Net;
using RestSharp;
using System.Threading.Tasks;
namespace web_parser.Services
{
    public class ApiService : IApiService
    {
        private string baseUrl = "https://mercury.postlight.com/";

        private IRestResponse response;

        public bool sendRequest(string url, string apiKey)
        {
            var apiClient = new RestClient(baseUrl);
            var request = new RestRequest("parser?", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("url", url);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-api-key", apiKey);
            response = apiClient.Execute(request);
            System.Diagnostics.Debug.WriteLine(request.Parameters.FirstOrDefault().ToString());
            System.Diagnostics.Debug.WriteLine(response.ErrorMessage);

            if (response.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        }

        public string getResponse()
        {
            return response.Content;
        }
    }
}