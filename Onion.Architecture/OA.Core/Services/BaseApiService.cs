using System.Net.Http;

namespace OA.Core.Services
{
    public abstract class BaseApiService
    {
        public static HttpClient _client = new HttpClient();
        public virtual string BaseUrl { get; set; }
        public BaseApiService()
        {
            ConfigureBaseUrl();
        }

        public virtual void ConfigureBaseUrl()
        {
        }
    }
}
