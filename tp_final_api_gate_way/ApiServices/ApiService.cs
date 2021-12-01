using tp_final_api_gate_way.Configuration;
using tp_final_api_gate_way.Manager;

namespace tp_final_api_gate_way.ApiServices
{
    public class ApiService
    {
        private readonly ApiManager _manager;

        public ApiService(ApiManager manager)=> _manager=manager;


        public async Task<HttpResponseMessage> Ping(Service service)
        {
            HttpResponseMessage res = await _manager.Ping(service);
            return res;
        }

       
    }
}
