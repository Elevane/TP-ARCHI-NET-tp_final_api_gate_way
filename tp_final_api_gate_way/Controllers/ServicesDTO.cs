using AutoMapper;
using tp_final_api_gate_way.Configuration;
using tp_final_gate_way.Utils.Mapper;

namespace tp_final_api_gate_way.Controllers
{
    public class ServicesDTO : IMapFrom<Service>
    {
        public List<ServiceDTO> services { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Services, ServiceDTO>().ReverseMap();
        }
    }
}
