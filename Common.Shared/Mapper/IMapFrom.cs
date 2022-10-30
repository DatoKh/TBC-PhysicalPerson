using AutoMapper;

namespace Common.Shared.Mapper
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}
