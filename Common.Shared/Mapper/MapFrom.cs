using AutoMapper;

namespace Common.Shared.Mapper
{
    public class MapFrom<T> : IMapFrom<T>
    {
        public void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
