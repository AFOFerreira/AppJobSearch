using System.Net.Http;

namespace JobApp.Services
{
    public abstract class Service
    {
        protected HttpClient _client;
        protected string BaseApiUrl = "https://xamarinforms2021api.azurewebsites.net/";

        public Service()
        {
            _client = new HttpClient();
        }
    }
}
