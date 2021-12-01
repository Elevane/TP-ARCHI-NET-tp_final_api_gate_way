using tp_final_api_gate_way.Configuration;

namespace tp_final_api_gate_way.Manager
{
    public class ApiManager
    {
        private readonly HttpClient _httpClient;
       
        public ApiManager(HttpClient httpClient) { _httpClient = httpClient;}


        public async Task<HttpResponseMessage> Ping(Service service)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{service.url}/{service.key}/ping");
            return response;
        }
        
       
    }
}
