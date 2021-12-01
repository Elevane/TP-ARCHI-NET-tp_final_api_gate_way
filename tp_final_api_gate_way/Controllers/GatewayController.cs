using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using tp_final_api_gate_way.ApiServices;
using tp_final_api_gate_way.Configuration;
using tp_final_api_gate_way.Extensions;
using tp_final_score_api.Controllers;

namespace tp_final_api_gate_way.Controllers
{

    [ApiController]
    [Route("/gateway")]
    public class GatewayController :Controller
    {
        private readonly IMapper _mapper;
        private readonly JsonServiceManager _manager;
        private readonly ApiService _service;

        public GatewayController(JsonServiceManager manager, IMapper mapper, ApiService service)
        {
            _manager = manager; 
            _mapper = mapper;
            _service = service;
            
        }

        [HttpGet("/[controller]/routes")]
        public async Task<Result<ServicesDTO>> GetServices()
        {
            ServicesDTO aciveServices = new ServicesDTO()
            {
                services = new List<ServiceDTO>()
            };

            Services services = _manager.GetServices();
            foreach(Service service in services.services)
            {
                HttpResponseMessage res = await _service.Ping(service);
                if (res.IsSuccessStatusCode)
                    aciveServices.services.Add(_mapper.Map<ServiceDTO>(service));
            }
            
            return Result.Ok<ServicesDTO>(aciveServices);
        }

        

    }
}
