using AutoMapper;
using tp_final_api_gate_way.Configuration;
using tp_final_gate_way.Utils.Mapper;

namespace tp_final_api_gate_way.Controllers
{
    public class ServiceDTO : IMapFrom<Service>
    {
        public string Name { get; set; }

        public string Key { get; set; }

        public  string url { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Service, ServiceDTO>().ReverseMap();
        }
    }
}