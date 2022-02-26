using AutoMapper;

namespace DoitsuTechnology.Shared.Application.Mappings;

public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}
