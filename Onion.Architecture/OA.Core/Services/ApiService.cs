using Microsoft.Extensions.Configuration;
using OA.Core.Interfaces;
using System.Text.Json;
using System.Threading.Tasks;

namespace OA.Core.Services
{
    public class ApiService : BaseApiService, IApiService
    {
        private readonly IConfiguration _configuration;
        public ApiService(IConfiguration configuration):base()
        {
            _configuration = configuration;
        }

        public override void ConfigureBaseUrl()
        {
            BaseUrl = "https://localhost:3000"; 
        }

        public async Task<T> Get<T>(object items,string uri)
        {
            uri = uri.TrimStart('/');
            var path = $"{BaseUrl}/{uri}";
            var response = await _client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<T>(body);
            return data;
        }
    }
}
