using AutoMapper;

namespace Majestim.Interface
{
    public interface IMapperService
    {
        IConfigurationProvider MapperProvider { get; }
    }
}