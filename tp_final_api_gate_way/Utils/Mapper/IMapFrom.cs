using AutoMapper;

namespace tp_final_gate_way.Utils.Mapper
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
